using System;

namespace LibraryManagerWF.DTO
{
    public class PhieuThuDTO
    {
        public int MaPT { get; set; }
        public string LoaiThu { get; set; }         // một trong LoaiThu.*
        public decimal SoTien { get; set; }
        public DateTime NgayThu { get; set; }
        public int? MaThe { get; set; }             // chỉ dùng cho Phí thẻ
        public int? MaCTM { get; set; }             // chỉ dùng cho Phạt trễ và Đền bù
        public int MaTK { get; set; }
        public string GhiChu { get; set; }
    }

    public static class LoaiThu
    {
        public const string PhiThe = "Phí thẻ";
        public const string PhatTre = "Phạt trễ";
        public const string DenBu = "Đền bù";
    }
}
