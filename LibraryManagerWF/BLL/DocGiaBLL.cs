using System;
using System.Data;
using System.Text.RegularExpressions;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    /// <summary>Hồ sơ độc giả (người mượn). Độc giả không đăng nhập. BR10, BR12.</summary>
    public static class DocGiaBLL
    {
        /// <summary>Kiểm tra nhập liệu (BR12). Trả về lỗi, hoặc null nếu hợp lệ.</summary>
        public static string KiemTra(DocGiaDTO d)
        {
            if (string.IsNullOrWhiteSpace(d.HoTen)) return "Vui lòng nhập họ tên.";
            if (d.NgaySinh.Date >= DateTime.Today) return "Ngày sinh phải nhỏ hơn ngày hôm nay.";
            if (d.GioiTinh != "Nam" && d.GioiTinh != "Nữ" && d.GioiTinh != "Khác") return "Giới tính phải là Nam, Nữ hoặc Khác.";
            if (d.SDT == null || !Regex.IsMatch(d.SDT.Trim(), "^[0-9]{10}$")) return "Số điện thoại phải gồm đúng 10 chữ số.";
            if (!string.IsNullOrWhiteSpace(d.Email) && !Regex.IsMatch(d.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Email không hợp lệ.";
            return null;
        }

        static void ChuanHoa(DocGiaDTO d)
        {
            d.HoTen = d.HoTen.Trim();
            d.NgaySinh = d.NgaySinh.Date;
            d.SDT = d.SDT.Trim();
            d.DiaChi = string.IsNullOrWhiteSpace(d.DiaChi) ? null : d.DiaChi.Trim();
            d.Email = string.IsNullOrWhiteSpace(d.Email) ? null : d.Email.Trim();
        }

        public static DataTable TimKiem(string tuKhoa)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                return DocGiaDAL.TimKiem(db, tuKhoa);
        }

        public static string Them(DocGiaDTO d)
        {
            Quyen.YeuCauDangNhap();
            string loi = KiemTra(d);
            if (loi != null) return loi;
            ChuanHoa(d);

            using (var db = new DbHelpers())
            {
                DocGiaDAL.Them(db, d);
                return null;
            }
        }

        public static string Sua(DocGiaDTO d)
        {
            Quyen.YeuCauDangNhap();
            string loi = KiemTra(d);
            if (loi != null) return loi;
            ChuanHoa(d);

            using (var db = new DbHelpers())
            {
                if (DocGiaDAL.Sua(db, d) == 0) return "Độc giả không còn tồn tại.";
                return null;
            }
        }

        /// <summary>Khóa (hoatDong = false) hoặc mở khóa (true) bằng tay. Khóa độc giả không tự khóa thẻ.</summary>
        public static void DoiTrangThai(int maDG, bool hoatDong)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                DocGiaDAL.DoiTrangThai(db, maDG, hoatDong);
        }

        /// <summary>BR10: độc giả đã có thẻ (đã phát sinh giao dịch) thì không xóa, chỉ khóa.</summary>
        public static string Xoa(int maDG)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
            {
                if (DocGiaDAL.DemThe(db, maDG) > 0) return "Độc giả đã có thẻ nên không xóa được, hãy khóa độc giả.";
                DocGiaDAL.Xoa(db, maDG);
                return null;
            }
        }
    }
}
