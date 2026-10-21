namespace LibraryManagerWF.BLL
{
    /// <summary>Người đang đăng nhập. Biến tĩnh nên chỗ nào cũng đọc được; chỉ AuthBLL được ghi.</summary>
    public static class AppSession
    {
        public static int MaTK { get; internal set; }
        public static string HoTen { get; internal set; }
        public static string VaiTro { get; internal set; }

        public static bool DaDangNhap { get { return MaTK > 0; } }
        public static bool LaQuanTri { get { return VaiTro == DTO.VaiTro.QuanTri; } }
    }
}
