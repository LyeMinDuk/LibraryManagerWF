using System;
using System.Data;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.DAL
{
    public static class PhieuThuDAL
    {
        public static int Them(DbHelpers db, PhieuThuDTO p)
        {
            return db.ThemLayMa(
                "INSERT INTO PhieuThu(LoaiThu, SoTien, NgayThu, MaThe, MaCTM, MaTK, GhiChu) VALUES(@0, @1, @2, @3, @4, @5, @6)",
                p.LoaiThu, p.SoTien, p.NgayThu, p.MaThe, p.MaCTM, p.MaTK, p.GhiChu);
        }

        public static DataTable TimKiem(DbHelpers db, DateTime tuNgay, DateTime denNgay, string loaiThu)
        {
            return db.DocBang(
                "SELECT p.MaPT, p.LoaiThu, p.SoTien, p.NgayThu, p.MaThe, p.MaCTM, p.GhiChu, tk.HoTen AS NguoiThu " +
                "FROM PhieuThu p JOIN TaiKhoan tk ON tk.MaTK = p.MaTK " +
                "WHERE p.NgayThu >= @0 AND p.NgayThu < @1 AND (@2 = N'' OR p.LoaiThu = @2) " +
                "ORDER BY p.NgayThu DESC",
                tuNgay.Date, denNgay.Date.AddDays(1), loaiThu ?? "");
        }

        public static DataTable DoanhThuTheoLoai(DbHelpers db, DateTime tuNgay, DateTime denNgay)
        {
            return db.DocBang(
                "SELECT LoaiThu, COUNT(*) AS SoPhieu, SUM(SoTien) AS TongTien FROM PhieuThu " +
                "WHERE NgayThu >= @0 AND NgayThu < @1 GROUP BY LoaiThu",
                tuNgay.Date, denNgay.Date.AddDays(1));
        }

        public static DataTable DoanhThuTheoNgay(DbHelpers db, DateTime tuNgay, DateTime denNgay)
        {
            return db.DocBang(
                "SELECT CAST(NgayThu AS DATE) AS Ngay, COUNT(*) AS SoPhieu, SUM(SoTien) AS TongTien FROM PhieuThu " +
                "WHERE NgayThu >= @0 AND NgayThu < @1 GROUP BY CAST(NgayThu AS DATE) ORDER BY Ngay",
                tuNgay.Date, denNgay.Date.AddDays(1));
        }
    }
}
