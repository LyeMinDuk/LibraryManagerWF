using System;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    /// <summary>Thẻ thư viện. BR01 (hiệu lực, phí), BR04 (điều kiện được mượn), BR10 (đã có giao dịch thì chỉ khóa).</summary>
    public static class TheBLL
    {
        /// <summary>"Khóa", "Hết hạn" hoặc "Hoạt động". "Hết hạn" không lưu trong CSDL mà tính từ ngày hết hạn.</summary>
        public static string TinhTrangThe(bool trangThai, DateTime ngayHetHan)
        {
            if (!trangThai) return "Khóa";
            if (ngayHetHan.Date < DateTime.Today) return "Hết hạn";
            return "Hoạt động";
        }

        /// <summary>Thẻ của độc giả (mỗi độc giả tối đa một thẻ), hoặc null nếu chưa cấp.</summary>
        public static TheThuVienDTO LayTheoDocGia(int maDG)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                return TheThuVienDAL.LayTheoDocGia(db, maDG);
        }

        /// <summary>
        /// BR04: được mượn hoặc gia hạn sách khi độc giả và thẻ không bị khóa, thẻ chưa hết hạn
        /// và không có cuốn nào quá hạn. Trả về lý do không được, hoặc null nếu được.
        /// Dùng trong transaction của MuonBLL nên nhận db từ người gọi.
        /// </summary>
        public static string KiemTraDuocMuon(DbHelpers db, int maThe)
        {
            TheThuVienDTO the = TheThuVienDAL.LayTheoMa(db, maThe);
            if (the == null) return "Không tìm thấy thẻ thư viện (độc giả chưa được cấp thẻ?).";
            DocGiaDTO dg = DocGiaDAL.LayTheoMa(db, the.MaDG);

            if (!dg.TrangThai) return "Độc giả \"" + dg.HoTen + "\" đang bị khóa.";

            string tinhTrang = TinhTrangThe(the.TrangThai, the.NgayHetHan);
            if (tinhTrang == "Khóa") return "Thẻ của độc giả \"" + dg.HoTen + "\" đang bị khóa.";
            if (tinhTrang == "Hết hạn")
                return "Thẻ của độc giả \"" + dg.HoTen + "\" đã hết hạn ngày " + the.NgayHetHan.ToString("dd/MM/yyyy") + ". Hãy gia hạn thẻ.";

            int quaHan = ChiTietMuonDAL.DemQuaHan(db, maThe, DateTime.Today);
            if (quaHan > 0)
                return "Độc giả \"" + dg.HoTen + "\" đang có " + quaHan + " cuốn sách quá hạn. Phải trả sách trước khi mượn hoặc gia hạn.";
            return null;
        }

        /// <summary>Cấp thẻ mới: tạo thẻ và lập phiếu thu phí thẻ trong cùng một transaction.</summary>
        public static string CapThe(int maDG, out DateTime ngayHetHan)
        {
            ngayHetHan = DateTime.Today;
            Quyen.YeuCauDangNhap();

            using (var db = new DbHelpers())
            {
                db.BatDauGiaoDich();

                DocGiaDTO dg = DocGiaDAL.LayTheoMa(db, maDG);
                if (dg == null) return "Không tìm thấy độc giả.";
                if (!dg.TrangThai) return "Độc giả đang bị khóa, không cấp được thẻ.";
                if (TheThuVienDAL.LayTheoDocGia(db, maDG) != null) return "Độc giả đã có thẻ. Hãy dùng chức năng Gia hạn thẻ.";

                ngayHetHan = DateTime.Today.AddMonths(CauHinhBLL.Lay(db, "THE_SO_THANG"));
                int maThe = TheThuVienDAL.Them(db, new TheThuVienDTO { MaDG = maDG, NgayCap = DateTime.Today, NgayHetHan = ngayHetHan });
                PhieuThuBLL.TaoPhieuThu(db, LoaiThu.PhiThe, CauHinhBLL.Lay(db, "PHI_THE"), maThe, null, "Cấp thẻ mới");

                db.XacNhan();
                return null;
            }
        }

        /// <summary>
        /// Gia hạn thẻ và lập phiếu thu phí thẻ. Thẻ còn hạn thì cộng thêm từ ngày hết hạn cũ,
        /// thẻ đã hết hạn thì tính từ hôm nay. Thẻ hoặc độc giả bị khóa thì không gia hạn được.
        /// </summary>
        public static string GiaHanThe(int maThe, out DateTime ngayHetHanMoi)
        {
            ngayHetHanMoi = DateTime.Today;
            Quyen.YeuCauDangNhap();

            using (var db = new DbHelpers())
            {
                db.BatDauGiaoDich();

                TheThuVienDTO the = TheThuVienDAL.LayTheoMa(db, maThe);
                if (the == null) return "Không tìm thấy thẻ.";
                if (!DocGiaDAL.LayTheoMa(db, the.MaDG).TrangThai) return "Độc giả đang bị khóa, không gia hạn được thẻ.";
                if (!the.TrangThai) return "Thẻ đang bị khóa, không gia hạn được.";

                DateTime goc = the.NgayHetHan >= DateTime.Today ? the.NgayHetHan : DateTime.Today;
                ngayHetHanMoi = goc.AddMonths(CauHinhBLL.Lay(db, "THE_SO_THANG"));

                if (TheThuVienDAL.GiaHan(db, maThe, the.NgayHetHan, ngayHetHanMoi) == 0)
                    return "Thẻ vừa được thay đổi ở nơi khác, hãy tải lại rồi gia hạn lại.";
                PhieuThuBLL.TaoPhieuThu(db, LoaiThu.PhiThe, CauHinhBLL.Lay(db, "PHI_THE"), maThe, null, "Gia hạn thẻ");

                db.XacNhan();
                return null;
            }
        }

        /// <summary>Khóa (hoatDong = false) hoặc mở khóa (true) thẻ bằng tay.</summary>
        public static void DoiTrangThai(int maThe, bool hoatDong)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                TheThuVienDAL.DoiTrangThai(db, maThe, hoatDong);
        }

        /// <summary>BR10: thẻ đã có phiếu mượn hoặc phiếu thu thì không xóa, chỉ khóa.</summary>
        public static string Xoa(int maThe)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
            {
                if (TheThuVienDAL.DemGiaoDich(db, maThe) > 0) return "Thẻ đã phát sinh giao dịch nên không xóa được, hãy khóa thẻ.";
                TheThuVienDAL.Xoa(db, maThe);
                return null;
            }
        }
    }
}
