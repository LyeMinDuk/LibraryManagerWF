using System;

namespace LibraryManagerWF.BLL
{
    public static class Quyen
    {
        public static void YeuCauDangNhap()
        {
            if (!AppSession.DaDangNhap)
                throw new UnauthorizedAccessException("Chưa đăng nhập.");
        }

        public static void YeuCauQuanTri()
        {
            YeuCauDangNhap();
            if (!AppSession.LaQuanTri)
                throw new UnauthorizedAccessException("Chức năng này chỉ dành cho quản trị viên.");
        }
    }
}
