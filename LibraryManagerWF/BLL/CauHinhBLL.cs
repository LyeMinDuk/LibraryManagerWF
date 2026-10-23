using System.Data;
using LibraryManagerWF.DAL;

namespace LibraryManagerWF.BLL
{
    public static class CauHinhBLL
    {
        public static int Lay(DbHelpers db, string khoa)
        {
            return CauHinhDAL.LayGiaTri(db, khoa);
        }

        public static DataTable LayTatCa()
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DbHelpers())
                return CauHinhDAL.LayTatCa(db);
        }

        public static string CapNhat(string khoa, string giaTri)
        {
            Quyen.YeuCauQuanTri();
            int so;
            if (!int.TryParse(giaTri, out so) || so < 0)
                return "Giá trị phải là số nguyên không âm.";

            using (var db = new DbHelpers())
            {
                if (CauHinhDAL.CapNhat(db, khoa, so.ToString()) == 0)
                    return "Không có khóa cấu hình này.";
                return null;
            }
        }
    }
}
