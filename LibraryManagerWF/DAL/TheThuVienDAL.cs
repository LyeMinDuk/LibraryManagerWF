using System;
using System.Data;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.DAL
{
    public static class TheThuVienDAL
    {
        static TheThuVienDTO LayMot(DbHelpers db, string dieuKien, int gt)
        {
            DataTable dt = db.DocBang(
                "SELECT MaThe, MaDG, NgayCap, NgayHetHan, TrangThai FROM TheThuVien WHERE " + dieuKien, gt);
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new TheThuVienDTO
            {
                MaThe = (int)r["MaThe"],
                MaDG = (int)r["MaDG"],
                NgayCap = (DateTime)r["NgayCap"],
                NgayHetHan = (DateTime)r["NgayHetHan"],
                TrangThai = (bool)r["TrangThai"]
            };
        }

        public static TheThuVienDTO LayTheoMa(DbHelpers db, int maThe) { return LayMot(db, "MaThe = @0", maThe); }

        /// <summary>Mỗi độc giả tối đa một thẻ (UNIQUE MaDG), nên trả về một thẻ hoặc null.</summary>
        public static TheThuVienDTO LayTheoDocGia(DbHelpers db, int maDG) { return LayMot(db, "MaDG = @0", maDG); }

        public static int Them(DbHelpers db, TheThuVienDTO t)
        {
            return db.ThemLayMa(
                "INSERT INTO TheThuVien(MaDG, NgayCap, NgayHetHan, TrangThai) VALUES(@0, @1, @2, 1)",
                t.MaDG, t.NgayCap, t.NgayHetHan);
        }

        /// <summary>Chỉ đổi khi NgayHetHan vẫn là giá trị đã đọc (chặn bấm gia hạn hai lần). 0 dòng = thẻ vừa bị đổi.</summary>
        public static int GiaHan(DbHelpers db, int maThe, DateTime hetHanCu, DateTime hetHanMoi)
        {
            return db.CapNhat("UPDATE TheThuVien SET NgayHetHan = @0 WHERE MaThe = @1 AND NgayHetHan = @2", hetHanMoi, maThe, hetHanCu);
        }

        public static int DoiTrangThai(DbHelpers db, int maThe, bool hoatDong)
        {
            return db.CapNhat("UPDATE TheThuVien SET TrangThai = @0 WHERE MaThe = @1", hoatDong, maThe);
        }

        public static int DemGiaoDich(DbHelpers db, int maThe)
        {
            return (int)db.LayMotGiaTri(
                "SELECT (SELECT COUNT(*) FROM PhieuMuon WHERE MaThe = @0) + (SELECT COUNT(*) FROM PhieuThu WHERE MaThe = @0)", maThe);
        }

        public static int Xoa(DbHelpers db, int maThe)
        {
            return db.CapNhat("DELETE FROM TheThuVien WHERE MaThe = @0", maThe);
        }
    }
}
