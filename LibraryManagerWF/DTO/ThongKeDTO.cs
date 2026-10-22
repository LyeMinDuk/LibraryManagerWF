namespace LibraryManagerWF.DTO
{
    /// <summary>Số liệu nhanh hiển thị ở trang chủ. Doanh thu chỉ có giá trị khi người xem là quản trị (null nếu không).</summary>
    public class ThongKeDTO
    {
        public int DauSachHoatDong { get; set; }    // số đầu sách đang hoạt động
        public int CuonConTrenKe { get; set; }      // tổng SoLuongCon của sách đang hoạt động
        public int TongCuon { get; set; }           // tổng SoLuongTong của sách đang hoạt động
        public int DocGiaHoatDong { get; set; }
        public int TheConHieuLuc { get; set; }      // thẻ không khóa và chưa hết hạn
        public int DangMuon { get; set; }           // cuốn chưa trả
        public int QuaHan { get; set; }             // cuốn chưa trả và đã quá hạn
        public int MuonHomNay { get; set; }         // số cuốn được cho mượn hôm nay
        public int TraHomNay { get; set; }          // số cuốn được trả hôm nay
        public decimal? DoanhThuHomNay { get; set; }
        public decimal? DoanhThuThangNay { get; set; }
    }
}
