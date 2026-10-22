using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Hộp thoại nhập mật khẩu mới, dùng cho hai việc:
    ///   - đổi mật khẩu của chính mình (hoiMatKhauCu = true, có ô mật khẩu hiện tại);
    ///   - quản trị đặt lại mật khẩu cho người khác (hoiMatKhauCu = false).
    /// Form không biết luật nghiệp vụ: chỉ kiểm tra hai ô mật khẩu mới giống nhau, rồi gọi hàm BLL do nơi mở truyền vào
    /// (thucHien(matKhauCu, matKhauMoi) trả về lỗi hoặc null). Có lỗi thì hộp thoại ở lại để nhập lại.
    /// </summary>
    public partial class frmDoiMatKhau : Form
    {
        private readonly Func<string, string, string> _thucHien;
        private readonly bool _hoiMatKhauCu;

        public frmDoiMatKhau(string tieuDe, bool hoiMatKhauCu, Func<string, string, string> thucHien)
        {
            InitializeComponent();
            _thucHien = thucHien;
            _hoiMatKhauCu = hoiMatKhauCu;
            Text = tieuDe;

            if (!hoiMatKhauCu)
            {
                // Đặt lại cho người khác: bỏ dòng "Mật khẩu hiện tại", thu nhỏ form đúng một dòng
                bang.Controls.Remove(lblCu);
                bang.Controls.Remove(txtCu);
                lblCu.Dispose();
                txtCu.Dispose();
                bang.RowStyles[0].Height = 0;
                ClientSize = new Size(ClientSize.Width, ClientSize.Height - 48);
            }

            ActiveControl = hoiMatKhauCu ? txtCu : txtMoi;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Hai ô mật khẩu mới không giống nhau.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLai.Clear();
                txtNhapLai.Focus();
                return;
            }

            btnLuu.Enabled = false;                 // chặn bấm nhiều lần khi đang xử lý
            try
            {
                string loi = _thucHien(_hoiMatKhauCu ? txtCu.Text : null, txtMoi.Text);
                if (loi != null)
                {
                    MessageBox.Show(loi, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox dich = (_hoiMatKhauCu && loi.Contains("hiện tại")) ? txtCu : txtMoi;
                    dich.SelectAll();
                    dich.Focus();
                    return;
                }
                DialogResult = DialogResult.OK;
            }
            finally
            {
                btnLuu.Enabled = true;
            }
        }
    }
}
