namespace LibraryManagerWF.GUI.UC.Duc
{
    public partial class ucQuanLySach : ucTabContainer
    {
        public ucQuanLySach() : base("QUẢN LÝ SÁCH & THỂ LOẠI",
            new TabInfo("Sách", () => new ucSach()),
            new TabInfo("Thể loại", () => new ucTheLoai()))
        {
        }
    }
}
