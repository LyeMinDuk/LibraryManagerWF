namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Phiếu thu chỉ xem/tra cứu. Không có tab "Tạo phiếu": theo BR08 mỗi khoản thu tự sinh từ nghiệp vụ
    /// (cấp/gia hạn thẻ trong TheBLL, trả sách trong TraBLL qua PhieuThuBLL.TaoPhieuThu(db, ...) trong transaction),
    /// GUI không được lập phiếu rời.
    /// </summary>
    public partial class ucQuanLyPhieuThu : ucTabContainer
    {
        public ucQuanLyPhieuThu() : base("QUẢN LÝ PHIẾU THU",
            new TabInfo("Danh sách phiếu thu", () => new ucThongTinPhieuThu()))
        {
        }
    }
}
