using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI
{
    public class ucTrangChu : UserControl
    {
        public ucTrangChu()
        {
            BackColor = Theme.Nen;
            string vaiTro = AppSession.LaQuanTri ? "Quản trị viên" : "Thủ thư";
            var lbl = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Theme.MakeFont(16F),
                ForeColor = Theme.Chu,
                Text = "Chào mừng đến với phần mềm quản lý thư viện\r\n\r\n" +
                       AppSession.HoTen + " (" + vaiTro + ")\r\n" +
                       "Hôm nay: " + DateTime.Today.ToString("dd/MM/yyyy")
            };
            Controls.Add(lbl);
        }
    }
}
