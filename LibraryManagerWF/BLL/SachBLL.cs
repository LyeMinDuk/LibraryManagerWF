using System;
using System.Data;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    public static class SachBLL
    {
        public static string KiemTra(SachDTO s)
        {
            if (string.IsNullOrWhiteSpace(s.TenSach))
                return "Vui lòng nhập tên sách.";
            if (string.IsNullOrWhiteSpace(s.TacGia))
                return "Vui lòng nhập tác giả.";
            if (s.MaTL <= 0)
                return "Vui lòng chọn thể loại.";
            if (s.NamXB.HasValue && (s.NamXB.Value < 1000 || s.NamXB.Value > DateTime.Today.Year))
                return "Năm xuất bản phải từ 1000 đến " + DateTime.Today.Year + ".";
            if (s.GiaBia <= 0)
                return "Giá bìa phải lớn hơn 0.";
            if (s.SoLuongTong <= 0)
                return "Số lượng tổng phải lớn hơn 0.";
            return null;
        }

        static void ChuanHoa(SachDTO s)
        {
            s.TenSach = s.TenSach.Trim();
            s.TacGia = s.TacGia.Trim();
            s.NXB = string.IsNullOrWhiteSpace(s.NXB) ? null : s.NXB.Trim();
        }

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
            if (loi != null)
                return loi;
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
            if (loi != null)
                return loi;
            ChuanHoa(s);

            using (var db = new DbHelpers())
            {
                SachDTO cu = SachDAL.LayTheoMa(db, s.MaSach);
                if (cu == null)
                    return "Sách không còn tồn tại.";

                int dangMuon = cu.SoLuongTong - cu.SoLuongCon;
                if (s.SoLuongTong < dangMuon)
                    return "Số lượng tổng không được nhỏ hơn số cuốn đang được mượn (" + dangMuon + ").";

                SachDAL.Sua(db, s);
                return null;
            }
        }

        public static void DoiTrangThai(int maSach, bool hoatDong)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                SachDAL.DoiTrangThai(db, maSach, hoatDong);
        }

        public static string Xoa(int maSach)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
            {
                if (SachDAL.DemLuotMuon(db, maSach) > 0)
                    return "Sách đã có giao dịch mượn nên không xóa được, hãy khóa sách.";
                SachDAL.Xoa(db, maSach);
                return null;
            }
        }
    }
}
