using LibraryManagerWF.BLL;
using LibraryManagerWF.GUI.UC.Cuong;
using LibraryManagerWF.GUI.UC.Duc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.GUI.UC.Cuong;
using LibraryManagerWF.GUI.UC.Duc;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Khung chính (bản Designer mới): 11 nút cố định (button1..button11 trong panel1..panel11
    /// của flpMenu) thay vì tạo Button động như bản cũ. Logic giữ nguyên tinh thần: ẩn mục
    /// theo vai trò, đổi màu nút khi chọn, nạp UserControl vào pnlNoiDung, đăng xuất/thoát.
    /// Muốn gắn module: sửa ĐÚNG dòng của mình trong KhoiTaoMenu() (mỗi module một dòng
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
        private Func<UserControl> _taoPhieuThuTiepTheo;

        public frmMainn()
        {
            InitializeComponent();
            DoubleBuffered = true;
            foreach (Control v in new Control[] { pnlNoiDung, pnlSidebar, flpMenu, pnlHeader })
                GridStyle.BatDoubleBuffer(v);
            lblTrang.UseMnemonic = false;

            new ToolTip().SetToolTip(lblNguoiDung, "Bấm để đổi mật khẩu của bạn");

            KhoiTaoMenu();
            ApDungPhanQuyen();

            // Người dùng lấy từ AppSession (AuthBLL.DangNhap đã điền trước khi frmMainn được tạo)
            lblNguoiDung.Text = AppSession.HoTen + "  -  " + (AppSession.LaQuanTri ? "Quản trị viên" : "Thủ thư");
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
                Tao("Sách & thể loại",      false, () => new ucQuanLySach(),      "Đức",    button2,  panel2),
                Tao("Độc giả & thẻ",        false, () => new ucQuanLyDocGia(),    "Cường",  button3,  panel3),
                Tao("Cho mượn",             false, () => new ucMuon(),            "Cường",  button4,  panel4),
                Tao("Gia hạn sách",         false, () => new ucGiaHan(),          "Cường",  button5,  panel5),
                Tao("Trả sách",             false, () => new ucQuanLyTra(),       "Thành",  button6,  panel6),
                Tao("Theo dõi mượn trả",    false, () => new ucTheoDoiMuonTra(),  "Thành",  button7,  panel7),
                Tao("Phiếu thu",            false, TaoUcQuanLyPhieuThu,            "Thành",  button8,  panel8),
                Tao("Báo cáo doanh thu",    true,  () => new ucBaoCaoDoanhThu(),    "Thành",  button9,  panel9),
                Tao("Tài khoản",            true,  () => new ucTaiKhoan(),        "Đức",    button10, panel10),
                Tao("Cấu hình đơn giá",     true,  () => new ucCauHinh(),                          "Đức",    button11, panel11),
            };

            foreach (MucMenu m in _menu)
            {
                m.Nut.Tag = m;
                m.Nut.Click += Nut_Click;
                m.Nut.MouseEnter += Nut_MouseEnter;
                m.Nut.MouseLeave += Nut_MouseLeave;
            }
        }

        private MucMenu Tao(string ten, bool canQuanTri, Func<UserControl> tao, string chuSoHuu, Button nut, Panel panel)
            => new MucMenu { Ten = ten, CanQuanTri = canQuanTri, Tao = tao, ChuSoHuu = chuSoHuu, Nut = nut, NutPanel = panel };

        private UserControl TaoUcQuanLyPhieuThu()
        {
            if (_taoPhieuThuTiepTheo == null) return new ucQuanLyPhieuThu();

            Func<UserControl> tao = _taoPhieuThuTiepTheo;
            _taoPhieuThuTiepTheo = null;
            return tao();
        }

        public void MoPhieuThuTra(int maCTM, string hoTen, int maThe, string tenSach, string tinhTrang)
        {
            _taoPhieuThuTiepTheo = () => new ucQuanLyPhieuThu(
                maCTM, hoTen, maThe, tenSach, tinhTrang, () => button6.PerformClick());
            try
            {
                button8.PerformClick();
            }
            finally
            {
                _taoPhieuThuTiepTheo = null;
            }
        }

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
            // Thêm UC mới (đúng cỡ) rồi mới bỏ UC cũ, để vùng giữa không bị trống giữa hai lần vẽ.
            List<Control> cu = pnlNoiDung.Controls.Cast<Control>().ToList();
            pnlNoiDung.SuspendLayout();
            uc.Size = pnlNoiDung.ClientSize;
            uc.Dock = DockStyle.Fill;
            pnlNoiDung.Controls.Add(uc);
            uc.BringToFront();
            foreach (Control c in cu)
            {
                pnlNoiDung.Controls.Remove(c);
                c.Dispose();
            }
            lblTrang.Text = tieuDe;
            pnlNoiDung.ResumeLayout(true);
        }

        private void frmMainn_Load(object sender, EventArgs e)
        {
            MucMenu dauTien = _menu.FirstOrDefault(m => m.NutPanel.Visible);
            if (dauTien != null) ChonMuc(dauTien);
        }

        /// <summary>Bấm vào tên người dùng ở góc phải: tự đổi mật khẩu (cả ThuThu lẫn QuanTri), chỉ gọi AuthBLL.DoiMatKhau.</summary>
        private void lblNguoiDung_Click(object sender, EventArgs e)
        {
            using (var f = new frmDoiMatKhau("Đổi mật khẩu của tôi", true, (cu, moi) => AuthBLL.DoiMatKhau(cu, moi)))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    MessageBox.Show("Đã đổi mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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