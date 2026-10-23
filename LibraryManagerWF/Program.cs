using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.GUI;

namespace LibraryManagerWF
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => BaoLoi(e.Exception);

            while (true)
            {
                using (var login = new frmDangNhap())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        return;
                }

                bool dangXuat;
                using (var main = new frmMainn())
                {
                    Application.Run(main);
                    dangXuat = main.DangXuat;
                }

                if (!dangXuat)
                {
                    AuthBLL.DangXuat();
                    return;
                }
            }
        }

        static void BaoLoi(Exception ex)
        {
            if (ex is UnauthorizedAccessException)
                MessageBox.Show(ex.Message, "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (ex is SqlException)
                MessageBox.Show("Không làm việc được với cơ sở dữ liệu:\n\n" + ex.Message,
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Đã xảy ra lỗi ngoài dự kiến:\n\n" + ex.Message,
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
