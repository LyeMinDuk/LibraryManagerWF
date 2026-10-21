using System;
using System.Data;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.DAL
{
    public static class ChiTietMuonDAL
    {
        public static ChiTietMuonDTO LayTheoMa(DbHelpers db, int maCTM)
        {
            DataTable dt = db.DocBang(
                "SELECT MaCTM, MaPM, MaSach, HanTra, SoLanGiaHan, NgayTra, TinhTrang FROM ChiTietMuon WHERE MaCTM = @0", maCTM);
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new ChiTietMuonDTO
            {
                MaCTM = (int)r["MaCTM"],
                MaPM = (int)r["MaPM"],
                MaSach = (int)r["MaSach"],
                HanTra = (DateTime)r["HanTra"],
                SoLanGiaHan = (int)r["SoLanGiaHan"],
                NgayTra = r["NgayTra"] == DBNull.Value ? (DateTime?)null : (DateTime)r["NgayTra"],
                TinhTrang = r["TinhTrang"].ToString()
            };
        }

        public static int Them(DbHelpers db, ChiTietMuonDTO c)
        {
            return db.ThemLayMa("INSERT INTO ChiTietMuon(MaPM, MaSach, HanTra) VALUES(@0, @1, @2)", c.MaPM, c.MaSach, c.HanTra);
        }

        /// <summary>Số cuốn thẻ đang mượn (chưa trả).</summary>
        public static int DemDangMuon(DbHelpers db, int maThe)
        {
            return (int)db.LayMotGiaTri(
                "SELECT COUNT(*) FROM ChiTietMuon c JOIN PhieuMuon pm ON pm.MaPM = c.MaPM " +
                "WHERE pm.MaThe = @0 AND c.NgayTra IS NULL", maThe);
        }

        /// <summary>Số cuốn thẻ đang mượn và đã quá hạn tính đến homNay.</summary>
        public static int DemQuaHan(DbHelpers db, int maThe, DateTime homNay)
        {
            return (int)db.LayMotGiaTri(
                "SELECT COUNT(*) FROM ChiTietMuon c JOIN PhieuMuon pm ON pm.MaPM = c.MaPM " +
                "WHERE pm.MaThe = @0 AND c.NgayTra IS NULL AND c.HanTra < @1", maThe, homNay);
        }

        /// <summary>Chỉ gia hạn cuốn chưa trả. 0 dòng = cuốn vừa được trả.</summary>
        public static int GiaHan(DbHelpers db, int maCTM, DateTime hanMoi)
        {
            return db.CapNhat(
                "UPDATE ChiTietMuon SET HanTra = @0, SoLanGiaHan = SoLanGiaHan + 1 WHERE MaCTM = @1 AND NgayTra IS NULL", hanMoi, maCTM);
        }

        /// <summary>Đóng cuốn mượn, chỉ khi còn "Chưa trả" (chặn bấm trả hai lần). 0 dòng = cuốn vừa được trả.</summary>
        public static int Dong(DbHelpers db, int maCTM, DateTime ngayTra, string tinhTrang)
        {
            return db.CapNhat(
                "UPDATE ChiTietMuon SET NgayTra = @0, TinhTrang = @1 WHERE MaCTM = @2 AND NgayTra IS NULL", ngayTra, tinhTrang, maCTM);
        }

        /// <summary>
        /// Danh sách cuốn mượn kèm độc giả, sách, số ngày trễ.
        /// tuKhoa: họ tên, SĐT hoặc tên sách (rỗng = tất cả). maThe = 0: mọi thẻ. loc: 0 tất cả, 1 đang mượn, 2 quá hạn, 3 đã trả.
        /// </summary>
        public static DataTable DanhSach(DbHelpers db, DateTime homNay, string tuKhoa, int maThe, int loc)
        {
            return db.DocBang(
                "SELECT c.MaCTM, pm.MaThe, dg.HoTen, dg.SDT, s.TenSach, s.GiaBia, pm.NgayMuon, c.HanTra, " +
                "c.SoLanGiaHan, c.NgayTra, c.TinhTrang, " +
                "CASE WHEN c.NgayTra IS NULL AND c.HanTra < @0 THEN DATEDIFF(DAY, c.HanTra, @0) ELSE 0 END AS SoNgayTre " +
                "FROM ChiTietMuon c " +
                "JOIN PhieuMuon pm ON pm.MaPM = c.MaPM " +
                "JOIN TheThuVien t ON t.MaThe = pm.MaThe " +
                "JOIN DocGia dg ON dg.MaDG = t.MaDG " +
                "JOIN Sach s ON s.MaSach = c.MaSach " +
                "WHERE (dg.HoTen LIKE @1 OR dg.SDT LIKE @1 OR s.TenSach LIKE @1) " +
                "AND (@2 = 0 OR pm.MaThe = @2) " +
                "AND (@3 = 0 " +
                "     OR (@3 = 1 AND c.NgayTra IS NULL) " +
                "     OR (@3 = 2 AND c.NgayTra IS NULL AND c.HanTra < @0) " +
                "     OR (@3 = 3 AND c.NgayTra IS NOT NULL)) " +
                "ORDER BY CASE WHEN c.NgayTra IS NULL THEN 0 ELSE 1 END, c.HanTra",
                homNay, "%" + (tuKhoa ?? "").Trim() + "%", maThe, loc);
        }
    }
}
