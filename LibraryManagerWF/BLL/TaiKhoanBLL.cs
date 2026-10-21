using System.Data;
using System.Text.RegularExpressions;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    /// <summary>
    /// Quản lý tài khoản, chỉ QuanTri (BR10, BR11).
    /// Luật: tên đăng nhập duy nhất, 3 đến 50 ký tự chữ, số hoặc gạch dưới; mật khẩu tối thiểu 6 ký tự;
    /// không tự khóa, hạ quyền hay xóa chính mình (nhờ vậy luôn còn ít nhất một QuanTri đang hoạt động);
    /// tài khoản đã lập phiếu mượn hoặc phiếu thu thì chỉ khóa, không xóa.
    /// </summary>
    public static class TaiKhoanBLL
    {
        public static DataTable LayTatCa()
        {
            Quyen.YeuCauQuanTri();
            using (var db = new DbHelpers())
                return TaiKhoanDAL.LayTatCa(db);
        }

        static string KiemTraTenDN(string tenDN)
        {
            if (string.IsNullOrWhiteSpace(tenDN) || !Regex.IsMatch(tenDN.Trim(), "^[A-Za-z0-9_]{3,50}$"))
                return "Tên đăng nhập gồm 3 đến 50 ký tự chữ, số hoặc gạch dưới.";
            return null;
        }

        static string KiemTraHoTenVaiTro(string hoTen, string vaiTro)
        {
            if (string.IsNullOrWhiteSpace(hoTen)) return "Vui lòng nhập họ tên.";
            if (hoTen.Trim().Length > 100) return "Họ tên tối đa 100 ký tự.";
            if (vaiTro != VaiTro.QuanTri && vaiTro != VaiTro.ThuThu) return "Vai trò phải là QuanTri hoặc ThuThu.";
            return null;
        }

        // Lấy tài khoản cần sửa. Hầu hết thao tác không được nhắm vào chính tài khoản đang đăng nhập
        static string LayMucTieu(DbHelpers db, int maTK, bool choPhepChinhMinh, out TaiKhoanDTO tk)
        {
            tk = TaiKhoanDAL.LayTheoMa(db, maTK);
            if (tk == null) return "Không tìm thấy tài khoản.";
            if (!choPhepChinhMinh && tk.MaTK == AppSession.MaTK)
                return "Không thực hiện được trên chính tài khoản đang đăng nhập.";
            return null;
        }

        public static string Them(string tenDN, string matKhau, string hoTen, string vaiTro)
        {
            Quyen.YeuCauQuanTri();
            string loi = KiemTraTenDN(tenDN) ?? AuthBLL.KiemTraMatKhauMoi(matKhau) ?? KiemTraHoTenVaiTro(hoTen, vaiTro);
            if (loi != null) return loi;

            using (var db = new DbHelpers())
            {
                if (TaiKhoanDAL.TenDNDaCo(db, tenDN.Trim())) return "Tên đăng nhập đã tồn tại.";
                TaiKhoanDAL.Them(db, new TaiKhoanDTO
                {
                    TenDN = tenDN.Trim(),
                    MatKhauHash = AuthBLL.TaoMatKhauHash(matKhau),
                    HoTen = hoTen.Trim(),
                    VaiTro = vaiTro
                });
                return null;
            }
        }

        /// <summary>Sửa họ tên và vai trò (không đổi tên đăng nhập). Không tự đổi vai trò của mình.</summary>
        public static string Sua(int maTK, string hoTen, string vaiTro)
        {
            Quyen.YeuCauQuanTri();
            string loi = KiemTraHoTenVaiTro(hoTen, vaiTro);
            if (loi != null) return loi;

            using (var db = new DbHelpers())
            {
                TaiKhoanDTO tk;
                loi = LayMucTieu(db, maTK, false, out tk);
                if (loi != null) return loi;
                TaiKhoanDAL.CapNhatThongTin(db, maTK, hoTen.Trim(), vaiTro);
                return null;
            }
        }

        /// <summary>Đặt lại mật khẩu cho một tài khoản (quên mật khẩu). Được dùng cả cho chính mình.</summary>
        public static string DatLaiMatKhau(int maTK, string matKhauMoi)
        {
            Quyen.YeuCauQuanTri();
            string loi = AuthBLL.KiemTraMatKhauMoi(matKhauMoi);
            if (loi != null) return loi;

            using (var db = new DbHelpers())
            {
                TaiKhoanDTO tk;
                loi = LayMucTieu(db, maTK, true, out tk);
                if (loi != null) return loi;
                TaiKhoanDAL.DatMatKhau(db, maTK, AuthBLL.TaoMatKhauHash(matKhauMoi));
                return null;
            }
        }

        /// <summary>Khóa (hoatDong = false) hoặc mở khóa (true). Không tự khóa mình.</summary>
        public static string DoiTrangThai(int maTK, bool hoatDong)
        {
            Quyen.YeuCauQuanTri();
            using (var db = new DbHelpers())
            {
                TaiKhoanDTO tk;
                string loi = LayMucTieu(db, maTK, false, out tk);
                if (loi != null) return loi;
                TaiKhoanDAL.DoiTrangThai(db, maTK, hoatDong);
                return null;
            }
        }

        /// <summary>BR10: tài khoản đã lập phiếu thì không xóa, chỉ khóa.</summary>
        public static string Xoa(int maTK)
        {
            Quyen.YeuCauQuanTri();
            using (var db = new DbHelpers())
            {
                TaiKhoanDTO tk;
                string loi = LayMucTieu(db, maTK, false, out tk);
                if (loi != null) return loi;
                if (TaiKhoanDAL.DemGiaoDich(db, maTK) > 0)
                    return "Tài khoản đã lập phiếu nên không xóa được, hãy khóa tài khoản.";
                TaiKhoanDAL.Xoa(db, maTK);
                return null;
            }
        }
    }
}
