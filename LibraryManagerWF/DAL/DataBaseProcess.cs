using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagerWF.DAL
{
    /// <summary>
    /// Lớp làm việc với CSDL, giống DataBaseProcess trong slide: DocBang = DataReader, CapNhat = DataChange.
    /// Khác slide hai điểm nhỏ:
    ///  1. Kết nối mở trong suốt một lần làm việc (using) để dùng được transaction.
    ///  2. Giá trị truyền qua @0, @1, ... thay vì nối chuỗi, ví dụ: db.DocBang("SELECT * FROM Sach WHERE MaSach = @0", maSach).
    ///     Nhờ vậy tên có dấu nháy (O'Brien) không làm lỗi câu SQL và không bị SQL injection.
    /// Thoát khỏi khối using mà chưa gọi XacNhan() thì mọi thay đổi trong transaction tự bị hủy.
    /// </summary>
    public class DataBaseProcess : IDisposable
    {
        SqlConnection conn;
        SqlTransaction tran;

        public DataBaseProcess()
        {
            string strConnect = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
            conn = new SqlConnection(strConnect);
            conn.Open();
        }

        SqlCommand TaoLenh(string sql, object[] giaTri)
        {
            SqlCommand cmd = new SqlCommand(sql, conn, tran);
            for (int i = 0; i < giaTri.Length; i++)
                cmd.Parameters.AddWithValue("@" + i, giaTri[i] ?? DBNull.Value);   // null C# -> NULL của SQL
            return cmd;
        }

        // Câu SELECT, trả về một DataTable
        public DataTable DocBang(string sql, params object[] giaTri)
        {
            DataTable dt = new DataTable();
            new SqlDataAdapter(TaoLenh(sql, giaTri)).Fill(dt);
            return dt;
        }

        // Câu INSERT / UPDATE / DELETE, trả về số dòng bị ảnh hưởng
        public int CapNhat(string sql, params object[] giaTri)
        {
            return TaoLenh(sql, giaTri).ExecuteNonQuery();
        }

        // Câu SELECT chỉ lấy một giá trị (ví dụ COUNT(*)); không có thì trả về null
        public object LayMotGiaTri(string sql, params object[] giaTri)
        {
            object v = TaoLenh(sql, giaTri).ExecuteScalar();
            return v == DBNull.Value ? null : v;
        }

        // Câu INSERT vào bảng có cột tự tăng, trả về mã vừa sinh
        public int ThemLayMa(string sql, params object[] giaTri)
        {
            return Convert.ToInt32(LayMotGiaTri(sql + "; SELECT CAST(SCOPE_IDENTITY() AS INT)", giaTri));
        }

        public void BatDauGiaoDich() { tran = conn.BeginTransaction(); }

        public void XacNhan()
        {
            tran.Commit();
            tran = null;
        }

        public void Dispose()
        {
            if (tran != null) tran.Rollback();
            conn.Close();
        }
    }
}
