using System.Data;
using LibraryManagerWF.DAL;

namespace LibraryManagerWF.BLL
{
    /// <summary>
    /// Tham số nghiệp vụ trong bảng CauHinh (BR01 đến BR07).
    /// Khóa: THE_SO_THANG, PHI_THE, MUON_TOI_DA, MUON_SO_NGAY, GIA_HAN_TOI_DA, GIA_HAN_SO_NGAY,
    ///       PHAT_TRE_MOI_NGAY, DEN_HONG_PHAN_TRAM, DEN_MAT_PHAN_TRAM.
    /// </summary>
    public static class CauHinhBLL
    {
        /// <summary>Dùng nội bộ giữa các BLL (đã kiểm tra quyền ở hàm gọi).</summary>
        public static int Lay(DataBaseProcess db, string khoa)
        {
            return CauHinhDAL.LayGiaTri(db, khoa);
        }

        public static DataTable LayTatCa()
        {
            Quyen.YeuCauDangNhap();
            using (var db = new DataBaseProcess())
                return CauHinhDAL.LayTatCa(db);
        }

        /// <summary>Chỉ QuanTri được đổi. Giá trị phải là số nguyên không âm.</summary>
        public static string CapNhat(string khoa, string giaTri)
        {
            Quyen.YeuCauQuanTri();
            int so;
            if (!int.TryParse(giaTri, out so) || so < 0) return "Giá trị phải là số nguyên không âm.";

            using (var db = new DataBaseProcess())
            {
                if (CauHinhDAL.CapNhat(db, khoa, so.ToString()) == 0) return "Không có khóa cấu hình này.";
                return null;
            }
        }
    }
}
