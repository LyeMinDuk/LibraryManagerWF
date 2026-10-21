using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    /// <summary>
    /// Cho mượn, gia hạn sách, theo dõi mượn trả. BR02 đến BR05.
    /// Mượn ghi nhiều bảng nên chạy trong MỘT transaction: lỗi ở bước nào thì thoát hàm,
    /// DataBaseProcess.Dispose() tự hủy hết, không bảng nào bị ghi dở.
    /// </summary>
    public static class MuonBLL
    {
        /// <summary>Lập phiếu mượn cho một thẻ gồm nhiều cuốn. hanTra là hạn trả chung của cả phiếu.</summary>
        public static string Muon(int maThe, List<int> dsMaSach, out DateTime hanTra)
        {
            hanTra = DateTime.Today;
            Quyen.YeuCauDangNhap();
            if (dsMaSach == null || dsMaSach.Count == 0) return "Vui lòng chọn ít nhất một cuốn sách.";
            if (dsMaSach.Distinct().Count() != dsMaSach.Count) return "Một phiếu mượn không được chọn trùng sách.";

            using (var db = new DbHelpers())
            {
                db.BatDauGiaoDich();
                hanTra = DateTime.Today.AddDays(CauHinhBLL.Lay(db, "MUON_SO_NGAY"));

                // 1. Thẻ và độc giả có được mượn không (BR04)
                string loi = TheBLL.KiemTraDuocMuon(db, maThe);
                if (loi != null) return loi;

                // 2. Không vượt hạn mức mượn cùng lúc (BR02)
                int toiDa = CauHinhBLL.Lay(db, "MUON_TOI_DA");
                int dangMuon = ChiTietMuonDAL.DemDangMuon(db, maThe);
                if (dangMuon + dsMaSach.Count > toiDa)
                    return "Vượt hạn mức mượn " + toiDa + " cuốn: thẻ đang mượn " + dangMuon + " cuốn.";

                // 3. Ghi phiếu mượn
                int maPM = PhieuMuonDAL.Them(db, new PhieuMuonDTO { MaThe = maThe, NgayMuon = DateTime.Today, MaTK = AppSession.MaTK });

                // 4. Mỗi cuốn: trừ kho rồi ghi dòng chi tiết
                foreach (int maSach in dsMaSach)
                {
                    // 0 dòng nghĩa là sách hết hoặc đang bị khóa (BR05)
                    if (SachDAL.TruKho(db, maSach) == 0)
                        return "Sách mã " + maSach + " đã hết hoặc đang bị khóa, không cho mượn.";
                    ChiTietMuonDAL.Them(db, new ChiTietMuonDTO { MaPM = maPM, MaSach = maSach, HanTra = hanTra });
                }

                db.XacNhan();
                return null;
            }
        }

        /// <summary>Gia hạn một cuốn: chưa quá hạn, chưa hết số lần gia hạn, độc giả không có cuốn nào khác quá hạn (BR03, BR04).</summary>
        public static string GiaHan(int maCTM, out DateTime hanMoi)
        {
            hanMoi = DateTime.Today;
            Quyen.YeuCauDangNhap();

            using (var db = new DbHelpers())
            {
                db.BatDauGiaoDich();

                ChiTietMuonDTO ct = ChiTietMuonDAL.LayTheoMa(db, maCTM);
                if (ct == null) return "Không tìm thấy cuốn mượn.";
                if (ct.NgayTra.HasValue) return "Cuốn này đã được trả, không gia hạn được.";

                int maThe = PhieuMuonDAL.LayTheoMa(db, ct.MaPM).MaThe;
                string loi = TheBLL.KiemTraDuocMuon(db, maThe);
                if (loi != null) return loi;

                if (ct.HanTra < DateTime.Today) return "Cuốn này đã quá hạn, không gia hạn được. Hãy trả sách.";
                int toiDa = CauHinhBLL.Lay(db, "GIA_HAN_TOI_DA");
                if (ct.SoLanGiaHan >= toiDa) return "Cuốn này đã gia hạn tối đa " + toiDa + " lần.";

                hanMoi = ct.HanTra.AddDays(CauHinhBLL.Lay(db, "GIA_HAN_SO_NGAY"));
                if (ChiTietMuonDAL.GiaHan(db, maCTM, hanMoi) == 0) return "Cuốn này vừa được trả, hãy tải lại danh sách.";

                db.XacNhan();
                return null;
            }
        }

        /// <summary>tuKhoa: họ tên, SĐT hoặc tên sách (rỗng = tất cả). maThe = 0: mọi thẻ. loc: 0 tất cả, 1 đang mượn, 2 quá hạn, 3 đã trả.</summary>
        public static DataTable DanhSachMuon(string tuKhoa, int maThe, int loc)
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                return ChiTietMuonDAL.DanhSach(db, DateTime.Today, tuKhoa, maThe, loc);
        }
    }
}
