using System;
using System.Security.Cryptography;
using System.Text;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    public static class AuthBLL
    {
        static string Bam(string matKhau, string salt)
        {
            using (var sha = SHA256.Create())
                return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(salt + matKhau))).Replace("-", "");
        }

        public static string TaoMatKhauHash(string matKhau)
        {
            string salt = Guid.NewGuid().ToString("N");
            return salt + "$" + Bam(matKhau, salt);
        }

        public static bool KiemTraMatKhau(string matKhau, string daLuu)
        {
            if (matKhau == null || daLuu == null)
                return false;
            int i = daLuu.IndexOf('$');
            if (i <= 0)
                return false;
            return Bam(matKhau, daLuu.Substring(0, i)) == daLuu.Substring(i + 1).ToUpper();
        }

        public static string KiemTraMatKhauMoi(string matKhau)
        {
            if (string.IsNullOrEmpty(matKhau) || matKhau.Length < 6)
                return "Mật khẩu phải có ít nhất 6 ký tự.";
            if (matKhau.Length > 50)
                return "Mật khẩu tối đa 50 ký tự.";
            return null;
        }

        public static string DangNhap(string tenDN, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrEmpty(matKhau))
                return "Vui lòng nhập tên đăng nhập và mật khẩu.";

            using (var db = new DbHelpers())
            {
                TaiKhoanDTO tk = TaiKhoanDAL.LayTheoTenDN(db, tenDN.Trim());

                if (tk == null || !KiemTraMatKhau(matKhau, tk.MatKhauHash))
                    return "Sai tên đăng nhập hoặc mật khẩu.";
                if (!tk.TrangThai)
                    return "Tài khoản đã bị khóa.";

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

        public static string DoiMatKhau(string matKhauCu, string matKhauMoi)
        {
            Quyen.YeuCauDangNhap();
            string loi = KiemTraMatKhauMoi(matKhauMoi);
            if (loi != null)
                return loi;

            using (var db = new DbHelpers())
            {
                TaiKhoanDTO tk = TaiKhoanDAL.LayTheoMa(db, AppSession.MaTK);
                if (tk == null || !KiemTraMatKhau(matKhauCu ?? "", tk.MatKhauHash))
                    return "Mật khẩu hiện tại không đúng.";
                TaiKhoanDAL.DatMatKhau(db, tk.MaTK, TaoMatKhauHash(matKhauMoi));
                return null;
            }
        }
    }
}
