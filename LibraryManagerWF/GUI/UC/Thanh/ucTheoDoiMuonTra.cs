namespace LibraryManagerWF.GUI
{
    public partial class ucTheoDoiMuonTra : ucTabContainer
    {
        public ucTheoDoiMuonTra() : base("THEO DÕI MƯỢN TRẢ",
            new TabInfo("Tất cả", () => new ucDSMuonTra(LocMuon.TatCa)),
            new TabInfo("Đang mượn", () => new ucDSMuonTra(LocMuon.DangMuon)),
            new TabInfo("Quá hạn", () => new ucDSMuonTra(LocMuon.QuaHan)),
            new TabInfo("Đã trả", () => new ucDSMuonTra(LocMuon.DaTra)))
        {
        }
    }
}
