using System;
using LibraryManagerWF.DAL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.BLL
{
    public static class ThongKeBLL
    {
        public static ThongKeDTO LayThongKeTrangChu()
        {
            Quyen.YeuCauDangNhap();
            DateTime homNay = DateTime.Today;

            using (var db = new DbHelpers())
            {
                ThongKeDTO tk = ThongKeDAL.LaySoDem(db, homNay);
                if (AppSession.LaQuanTri)
                {
                    tk.DoanhThuHomNay = ThongKeDAL.TongDoanhThu(db, homNay, homNay);
                    tk.DoanhThuThangNay = ThongKeDAL.TongDoanhThu(db, new DateTime(homNay.Year, homNay.Month, 1), homNay);
                }
                return tk;
            }
        }
    }
}
