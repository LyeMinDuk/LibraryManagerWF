using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    public partial class ucChoPhatTrien : UserControl
    {
        public ucChoPhatTrien(string tenChucNang, string chuSoHuu)
        {
            InitializeComponent();
            lblNoiDung.Text = "Chức năng \"" + tenChucNang + "\" chưa được cài đặt.\r\n\r\n" +
                              "Người phụ trách: " + chuSoHuu + "\r\n\r\n" +
                              "Tạo UserControl của bạn (ví dụ ucSach), rồi trong frmMainn.KhoiTaoMenu()\r\n" +
                              "thay null của dòng này bằng:  () => new ucSach()";
        }
    }
}
