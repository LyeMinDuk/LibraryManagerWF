using System;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Màn hình đăng nhập. GUI chỉ gọi AuthBLL.DangNhap (null = thành công, khác null = lỗi nghiệp vụ);
    /// thành công thì AppSession đã có người dùng và form đóng với DialogResult.OK để Program mở frmMainn.
    /// Lỗi hệ thống (mất kết nối CSDL...) không bắt ở đây, Program.cs bắt chung.
    /// </summary>
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            ActiveControl = txtTenDangNhap;
            btnXacNhan.Click += btnXacNhan_Click;   // Enter kích hoạt nút này nhờ AcceptButton
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;             // chặn bấm nhiều lần khi đang xử lý
            try
            {
                string loi = AuthBLL.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
                if (loi != null)
                {
                    MessageBox.Show(loi, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                        txtTenDangNhap.Focus();
                    else
                    {
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                    }
                    return;
                }
                DialogResult = DialogResult.OK;
            }
            finally
            {
                btnXacNhan.Enabled = true;
            }
        }
    }
}
