using System;
using System.Data;

namespace LibraryManagerWF.DAL
{
    public static class CauHinhDAL
    {
        /// <summary>Giá trị số của một khóa. Thiếu khóa thì ném lỗi, tránh ngầm trả 0 làm sai nghiệp vụ.</summary>
        public static int LayGiaTri(DataBaseProcess db, string khoa)
        {
            object v = db.LayMotGiaTri("SELECT GiaTri FROM CauHinh WHERE Khoa = @0", khoa);
            if (v == null) throw new InvalidOperationException("Thiếu khóa cấu hình " + khoa + " trong bảng CauHinh.");
            return Convert.ToInt32(v);
        }

        public static DataTable LayTatCa(DataBaseProcess db)
        {
            return db.DocBang("SELECT Khoa, GiaTri, MoTa FROM CauHinh ORDER BY Khoa");
        }

        public static int CapNhat(DataBaseProcess db, string khoa, string giaTri)
        {
            return db.CapNhat("UPDATE CauHinh SET GiaTri = @0 WHERE Khoa = @1", giaTri, khoa);
        }
    }
}
