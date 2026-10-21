using System;
using System.Security.Cryptography;
using System.Text;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    /// <summary>
    /// Đăng nhập, đổi mật khẩu của chính mình (BR11).
    /// Mật khẩu lưu dạng  salt$hash  với hash = SHA-256(salt + matkhau) viết hex HOA.
    /// Salt là chuỗi ngẫu nhiên riêng cho mỗi tài khoản, lưu ngay cạnh hash.
    /// </summary>
    public static class AuthBLL
    {
        // ===== Mật khẩu =====

        // SHA-256 của chuỗi (salt + mật khẩu), mã hóa UTF-8, trả về hex HOA
        static string Bam(string matKhau, string salt)
        {
            using (var sha = SHA256.Create())
                return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(salt + matKhau))).Replace("-", "");
        }

        public static string TaoMatKhauHash(string matKhau)
        {
            string salt = Guid.NewGuid().ToString("N");     // 32 ký tự hex, mỗi lần một khác
            return salt + "$" + Bam(matKhau, salt);
        }

        public static bool KiemTraMatKhau(string matKhau, string daLuu)
        {
            if (matKhau == null || daLuu == null) return false;
            int i = daLuu.IndexOf('$');
            if (i <= 0) return false;                       // lưu sai định dạng thì coi như không khớp
            return Bam(matKhau, daLuu.Substring(0, i)) == daLuu.Substring(i + 1).ToUpper();
        }

        /// <summary>Luật cho mật khẩu mới (dùng cả khi tạo tài khoản, đặt lại và đổi). Trả về lỗi, hoặc null.</summary>
        public static string KiemTraMatKhauMoi(string matKhau)
        {
            if (string.IsNullOrEmpty(matKhau) || matKhau.Length < 6) return "Mật khẩu phải có ít nhất 6 ký tự.";
            if (matKhau.Length > 50) return "Mật khẩu tối đa 50 ký tự.";
            return null;
        }

        // ===== Phiên làm việc =====

        /// <summary>Trả về lỗi, hoặc null nếu đăng nhập được (khi đó AppSession đã có thông tin người dùng).</summary>
        public static string DangNhap(string tenDN, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrEmpty(matKhau))
                return "Vui lòng nhập tên đăng nhập và mật khẩu.";

            using (var db = new DataBaseProcess())
            {
                TaiKhoanDTO tk = TaiKhoanDAL.LayTheoTenDN(db, tenDN.Trim());

                // Sai tên và sai mật khẩu dùng chung một thông báo, để không lộ tài khoản nào tồn tại
                if (tk == null || !KiemTraMatKhau(matKhau, tk.MatKhauHash)) return "Sai tên đăng nhập hoặc mật khẩu.";
                if (!tk.TrangThai) return "Tài khoản đã bị khóa.";

                AppSession.MaTK = tk.MaTK;
                AppSession.HoTen = tk.HoTen;
                AppSession.VaiTro = tk.VaiTro;
                return null;
            }
        }

        public static void DangXuat()
        {
            AppSession.MaTK = 0;
            AppSession.HoTen = null;
            AppSession.VaiTro = null;
        }

        /// <summary>Người đang đăng nhập tự đổi mật khẩu của mình (cả ThuThu lẫn QuanTri).</summary>
        public static string DoiMatKhau(string matKhauCu, string matKhauMoi)
        {
            Quyen.YeuCauDangNhap();
            string loi = KiemTraMatKhauMoi(matKhauMoi);
            if (loi != null) return loi;

            using (var db = new DataBaseProcess())
            {
                TaiKhoanDTO tk = TaiKhoanDAL.LayTheoMa(db, AppSession.MaTK);
                if (tk == null || !KiemTraMatKhau(matKhauCu ?? "", tk.MatKhauHash)) return "Mật khẩu hiện tại không đúng.";
                TaiKhoanDAL.DatMatKhau(db, tk.MaTK, TaoMatKhauHash(matKhauMoi));
                return null;
            }
        }
    }
}
