using System.Data;
using LibraryManagerWF.DAL;

namespace LibraryManagerWF.BLL
{
    public static class TheLoaiBLL
    {
        public static DataTable LayTatCa()
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                return TheLoaiDAL.LayTatCa(db);
        }

        static string KiemTraTen(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten))
                return "Vui lòng nhập tên thể loại.";
            if (ten.Trim().Length > 100)
                return "Tên thể loại tối đa 100 ký tự.";
            return null;
        }

        public static string Them(string ten)
        {
            Quyen.YeuCauDangNhap();
            string loi = KiemTraTen(ten);
            if (loi != null)
                return loi;

            using (var db = new DbHelpers())
            {
                if (TheLoaiDAL.TrungTen(db, ten.Trim(), 0))
                    return "Thể loại này đã tồn tại.";
                TheLoaiDAL.Them(db, ten.Trim());
                return null;
            }
        }

        public static string Sua(int maTL, string ten)
        {
            Quyen.YeuCauDangNhap();
            string loi = KiemTraTen(ten);
            if (loi != null)
                return loi;

            using (var db = new DbHelpers())
            {
                if (TheLoaiDAL.TrungTen(db, ten.Trim(), maTL))
                    return "Thể loại này đã tồn tại.";
                if (TheLoaiDAL.Sua(db, maTL, ten.Trim()) == 0)
                    return "Thể loại không còn tồn tại.";
                return null;
            }
        }

        public static string Xoa(int maTL)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
            {
                if (TheLoaiDAL.DemSach(db, maTL) > 0)
                    return "Không xóa được: thể loại còn sách.";
                TheLoaiDAL.Xoa(db, maTL);
                return null;
            }
        }
    }
}
