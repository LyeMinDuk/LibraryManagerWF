using System;

namespace LibraryManagerWF.BLL
{
    /// <summary>Công thức tính tiền (BR06, BR07). Ba hàm đầu là hàm thuần, không cần CSDL nên dễ kiểm tra.</summary>
    public static class TinhPhatBLL
    {
        /// <summary>Số ngày trả trễ, tính theo ngày lịch. Trả đúng ngày hạn thì là 0.</summary>
        public static int SoNgayTre(DateTime hanTra, DateTime ngayTra)
        {
            return Math.Max(0, (ngayTra.Date - hanTra.Date).Days);
        }

        /// <summary>BR06: phạt trễ = số ngày x đơn giá mỗi ngày, nhưng không vượt giá bìa.</summary>
        public static decimal TienPhatTre(decimal giaBia, int soNgayTre, int phatMoiNgay)
        {
            return Math.Min(soNgayTre * phatMoiNgay, giaBia);
        }

        /// <summary>BR07: tiền đền = giá bìa x phần trăm, làm tròn nửa lên (khớp ROUND của SQL).</summary>
        public static decimal TienDen(decimal giaBia, int phanTram)
        {
            return Math.Round(giaBia * phanTram / 100m, 0, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Ghép ba công thức theo tình trạng. Mất: chỉ đền (không phạt trễ). Hỏng: phạt trễ cộng đền.
        /// Bình thường: chỉ phạt trễ. Đơn giá lấy từ CauHinh.
        /// </summary>
        public static void Tinh(DAL.DataBaseProcess db, decimal giaBia, DateTime hanTra, string tinhTrang,
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
            if (tinhTrang == DTO.TinhTrangMuon.Hong) tienDen = TienDen(giaBia, CauHinhBLL.Lay(db, "DEN_HONG_PHAN_TRAM"));
        }
    }
}
