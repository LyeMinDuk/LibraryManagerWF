using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagerWF.DAL
{
    public class DbHelpers : IDisposable
    {
        SqlConnection conn;
        SqlTransaction tran;

        public DbHelpers()
        {
            string strConnect = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
            conn = new SqlConnection(strConnect);
            conn.Open();
        }

        SqlCommand TaoLenh(string sql, object[] giaTri)
        {
            SqlCommand cmd = new SqlCommand(sql, conn, tran);
            for (int i = 0; i < giaTri.Length; i++)
                cmd.Parameters.AddWithValue("@" + i, giaTri[i] ?? DBNull.Value);
            return cmd;
        }

        public DataTable DocBang(string sql, params object[] giaTri)
        {
            DataTable dt = new DataTable();
            new SqlDataAdapter(TaoLenh(sql, giaTri)).Fill(dt);
            return dt;
        }

        public int CapNhat(string sql, params object[] giaTri)
        {
            return TaoLenh(sql, giaTri).ExecuteNonQuery();
        }

        public object LayMotGiaTri(string sql, params object[] giaTri)
        {
            object v = TaoLenh(sql, giaTri).ExecuteScalar();
            return v == DBNull.Value ? null : v;
        }

        public int ThemLayMa(string sql, params object[] giaTri)
        {
            return Convert.ToInt32(LayMotGiaTri(sql + "; SELECT CAST(SCOPE_IDENTITY() AS INT)", giaTri));
        }

        public void BatDauGiaoDich()
        {
            tran = conn.BeginTransaction();
        }

        public void XacNhan()
        {
            tran.Commit();
            tran = null;
        }

        public void Dispose()
        {
            if (tran != null)
                tran.Rollback();
            conn.Close();
        }
    }
}
