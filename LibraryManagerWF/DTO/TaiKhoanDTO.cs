namespace LibraryManagerWF.DTO
{
    public class TaiKhoanDTO
    {
        public int MaTK { get; set; }
        public string TenDN { get; set; }
        public string MatKhauHash { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
        public bool TrangThai { get; set; }
    }

    public static class VaiTro
    {
        public const string QuanTri = "QuanTri";
        public const string ThuThu = "ThuThu";
    }
}
