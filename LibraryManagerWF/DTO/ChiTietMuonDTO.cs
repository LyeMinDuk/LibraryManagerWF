using System;

namespace LibraryManagerWF.DTO
{
    public class ChiTietMuonDTO
    {
        public int MaCTM { get; set; }
        public int MaPM { get; set; }
        public int MaSach { get; set; }
        public DateTime HanTra { get; set; }
        public int SoLanGiaHan { get; set; }
        public DateTime? NgayTra { get; set; }
        public string TinhTrang { get; set; }
    }

    public static class TinhTrangMuon
    {
        public const string ChuaTra = "Chưa trả";
        public const string BinhThuong = "Bình thường";
        public const string Hong = "Hỏng";
        public const string Mat = "Mất";
    }
}
