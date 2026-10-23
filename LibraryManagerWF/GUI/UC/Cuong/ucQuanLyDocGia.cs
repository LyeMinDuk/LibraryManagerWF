namespace LibraryManagerWF.GUI.UC.Cuong
{
    public partial class ucQuanLyDocGia : ucTabContainer
    {
        public ucQuanLyDocGia() : base("QUẢN LÝ ĐỘC GIẢ & THẺ",
            new TabInfo("Độc giả", () => new ucDocGia()),
            new TabInfo("Thẻ thư viện", () => new ucThe()))
        {
        }
    }
}
