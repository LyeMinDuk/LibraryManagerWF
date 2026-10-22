using System;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI
{
    /// <summary>Trang chủ: lời chào theo người đăng nhập. Giao diện kéo thả trong ucTrangChu.Designer.cs, ở đây chỉ gán chữ động.</summary>
    public partial class ucTrangChu : UserControl
    {
        public ucTrangChu()
        {
            InitializeComponent();
            string vaiTro = AppSession.LaQuanTri ? "Quản trị viên" : "Thủ thư";
            lblChao.Text = "Chào mừng đến với phần mềm quản lý thư viện\r\n\r\n" +
                           AppSession.HoTen + " (" + vaiTro + ")\r\n" +
                           "Hôm nay: " + DateTime.Today.ToString("dd/MM/yyyy");
        }
    }
}
