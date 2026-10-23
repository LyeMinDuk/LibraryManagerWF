using System;
using System.Data;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.DAL
{
    public static class ThongKeDAL
    {
        public static ThongKeDTO LaySoDem(DbHelpers db, DateTime homNay)
        {
            DateTime ngayMai = homNay.Date.AddDays(1);
            DataTable dt = db.DocBang(
                "SELECT " +
                "(SELECT COUNT(*) FROM Sach WHERE TrangThai = 1) AS DauSach, " +
                "(SELECT ISNULL(SUM(SoLuongCon), 0) FROM Sach WHERE TrangThai = 1) AS CuonCon, " +
                "(SELECT ISNULL(SUM(SoLuongTong), 0) FROM Sach WHERE TrangThai = 1) AS CuonTong, " +
                "(SELECT COUNT(*) FROM DocGia WHERE TrangThai = 1) AS DocGia, " +
                "(SELECT COUNT(*) FROM TheThuVien WHERE TrangThai = 1 AND NgayHetHan >= @0) AS TheHieuLuc, " +
                "(SELECT COUNT(*) FROM ChiTietMuon WHERE NgayTra IS NULL) AS DangMuon, " +
                "(SELECT COUNT(*) FROM ChiTietMuon WHERE NgayTra IS NULL AND HanTra < @0) AS QuaHan, " +
                "(SELECT COUNT(*) FROM ChiTietMuon c JOIN PhieuMuon pm ON pm.MaPM = c.MaPM " +
                "   WHERE pm.NgayMuon >= @0 AND pm.NgayMuon < @1) AS MuonNay, " +
                "(SELECT COUNT(*) FROM ChiTietMuon WHERE NgayTra >= @0 AND NgayTra < @1) AS TraNay",
                homNay.Date, ngayMai);

            DataRow r = dt.Rows[0];
            return new ThongKeDTO
            {
                DauSachHoatDong = (int)r["DauSach"],
                CuonConTrenKe = Convert.ToInt32(r["CuonCon"]),
                TongCuon = Convert.ToInt32(r["CuonTong"]),
                DocGiaHoatDong = (int)r["DocGia"],
                TheConHieuLuc = (int)r["TheHieuLuc"],
                DangMuon = (int)r["DangMuon"],
                QuaHan = (int)r["QuaHan"],
                MuonHomNay = (int)r["MuonNay"],
                TraHomNay = (int)r["TraNay"]
            };
        }

        public static decimal TongDoanhThu(DbHelpers db, DateTime tuNgay, DateTime denNgay)
        {
            object v = db.LayMotGiaTri(
                "SELECT SUM(SoTien) FROM PhieuThu WHERE NgayThu >= @0 AND NgayThu < @1",
                tuNgay.Date, denNgay.Date.AddDays(1));
            return v == null ? 0m : Convert.ToDecimal(v);
        }
    }
}
