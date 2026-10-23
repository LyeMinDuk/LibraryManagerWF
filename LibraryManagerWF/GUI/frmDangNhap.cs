using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI
{
    public partial class frmDangNhap : Form
    {
        private readonly List<Image> _anhDaVe = new List<Image>();

        public frmDangNhap()
        {
            InitializeComponent();
            BatChongNhay();
            ActiveControl = txtTenDangNhap;
        }

        private void BatChongNhay()
        {
            DoubleBuffered = true;
            foreach (Control c in new Control[] { pnlNen, pnlFormDangNhap, tlpKhung, pnlThan, tlpNoiDung, tlpO })
                BatDoubleBuffer(c);
        }

        private static void BatDoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(c, true, null);
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
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
            if (goc == null || p.ClientSize.Width <= 0 || p.ClientSize.Height <= 0)
                return;

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
            foreach (Image anh in _anhDaVe)
                anh.Dispose();
            _anhDaVe.Clear();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;
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
