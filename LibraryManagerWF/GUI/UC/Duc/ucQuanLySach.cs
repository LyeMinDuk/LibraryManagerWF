namespace LibraryManagerWF.GUI.UC.Duc
{
    /// <summary>Sách &amp; thể loại: hai tab dùng chung khung tiêu đề / nút tab của ucTabContainer.</summary>
    public partial class ucQuanLySach : ucTabContainer
    {
        public ucQuanLySach() : base("QUẢN LÝ SÁCH & THỂ LOẠI",
            new TabInfo("Sách", () => new ucSach()),
            new TabInfo("Thể loại", () => new ucTheLoai()))
        {
        }
    }
}
