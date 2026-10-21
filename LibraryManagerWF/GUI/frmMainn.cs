using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Khung chính (bản Designer mới): 11 nút cố định (button1..button11 trong panel1..panel11
    /// của flpMenu) thay vì tạo Button động như bản cũ. Logic giữ nguyên tinh thần: ẩn mục
    /// theo vai trò, đổi màu nút khi chọn, nạp UserControl vào pnlNoiDung, đăng xuất/thoát.
    /// Muốn thêm/gắn module: sửa ĐÚNG dòng của mình trong KhoiTaoMenu() (mỗi module một dòng
    /// riêng để nhánh Git không xung đột).
    /// </summary>
    public partial class frmMainn : Form
    {
        public bool DangXuat { get; private set; }

        private class MucMenu
        {
            public string Ten;
            public bool CanQuanTri;
            public Func<UserControl> Tao;   // null = chưa làm, hiện trang giữ chỗ
            public string ChuSoHuu;
            public Button Nut;
            public Panel NutPanel;          // panelX bọc button — ẩn cả panel để FlowLayoutPanel dồn lên
        }

        private List<MucMenu> _menu;
        private MucMenu _dangChon;
        private bool sideBarExpand;

        public frmMainn()
        {
            InitializeComponent();
            lblTrang.UseMnemonic = false;

            this.Load += frmMainn_Load;
            this.FormClosing += frmMainn_FormClosing;
            btnDangXuat.Click += btnDangXuat_Click;
            pbLogo.Click += pbLogo_Click; 

            KhoiTaoMenu();
            ApDungPhanQuyen();

            //TaiKhoanDTO tk = AppSession.CurrentUser;
            //if (tk != null)
            //    lblNguoiDung.Text = tk.HoTen + "  ·  " +
            //        (tk.VaiTro == Constants.VaiTro.QuanTri ? "Quản trị viên" : "Thủ thư");
        }

        /// <summary>
        /// ĐĂNG KÝ MODULE — ĐÚNG THỨ TỰ 1→11 khớp button1..button11 đã kéo sẵn trong Designer.
        /// Không được đảo thứ tự ở đây, vì nút không còn tạo động mà map cố định theo index.
        /// </summary>
        private void KhoiTaoMenu()
        {
            _menu = new List<MucMenu>
            {
                Tao("Trang chủ",            false, () => new ucTrangChu(),        "Đức",    button1,  panel1),
                Tao("Sách & thể loại",      false, null,                          "Đức",    button2,  panel2),
                Tao("Độc giả & thẻ",        false, null,                          "Cường",  button3,  panel3),
                Tao("Cho mượn",             false, null,                          "Cường",  button4,  panel4),
                Tao("Gia hạn sách",         false, null,                          "Cường",  button5,  panel5),
                Tao("Trả sách",             false, () => new ucQuanLyTra(),       "Thành",  button6,  panel6),
                Tao("Theo dõi mượn trả",    false, () => new ucTheoDoiMuonTra(),  "Thành",  button7,  panel7),
                Tao("Phiếu thu",            false, () => new ucQuanLyPhieuThu(),  "Thành",  button8,  panel8),
                Tao("Báo cáo doanh thu",    true,  null,                          "Thành",  button9,  panel9),
                Tao("Tài khoản",            true,  null,                          "Đức",    button10, panel10),
                Tao("Cấu hình đơn giá",     true,  null,                          "Đức",    button11, panel11),
            };

            foreach (MucMenu m in _menu)
            {
                
                //m.Nut.TextAlign = ContentAlignment.MiddleLeft;
                //m.Nut.UseMnemonic = false;   // để "&" trong "Sách & thể loại" hiện đúng, không bị hiểu là phím tắt
                //m.Nut.FlatStyle = FlatStyle.Flat;
                //m.Nut.FlatAppearance.BorderSize = 0;
                //m.Nut.BackColor = Theme.Sidebar;
                //m.Nut.ForeColor = Theme.ChuSangTrenToi;
                m.Nut.Tag = m;
                m.Nut.Click += Nut_Click;
                m.Nut.MouseEnter += Nut_MouseEnter;
                m.Nut.MouseLeave += Nut_MouseLeave;
            }
        }

        private MucMenu Tao(string ten, bool canQuanTri, Func<UserControl> tao, string chuSoHuu, Button nut, Panel panel)
            => new MucMenu { Ten = ten, CanQuanTri = canQuanTri, Tao = tao, ChuSoHuu = chuSoHuu, Nut = nut, NutPanel = panel };

        /// <summary>ThuThu không thấy mục chỉ QuanTri (mục 2) — ẩn cả Panel bọc, không chỉ Button,
        /// để FlowLayoutPanel tự dồn các mục còn lại lên trên, không để khoảng trống giữa chừng.</summary>
        private void ApDungPhanQuyen()
        {
            foreach (MucMenu m in _menu)
                m.NutPanel.Visible = !m.CanQuanTri || AppSession.LaQuanTri;
        }

        private void Nut_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var m = (MucMenu)btn.Tag;
            if (_dangChon != m) btn.BackColor = Theme.SidebarHover;
        }

        private void Nut_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var m = (MucMenu)btn.Tag;
            if (_dangChon != m) btn.BackColor = Theme.Sidebar;
        }

        private void Nut_Click(object sender, EventArgs e) => ChonMuc((MucMenu)((Button)sender).Tag);

        private void ChonMuc(MucMenu m)
        {
            if (_dangChon != null) _dangChon.Nut.BackColor = Theme.Sidebar;
            _dangChon = m;
            m.Nut.BackColor = Theme.SidebarChon;

            UserControl uc = m.Tao != null ? m.Tao() : new ucChoPhatTrien(m.Ten, m.ChuSoHuu);
            HienTrang(m.Ten, uc);
        }

        /// <summary>Thay nội dung vùng giữa bằng một UserControl (hủy control cũ để giải phóng bộ nhớ).</summary>
        public void HienTrang(string tieuDe, UserControl uc)
        {
            pnlNoiDung.SuspendLayout();
            foreach (Control c in pnlNoiDung.Controls.Cast<Control>().ToList())
            {
                pnlNoiDung.Controls.Remove(c);
                c.Dispose();
            }
            uc.Dock = DockStyle.Fill;
            pnlNoiDung.Controls.Add(uc);
            lblTrang.Text = tieuDe;
            pnlNoiDung.ResumeLayout();
        }

        private void frmMainn_Load(object sender, EventArgs e)
        {
            MucMenu dauTien = _menu.FirstOrDefault(m => m.NutPanel.Visible);
            if (dauTien != null) ChonMuc(dauTien);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            AuthBLL.DangXuat();
            DangXuat = true;
            Close();
        }

        private void frmMainn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DangXuat || e.CloseReason != CloseReason.UserClosing) return;
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }

        // ==== Thu gọn/mở rộng sidebar — giữ nguyên từ bản bạn gửi ====
        private void SideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                pnlSidebar.Width -= 50;
                if (pnlSidebar.Width <= pnlSidebar.MinimumSize.Width)
                {
                    sideBarExpand = false;
                    SideBarTimer.Stop();
                }
            }
            else
            {
                pnlSidebar.Width += 50;
                if (pnlSidebar.Width >= pnlSidebar.MaximumSize.Width)
                {
                    sideBarExpand = true;
                    SideBarTimer.Stop();
                }
            }
        }

        private void pbLogo_Click(object sender, EventArgs e) => SideBarTimer.Start();
    }
}