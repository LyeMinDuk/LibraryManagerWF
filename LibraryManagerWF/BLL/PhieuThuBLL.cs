using System;
using System.Data;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    public static class PhieuThuBLL
    {
        public static int TaoPhieuThu(DbHelpers db, string loaiThu, decimal soTien, int? maThe, int? maCTM, string ghiChu)
        {
            soTien = Math.Round(soTien, 0, MidpointRounding.AwayFromZero);
            if (soTien <= 0)
                return 0;

            return PhieuThuDAL.Them(db, new PhieuThuDTO
            {
                LoaiThu = loaiThu,
                SoTien = soTien,
                NgayThu = DateTime.Now,
                MaThe = maThe,
                MaCTM = maCTM,
                MaTK = AppSession.MaTK,
                GhiChu = ghiChu
            });
        }

        public static DataTable TimKiem(DateTime tuNgay, DateTime denNgay, string loaiThu)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                return PhieuThuDAL.TimKiem(db, tuNgay, denNgay, loaiThu);
        }

        public static DataTable DoanhThuTheoLoai(DateTime tuNgay, DateTime denNgay)
        {
            Quyen.YeuCauQuanTri();
            using (var db = new DbHelpers())
                return PhieuThuDAL.DoanhThuTheoLoai(db, tuNgay, denNgay);
        }

        public static DataTable DoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            Quyen.YeuCauQuanTri();
            using (var db = new DbHelpers())
                return PhieuThuDAL.DoanhThuTheoNgay(db, tuNgay, denNgay);
        }
    }
}
