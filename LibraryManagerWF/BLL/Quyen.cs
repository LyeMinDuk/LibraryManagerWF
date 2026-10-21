using System;

namespace LibraryManagerWF.BLL
{
    /// <summary>
    /// Kiểm tra quyền, dùng chung cho mọi hàm BLL. Hai mức, QuanTri bao trùm ThuThu:
    ///   YeuCauDangNhap: ThuThu hoặc QuanTri đều được.
    ///   YeuCauQuanTri : chỉ QuanTri.
    /// Quy ước: thiếu quyền là lỗi lập trình (GUI đã ẩn nút) nên ném UnauthorizedAccessException,
    /// Program.cs bắt chung. Còn vi phạm luật nghiệp vụ thì hàm trả về chuỗi lỗi.
    /// </summary>
    public static class Quyen
    {
        public static void YeuCauDangNhap()
        {
            if (!AppSession.DaDangNhap) throw new UnauthorizedAccessException("Chưa đăng nhập.");
        }

        public static void YeuCauQuanTri()
        {
            YeuCauDangNhap();
            if (!AppSession.LaQuanTri) throw new UnauthorizedAccessException("Chức năng này chỉ dành cho quản trị viên.");
        }
    }
}
