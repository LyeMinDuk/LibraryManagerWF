namespace LibraryManagerWF.GUI.UC.Cuong
{
    /// <summary>Độc giả &amp; thẻ: hai tab dùng chung khung tiêu đề / nút tab của ucTabContainer.</summary>
    public partial class ucQuanLyDocGia : ucTabContainer
    {
        public ucQuanLyDocGia() : base("QUẢN LÝ ĐỘC GIẢ & THẺ",
            new TabInfo("Độc giả", () => new ucDocGia()),
            new TabInfo("Thẻ thư viện", () => new ucThe()))
        {
        }
    }
}
