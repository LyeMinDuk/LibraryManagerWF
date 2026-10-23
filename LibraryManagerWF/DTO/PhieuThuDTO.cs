using System;

namespace LibraryManagerWF.DTO
{
    public class PhieuThuDTO
    {
        public int MaPT { get; set; }
        public string LoaiThu { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayThu { get; set; }
        public int? MaThe { get; set; }
        public int? MaCTM { get; set; }
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
