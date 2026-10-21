using System;

namespace LibraryManagerWF.DTO
{
    public class TheThuVienDTO
    {
        public int MaThe { get; set; }
        public int MaDG { get; set; }
        public DateTime NgayCap { get; set; }
        public DateTime NgayHetHan { get; set; }
        public bool TrangThai { get; set; }         // "Hết hạn" không lưu, TheBLL.TinhTrangThe tính từ NgayHetHan
    }
}
