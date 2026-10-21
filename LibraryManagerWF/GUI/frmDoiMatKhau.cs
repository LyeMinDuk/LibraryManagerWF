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
    public class frmDoiMatKhau : Form
    {
        private readonly Func<string, string, string> _thucHien;
        private TextBox txtCu, txtMoi, txtNhapLai;
        private Button btnLuu, btnHuy;
        private TableLayoutPanel bang;

        public frmDoiMatKhau(string tieuDe, bool hoiMatKhauCu, Func<string, string, string> thucHien)
        {
            _thucHien = thucHien;

            Text = tieuDe;
            Font = Theme.MakeFont(10.5F);
            BackColor = Theme.Nen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(480, hoiMatKhauCu ? 260 : 210);

            bang = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Padding = new Padding(16, 16, 16, 0)
            };
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170));
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            if (hoiMatKhauCu) txtCu = ThemDong("Mật khẩu hiện tại:");
            txtMoi = ThemDong("Mật khẩu mới:");
            txtNhapLai = ThemDong("Nhập lại mật khẩu mới:");

            var flpNut = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(12, 8, 12, 8)
            };
            btnHuy = new Button { Text = "Hủy", Size = new Size(110, 40), DialogResult = DialogResult.Cancel, UseVisualStyleBackColor = true };
            btnLuu = new Button { Text = "Lưu", Size = new Size(110, 40), UseVisualStyleBackColor = true };
            btnLuu.Click += btnLuu_Click;
            flpNut.Controls.Add(btnHuy);   // RightToLeft: nút thêm trước nằm sát phải
            flpNut.Controls.Add(btnLuu);

            Controls.Add(bang);
            Controls.Add(flpNut);
            AcceptButton = btnLuu;
            CancelButton = btnHuy;
            ActiveControl = txtCu ?? txtMoi;
        }

        private TextBox ThemDong(string nhan)
        {
            int dong = bang.RowCount;
            bang.RowCount = dong + 1;
            bang.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));

            var lbl = new Label { Text = nhan, AutoSize = true, Anchor = AnchorStyles.Left, UseMnemonic = false };
            var txt = new TextBox
            {
                UseSystemPasswordChar = true,
                MaxLength = 50,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Margin = new Padding(4)
            };
            bang.Controls.Add(lbl, 0, dong);
            bang.Controls.Add(txt, 1, dong);
            return txt;
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
                string loi = _thucHien(txtCu != null ? txtCu.Text : null, txtMoi.Text);
                if (loi != null)
                {
                    MessageBox.Show(loi, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox dich = (txtCu != null && loi.Contains("hiện tại")) ? txtCu : txtMoi;
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
