using System;

namespace LibraryManagerWF.BLL
{
    public static class TinhPhatBLL
    {
        public static int SoNgayTre(DateTime hanTra, DateTime ngayTra)
        {
            return Math.Max(0, (ngayTra.Date - hanTra.Date).Days);
        }

        public static decimal TienPhatTre(decimal giaBia, int soNgayTre, int phatMoiNgay)
        {
            return Math.Min(soNgayTre * phatMoiNgay, giaBia);
        }

        public static decimal TienDen(decimal giaBia, int phanTram)
        {
            return Math.Round(giaBia * phanTram / 100m, 0, MidpointRounding.AwayFromZero);
        }

        public static void Tinh(DAL.DbHelpers db, decimal giaBia, DateTime hanTra, string tinhTrang,
            out int soNgayTre, out decimal tienPhat, out decimal tienDen)
        {
            soNgayTre = 0;
            tienPhat = 0;
            tienDen = 0;
            if (tinhTrang == DTO.TinhTrangMuon.Mat)
            {
                tienDen = TienDen(giaBia, CauHinhBLL.Lay(db, "DEN_MAT_PHAN_TRAM"));
                return;
            }
            soNgayTre = SoNgayTre(hanTra, DateTime.Today);
            tienPhat = TienPhatTre(giaBia, soNgayTre, CauHinhBLL.Lay(db, "PHAT_TRE_MOI_NGAY"));
            if (tinhTrang == DTO.TinhTrangMuon.Hong)
                tienDen = TienDen(giaBia, CauHinhBLL.Lay(db, "DEN_HONG_PHAN_TRAM"));
        }
    }
}
