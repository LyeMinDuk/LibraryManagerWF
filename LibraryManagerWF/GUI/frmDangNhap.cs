using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
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
        // Ảnh nền đã co sẵn đúng cỡ (tạo một lần ở Load, giải phóng khi đóng form)
        private readonly List<Image> _anhDaVe = new List<Image>();

        public frmDangNhap()
        {
            InitializeComponent();
            BatChongNhay();
            ActiveControl = txtTenDangNhap;
        }

        // ===== Chống giật hình =====
        // Nguyên nhân: nền là ảnh Stretch + nhiều control con BackColor Transparent. Mỗi lần một control con vẽ lại,
        // WinForms vẽ lại cả ảnh nền của cha (co ảnh 1920x960 về cỡ form) rồi mới vẽ chữ lên, nên thấy nháy.
        // Cách sửa: bật vẽ đệm (DoubleBuffered) cho cả chuỗi control cha, và co ảnh nền về đúng cỡ một lần duy nhất.

        private void BatChongNhay()
        {
            DoubleBuffered = true;
            foreach (Control c in new Control[] { pnlNen, pnlFormDangNhap, tlpKhung, pnlThan, tlpNoiDung, tlpO })
                BatDoubleBuffer(c);
        }

        /// <summary>DoubleBuffered là thuộc tính protected của Control nên phải bật qua reflection.</summary>
        private static void BatDoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(c, true, null);
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // Form thiết kế cỡ 1685x838: màn hình nhỏ hơn thì thu lại cho vừa vùng làm việc
            Rectangle vung = Screen.FromControl(this).WorkingArea;
            if (Width > vung.Width || Height > vung.Height)
            {
                ClientSize = new Size(
                    Math.Min(ClientSize.Width, vung.Width - (Width - ClientSize.Width)),
                    Math.Min(ClientSize.Height, vung.Height - (Height - ClientSize.Height)));
                CenterToScreen();
            }

            VeSanNen(pnlNen);
            VeSanNen(pnlThan);
        }

        private void VeSanNen(Panel p)
        {
            Image goc = p.BackgroundImage;
            if (goc == null || p.ClientSize.Width <= 0 || p.ClientSize.Height <= 0) return;

            var bmp = new Bitmap(p.ClientSize.Width, p.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(goc, 0, 0, bmp.Width, bmp.Height);
            }
            p.BackgroundImageLayout = ImageLayout.None;
            p.BackgroundImage = bmp;
            _anhDaVe.Add(bmp);
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlNen.BackgroundImage = null;
            pnlThan.BackgroundImage = null;
            foreach (Image anh in _anhDaVe) anh.Dispose();
            _anhDaVe.Clear();
        }

        // ===== Đăng nhập =====

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
