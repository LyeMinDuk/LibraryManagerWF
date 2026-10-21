using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    /// <summary>Trang giữ chỗ cho module chưa làm. Chủ module thay bằng UserControl thật trong frmMain.DangKyMenu().</summary>
    public class ucChoPhatTrien : UserControl
    {
        public ucChoPhatTrien(string tenChucNang, string chuSoHuu)
        {
            BackColor = Theme.Nen;
            var lbl = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Theme.MakeFont(14F),
                ForeColor = Theme.ChuPhu,
                Text = "Chức năng \"" + tenChucNang + "\" chưa được cài đặt.\r\n\r\n" +
                       "Người phụ trách: " + chuSoHuu + "\r\n\r\n" +
                       "Tạo UserControl của bạn (ví dụ ucSach), rồi trong frmMain.DangKyMenu()\r\n" +
                       "thay null của dòng này bằng:  () => new ucSach()"
            };
            Controls.Add(lbl);
        }
    }
}
