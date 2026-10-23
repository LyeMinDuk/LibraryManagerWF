using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
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

            btnLuu.Enabled = false;
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
