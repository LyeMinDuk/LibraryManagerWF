using System.Data;

namespace LibraryManagerWF.DAL
{
    public static class TheLoaiDAL
    {
        public static DataTable LayTatCa(DbHelpers db)
        {
            return db.DocBang(
                "SELECT tl.MaTL, tl.TenTL, COUNT(s.MaSach) AS SoSach " +
                "FROM TheLoai tl LEFT JOIN Sach s ON s.MaTL = tl.MaTL " +
                "GROUP BY tl.MaTL, tl.TenTL ORDER BY tl.TenTL");
        }

        /// <summary>Có thể loại khác trùng tên không? (maBoQua = 0 khi thêm mới)</summary>
        public static bool TrungTen(DbHelpers db, string ten, int maBoQua)
        {
            return (int)db.LayMotGiaTri("SELECT COUNT(*) FROM TheLoai WHERE TenTL = @0 AND MaTL <> @1", ten, maBoQua) > 0;
        }

        public static int DemSach(DbHelpers db, int maTL)
        {
            return (int)db.LayMotGiaTri("SELECT COUNT(*) FROM Sach WHERE MaTL = @0", maTL);
        }

        public static int Them(DbHelpers db, string ten)
        {
            return db.CapNhat("INSERT INTO TheLoai(TenTL) VALUES(@0)", ten);
        }

        public static int Sua(DbHelpers db, int maTL, string ten)
        {
            return db.CapNhat("UPDATE TheLoai SET TenTL = @0 WHERE MaTL = @1", ten, maTL);
        }

        public static int Xoa(DbHelpers db, int maTL)
        {
            return db.CapNhat("DELETE FROM TheLoai WHERE MaTL = @0", maTL);
        }
    }
}
