using System;
using System.Data;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    /// <summary>
    /// Phiếu thu = sổ ghi mọi khoản tiền thu được: Phí thẻ, Phạt trễ, Đền bù. Mỗi khoản một phiếu (BR08).
    /// Doanh thu = tổng phiếu thu. Loại thu hợp lệ, số tiền lớn hơn 0 và "phí thẻ gắn thẻ, phạt/đền gắn cuốn mượn"
    /// đã có CHECK trong CSDL nên ở đây không kiểm tra lại.
    /// </summary>
    public static class PhieuThuBLL
    {
        /// <summary>
        /// Lập một phiếu thu trong transaction của người gọi. Khoản 0đ thì không lập và trả về 0.
        /// Phí thẻ: truyền maThe, maCTM = null. Phạt trễ / Đền bù: truyền maCTM, maThe = null.
        /// </summary>
        public static int TaoPhieuThu(DbHelpers db, string loaiThu, decimal soTien, int? maThe, int? maCTM, string ghiChu)
        {
            soTien = Math.Round(soTien, 0, MidpointRounding.AwayFromZero);   // làm tròn nửa lên, khớp ROUND của SQL
            if (soTien <= 0) return 0;

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

        // ===== Báo cáo doanh thu (chỉ QuanTri) =====

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
