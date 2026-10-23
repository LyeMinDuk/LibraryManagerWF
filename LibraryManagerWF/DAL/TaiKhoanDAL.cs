using System.Data;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.DAL
{
    public static class TaiKhoanDAL
    {
        const string Cot = "MaTK, TenDN, MatKhauHash, HoTen, VaiTro, TrangThai";

        static TaiKhoanDTO TuDong(DataRow r)
        {
            return new TaiKhoanDTO
            {
                MaTK = (int)r["MaTK"],
                TenDN = r["TenDN"].ToString(),
                MatKhauHash = r["MatKhauHash"].ToString(),
                HoTen = r["HoTen"].ToString(),
                VaiTro = r["VaiTro"].ToString(),
                TrangThai = (bool)r["TrangThai"]
            };
        }

        public static TaiKhoanDTO LayTheoTenDN(DbHelpers db, string tenDN)
        {
            DataTable dt = db.DocBang("SELECT " + Cot + " FROM TaiKhoan WHERE TenDN = @0", tenDN);
            return dt.Rows.Count == 0 ? null : TuDong(dt.Rows[0]);
        }

        public static TaiKhoanDTO LayTheoMa(DbHelpers db, int maTK)
        {
            DataTable dt = db.DocBang("SELECT " + Cot + " FROM TaiKhoan WHERE MaTK = @0", maTK);
            return dt.Rows.Count == 0 ? null : TuDong(dt.Rows[0]);
        }

        public static DataTable LayTatCa(DbHelpers db)
        {
            return db.DocBang("SELECT MaTK, TenDN, HoTen, VaiTro, TrangThai FROM TaiKhoan ORDER BY MaTK");
        }

        public static bool TenDNDaCo(DbHelpers db, string tenDN)
        {
            return (int)db.LayMotGiaTri("SELECT COUNT(*) FROM TaiKhoan WHERE TenDN = @0", tenDN) > 0;
        }

        public static int Them(DbHelpers db, TaiKhoanDTO tk)
        {
            return db.ThemLayMa(
                "INSERT INTO TaiKhoan(TenDN, MatKhauHash, HoTen, VaiTro, TrangThai) VALUES(@0, @1, @2, @3, 1)",
                tk.TenDN, tk.MatKhauHash, tk.HoTen, tk.VaiTro);
        }

        public static int CapNhatThongTin(DbHelpers db, int maTK, string hoTen, string vaiTro)
        {
            return db.CapNhat("UPDATE TaiKhoan SET HoTen = @0, VaiTro = @1 WHERE MaTK = @2", hoTen, vaiTro, maTK);
        }

        public static int DatMatKhau(DbHelpers db, int maTK, string matKhauHash)
        {
            return db.CapNhat("UPDATE TaiKhoan SET MatKhauHash = @0 WHERE MaTK = @1", matKhauHash, maTK);
        }

        public static int DoiTrangThai(DbHelpers db, int maTK, bool hoatDong)
        {
            return db.CapNhat("UPDATE TaiKhoan SET TrangThai = @0 WHERE MaTK = @1", hoatDong, maTK);
        }

        public static int DemGiaoDich(DbHelpers db, int maTK)
        {
            return (int)db.LayMotGiaTri(
                "SELECT (SELECT COUNT(*) FROM PhieuMuon WHERE MaTK = @0) + (SELECT COUNT(*) FROM PhieuThu WHERE MaTK = @0)", maTK);
        }

        public static int Xoa(DbHelpers db, int maTK)
        {
            return db.CapNhat("DELETE FROM TaiKhoan WHERE MaTK = @0", maTK);
        }
    }
}
