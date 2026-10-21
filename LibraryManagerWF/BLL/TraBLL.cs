using System;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    /// <summary>
    /// Trả sách, tính phạt, đền bù, lập phiếu thu. BR06, BR07, BR13.
    /// Trả ghi nhiều bảng nên chạy trong MỘT transaction như MuonBLL.
    /// </summary>
    public static class TraBLL
    {
        static string KiemTraTinhTrang(string tinhTrang)
        {
            if (tinhTrang != TinhTrangMuon.BinhThuong && tinhTrang != TinhTrangMuon.Hong && tinhTrang != TinhTrangMuon.Mat)
                return "Tình trạng khi trả phải là Bình thường, Hỏng hoặc Mất.";
            return null;
        }

        /// <summary>Xem trước số tiền phạt trễ và đền nếu trả hôm nay (chưa ghi gì). Trả về lỗi, hoặc null.</summary>
        public static string XemTruoc(int maCTM, string tinhTrang, out decimal tienPhat, out decimal tienDen)
        {
            tienPhat = 0;
            tienDen = 0;
            Quyen.YeuCauDangNhap();
            string loi = KiemTraTinhTrang(tinhTrang);
            if (loi != null) return loi;

            using (var db = new DataBaseProcess())
            {
                ChiTietMuonDTO ct = ChiTietMuonDAL.LayTheoMa(db, maCTM);
                if (ct == null) return "Không tìm thấy cuốn mượn.";
                if (ct.NgayTra.HasValue) return "Cuốn này đã được trả rồi.";

                int soNgayTre;
                TinhPhatBLL.Tinh(db, SachDAL.LayTheoMa(db, ct.MaSach).GiaBia, ct.HanTra, tinhTrang, out soNgayTre, out tienPhat, out tienDen);
                return null;
            }
        }

        /// <summary>
        /// Trả (hoặc ghi nhận mất) một cuốn. Ngày trả luôn là hôm nay.
        /// Có tiền phải thu mà daThuTien = false thì từ chối, cuốn vẫn "Chưa trả" (BR13: thu ngay, không công nợ).
        /// tienPhat, tienDen trả về để hiển thị.
        /// </summary>
        public static string Tra(int maCTM, string tinhTrang, bool daThuTien, out decimal tienPhat, out decimal tienDen)
        {
            tienPhat = 0;
            tienDen = 0;
            Quyen.YeuCauDangNhap();
            string loi = KiemTraTinhTrang(tinhTrang);
            if (loi != null) return loi;

            using (var db = new DataBaseProcess())
            {
                db.BatDauGiaoDich();

                // Bước 1: đọc, kiểm tra, tính tiền
                ChiTietMuonDTO ct = ChiTietMuonDAL.LayTheoMa(db, maCTM);
                if (ct == null) return "Không tìm thấy cuốn mượn.";
                if (ct.NgayTra.HasValue) return "Cuốn này đã được trả rồi.";

                int soNgayTre;
                TinhPhatBLL.Tinh(db, SachDAL.LayTheoMa(db, ct.MaSach).GiaBia, ct.HanTra, tinhTrang, out soNgayTre, out tienPhat, out tienDen);
                if (tienPhat + tienDen > 0 && !daThuTien)
                    return "Phải thu " + string.Format("{0:N0}", tienPhat + tienDen) + "đ trước khi hoàn tất trả sách.";

                // Bước 2: đóng cuốn mượn. 0 dòng nghĩa là có người vừa đóng cuốn này
                if (ChiTietMuonDAL.Dong(db, maCTM, DateTime.Today, tinhTrang) == 0)
                    return "Cuốn này vừa được trả, hãy tải lại danh sách.";

                // Bước 3: kho. Mất thì giảm tổng; còn lại thì cuốn về kho
                if (tinhTrang == TinhTrangMuon.Mat) SachDAL.GiamTong(db, ct.MaSach);
                else SachDAL.CongKho(db, ct.MaSach);

                // Bước 4: phiếu thu. Khoản 0đ thì hàm tự bỏ qua. Vừa trễ vừa hỏng thì có 2 phiếu
                PhieuThuBLL.TaoPhieuThu(db, LoaiThu.PhatTre, tienPhat, null, maCTM, "Trả trễ " + soNgayTre + " ngày");
                PhieuThuBLL.TaoPhieuThu(db, LoaiThu.DenBu, tienDen, null, maCTM, tinhTrang == TinhTrangMuon.Mat ? "Sách mất" : "Sách hỏng");

                db.XacNhan();
                return null;
            }
        }
    }
}
