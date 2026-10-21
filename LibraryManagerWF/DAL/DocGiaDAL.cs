using System;
using System.Data;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.DAL
{
    public static class DocGiaDAL
    {
        public static DocGiaDTO LayTheoMa(DataBaseProcess db, int maDG)
        {
            DataTable dt = db.DocBang(
                "SELECT MaDG, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, Email, TrangThai FROM DocGia WHERE MaDG = @0", maDG);
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new DocGiaDTO
            {
                MaDG = (int)r["MaDG"],
                HoTen = r["HoTen"].ToString(),
                NgaySinh = (DateTime)r["NgaySinh"],
                GioiTinh = r["GioiTinh"].ToString(),
                DiaChi = r["DiaChi"] == DBNull.Value ? null : r["DiaChi"].ToString(),
                SDT = r["SDT"].ToString(),
                Email = r["Email"] == DBNull.Value ? null : r["Email"].ToString(),
                TrangThai = (bool)r["TrangThai"]
            };
        }

        /// <summary>Tìm theo họ tên hoặc số điện thoại, kèm thông tin thẻ (MaThe, NgayHetHan, TrangThaiThe nếu đã có thẻ).</summary>
        public static DataTable TimKiem(DataBaseProcess db, string tuKhoa)
        {
            return db.DocBang(
                "SELECT dg.MaDG, dg.HoTen, dg.NgaySinh, dg.GioiTinh, dg.DiaChi, dg.SDT, dg.Email, dg.TrangThai, " +
                "t.MaThe, t.NgayHetHan, t.TrangThai AS TrangThaiThe " +
                "FROM DocGia dg LEFT JOIN TheThuVien t ON t.MaDG = dg.MaDG " +
                "WHERE dg.HoTen LIKE @0 OR dg.SDT LIKE @0 ORDER BY dg.MaDG DESC",
                "%" + (tuKhoa ?? "").Trim() + "%");
        }

        public static int Them(DataBaseProcess db, DocGiaDTO d)
        {
            return db.CapNhat(
                "INSERT INTO DocGia(HoTen, NgaySinh, GioiTinh, DiaChi, SDT, Email, TrangThai) VALUES(@0, @1, @2, @3, @4, @5, 1)",
                d.HoTen, d.NgaySinh, d.GioiTinh, d.DiaChi, d.SDT, d.Email);
        }

        public static int Sua(DataBaseProcess db, DocGiaDTO d)
        {
            return db.CapNhat(
                "UPDATE DocGia SET HoTen = @0, NgaySinh = @1, GioiTinh = @2, DiaChi = @3, SDT = @4, Email = @5 WHERE MaDG = @6",
                d.HoTen, d.NgaySinh, d.GioiTinh, d.DiaChi, d.SDT, d.Email, d.MaDG);
        }

        public static int DoiTrangThai(DataBaseProcess db, int maDG, bool hoatDong)
        {
            return db.CapNhat("UPDATE DocGia SET TrangThai = @0 WHERE MaDG = @1", hoatDong, maDG);
        }

        public static int DemThe(DataBaseProcess db, int maDG)
        {
            return (int)db.LayMotGiaTri("SELECT COUNT(*) FROM TheThuVien WHERE MaDG = @0", maDG);
        }

        public static int Xoa(DataBaseProcess db, int maDG)
        {
            return db.CapNhat("DELETE FROM DocGia WHERE MaDG = @0", maDG);
        }
    }
}
