using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    public class ucTrangChu : UserControl
    {
        public ucTrangChu()
        {
            //BackColor = Theme.Nen;
            //TaiKhoan tk = AppSession.CurrentUser;
            //string vaiTro = tk != null && tk.VaiTro == Constants.VaiTro.QuanTri ? "Quản trị viên" : "Thủ thư";
            //var lbl = new Label
            //{
            //    Dock = DockStyle.Fill,
            //    TextAlign = ContentAlignment.MiddleCenter,
            //    Font = Theme.MakeFont(16F),
            //    ForeColor = Theme.Chu,
            //    Text = "Chào mừng đến với phần mềm quản lý thư viện\r\n\r\n" +
            //           (tk == null ? "" : tk.HoTen + " (" + vaiTro + ")\r\n") +
            //           "Hôm nay: " + Clock.Today.ToString("dd/MM/yyyy")
            //};
            //Controls.Add(lbl);
        }
    }
}
