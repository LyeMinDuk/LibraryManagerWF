using System;

namespace LibraryManagerWF.DTO
{
    public class DocGiaDTO
    {
        public int MaDG { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }        // "Nam", "Nữ" hoặc "Khác"
        public string DiaChi { get; set; }          // null nếu để trống
        public string SDT { get; set; }
        public string Email { get; set; }           // null nếu để trống
        public bool TrangThai { get; set; }
    }
}
