using System;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    public static class TraBLL
    {
        static string KiemTraTinhTrang(string tinhTrang)
        {
            if (tinhTrang != TinhTrangMuon.BinhThuong && tinhTrang != TinhTrangMuon.Hong && tinhTrang != TinhTrangMuon.Mat)
                return "Tình trạng khi trả phải là Bình thường, Hỏng hoặc Mất.";
            return null;
        }

        public static string XemTruoc(int maCTM, string tinhTrang, out decimal tienPhat, out decimal tienDen)
        {
            tienPhat = 0;
            tienDen = 0;
            Quyen.YeuCauDangNhap();
            string loi = KiemTraTinhTrang(tinhTrang);
            if (loi != null)
                return loi;

            using (var db = new DbHelpers())
            {
                ChiTietMuonDTO ct = ChiTietMuonDAL.LayTheoMa(db, maCTM);
                if (ct == null)
                    return "Không tìm thấy cuốn mượn.";
                if (ct.NgayTra.HasValue)
                    return "Cuốn này đã được trả rồi.";

                int soNgayTre;
                TinhPhatBLL.Tinh(db, SachDAL.LayTheoMa(db, ct.MaSach).GiaBia, ct.HanTra, tinhTrang, out soNgayTre, out tienPhat, out tienDen);
                return null;
            }
        }

        public static string Tra(int maCTM, string tinhTrang, bool daThuTien, out decimal tienPhat, out decimal tienDen, string GhiChu)
        {
            tienPhat = 0;
            tienDen = 0;

            Quyen.YeuCauDangNhap();
            string loi = KiemTraTinhTrang(tinhTrang);
            if (loi != null)
                return loi;

            using (var db = new DbHelpers())
            {
                db.BatDauGiaoDich();

                ChiTietMuonDTO ct = ChiTietMuonDAL.LayTheoMa(db, maCTM);
                if (ct == null)
                    return "Không tìm thấy cuốn mượn.";
                if (ct.NgayTra.HasValue)
                    return "Cuốn này đã được trả rồi.";

                int soNgayTre;
                TinhPhatBLL.Tinh(db, SachDAL.LayTheoMa(db, ct.MaSach).GiaBia, ct.HanTra, tinhTrang, out soNgayTre, out tienPhat, out tienDen);
                if (tienPhat + tienDen > 0 && !daThuTien)
                    return "Phải thu " + string.Format("{0:N0}", tienPhat + tienDen) + "đ trước khi hoàn tất trả sách.";

                if (ChiTietMuonDAL.Dong(db, maCTM, DateTime.Today, tinhTrang) == 0)
                    return "Cuốn này vừa được trả, hãy tải lại danh sách.";

                if (tinhTrang == TinhTrangMuon.Mat)
                    SachDAL.GiamTong(db, ct.MaSach);
                else
                    SachDAL.CongKho(db, ct.MaSach);

                PhieuThuBLL.TaoPhieuThu(db, LoaiThu.PhatTre, tienPhat, null, maCTM, "Trả trễ " + soNgayTre + " ngày" + (string.IsNullOrEmpty(GhiChu) ? "" : " (" + GhiChu + ")"));
                PhieuThuBLL.TaoPhieuThu(db, LoaiThu.DenBu, tienDen, null, maCTM, tinhTrang == TinhTrangMuon.Mat ? "Sách mất" : "Sách hỏng" + (string.IsNullOrEmpty(GhiChu) ? "" : " (" + GhiChu + ")"));

                db.XacNhan();
                return null;
            }
        }
    }
}
