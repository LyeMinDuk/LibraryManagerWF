namespace LibraryManagerWF.DTO
{
    /// <summary>Một dòng của bảng TaiKhoan. DTO chỉ chứa dữ liệu, không có logic.</summary>
    public class TaiKhoanDTO
    {
        public int MaTK { get; set; }
        public string TenDN { get; set; }
        public string MatKhauHash { get; set; }     // dạng salt$SHA256HEX
        public string HoTen { get; set; }
        public string VaiTro { get; set; }          // VaiTro.QuanTri hoặc VaiTro.ThuThu
        public bool TrangThai { get; set; }         // true = hoạt động, false = khóa
    }

    /// <summary>Hai giá trị hợp lệ của TaiKhoan.VaiTro. QuanTri có đủ quyền của ThuThu.</summary>
    public static class VaiTro
    {
        public const string QuanTri = "QuanTri";
        public const string ThuThu = "ThuThu";
    }
}
