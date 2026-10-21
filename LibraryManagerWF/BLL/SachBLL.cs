using System;
using System.Data;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    /// <summary>Danh mục sách. BR05 (khóa sách), BR10 (đã mượn thì chỉ khóa, không xóa), BR12 (giá, số lượng lớn hơn 0).</summary>
    public static class SachBLL
    {
        /// <summary>Kiểm tra nhập liệu (BR12). Trả về lỗi, hoặc null nếu hợp lệ.</summary>
        public static string KiemTra(SachDTO s)
        {
            if (string.IsNullOrWhiteSpace(s.TenSach)) return "Vui lòng nhập tên sách.";
            if (string.IsNullOrWhiteSpace(s.TacGia)) return "Vui lòng nhập tác giả.";
            if (s.MaTL <= 0) return "Vui lòng chọn thể loại.";
            if (s.NamXB.HasValue && (s.NamXB.Value < 1000 || s.NamXB.Value > DateTime.Today.Year))
                return "Năm xuất bản phải từ 1000 đến " + DateTime.Today.Year + ".";
            if (s.GiaBia <= 0) return "Giá bìa phải lớn hơn 0.";
            if (s.SoLuongTong <= 0) return "Số lượng tổng phải lớn hơn 0.";
            return null;
        }

        // Cắt khoảng trắng, ô trống thành null, để DAL ghi thẳng
        static void ChuanHoa(SachDTO s)
        {
            s.TenSach = s.TenSach.Trim();
            s.TacGia = s.TacGia.Trim();
            s.NXB = string.IsNullOrWhiteSpace(s.NXB) ? null : s.NXB.Trim();
        }

        /// <summary>maTL = 0: mọi thể loại. trangThai = -1: mọi trạng thái, 1: hoạt động, 0: khóa.</summary>
        public static DataTable TimKiem(string tuKhoa, int maTL, int trangThai)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                return SachDAL.TimKiem(db, tuKhoa, maTL, trangThai);
        }

        public static string Them(SachDTO s)
        {
            Quyen.YeuCauDangNhap();
            string loi = KiemTra(s);
            if (loi != null) return loi;
            ChuanHoa(s);

            using (var db = new DbHelpers())
            {
                SachDAL.Them(db, s);
                return null;
            }
        }

        public static string Sua(SachDTO s)
        {
            Quyen.YeuCauDangNhap();
            string loi = KiemTra(s);
            if (loi != null) return loi;
            ChuanHoa(s);

            using (var db = new DbHelpers())
            {
                SachDTO cu = SachDAL.LayTheoMa(db, s.MaSach);
                if (cu == null) return "Sách không còn tồn tại.";

                // Số cuốn đang được mượn = tổng - còn. Tổng mới không được nhỏ hơn số đó
                int dangMuon = cu.SoLuongTong - cu.SoLuongCon;
                if (s.SoLuongTong < dangMuon) return "Số lượng tổng không được nhỏ hơn số cuốn đang được mượn (" + dangMuon + ").";

                SachDAL.Sua(db, s);
                return null;
            }
        }

        /// <summary>BR05: hoatDong = false là khóa sách (không cho mượn), true là mở khóa.</summary>
        public static void DoiTrangThai(int maSach, bool hoatDong)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                SachDAL.DoiTrangThai(db, maSach, hoatDong);
        }

        /// <summary>BR10: sách đã có giao dịch mượn thì không xóa, chỉ khóa.</summary>
        public static string Xoa(int maSach)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
            {
                if (SachDAL.DemLuotMuon(db, maSach) > 0) return "Sách đã có giao dịch mượn nên không xóa được, hãy khóa sách.";
                SachDAL.Xoa(db, maSach);
                return null;
            }
        }
    }
}
