using System;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Phiếu thu chỉ xem/tra cứu. Không có tab "Tạo phiếu": theo BR08 mỗi khoản thu tự sinh từ nghiệp vụ
    /// (cấp/gia hạn thẻ trong TheBLL, trả sách trong TraBLL qua PhieuThuBLL.TaoPhieuThu(db, ...) trong transaction),
    /// GUI không được lập phiếu rời.
    /// </summary>
    public partial class ucQuanLyPhieuThu : ucTabContainer
    {
        public ucQuanLyPhieuThu() : this(null, null, null, null, null, null)
        {
        }

        public ucQuanLyPhieuThu(int maCTM, string hoTen, int maThe, string tenSach, string tinhTrang, Action dong)
            : this((int?)maCTM, hoTen, (int?)maThe, tenSach, tinhTrang, dong)
        {
        }

        private ucQuanLyPhieuThu(int? maCTM, string hoTen, int? maThe, string tenSach, string tinhTrang, Action dong)
            : base("QUẢN LÝ PHIẾU THU",
            new TabInfo("Tạo phiếu thu", () => TaoPhieuThu(maCTM, hoTen, maThe, tenSach, tinhTrang, dong)),
            new TabInfo("Danh sách phiếu thu", () => new ucThongTinPhieuThu()))
        {
        }

        private static UserControl TaoPhieuThu(int? maCTM, string hoTen, int? maThe, string tenSach, string tinhTrang, Action dong)
        {
            var uc = new ucTaoPhieuThu();
            if (maCTM.HasValue && maThe.HasValue)
                uc.Nap(maCTM.Value, hoTen, maThe.Value, tenSach, tinhTrang);
            if (dong != null)
                uc.Dong += (s, e) => dong();
            return uc;
        }
    }
}
