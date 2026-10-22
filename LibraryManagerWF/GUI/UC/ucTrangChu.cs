using System;
using System.Globalization;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Trang chủ: lời chào và thống kê nhanh. Giao diện kéo thả trong ucTrangChu.Designer.cs,
    /// ở đây chỉ gọi ThongKeBLL rồi gán chữ. Doanh thu chỉ hiện cho quản trị.
    /// </summary>
    public partial class ucTrangChu : UserControl
    {
        private static readonly CultureInfo VN = new CultureInfo("vi-VN");

        public ucTrangChu()
        {
            InitializeComponent();
        }

        private void ucTrangChu_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;   // mở trong Designer thì không gọi CSDL
            TaiThongKe();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiThongKe();
        }

        private void TaiThongKe()
        {
            ThongKeDTO tk = ThongKeBLL.LayThongKeTrangChu();

            lblSachSo.Text = tk.DauSachHoatDong.ToString("N0", VN);
            lblCuonSo.Text = tk.CuonConTrenKe.ToString("N0", VN);
            lblCuonChu.Text = "Cuốn còn trên kệ (tổng " + tk.TongCuon.ToString("N0", VN) + ")";
            lblDocGiaSo.Text = tk.DocGiaHoatDong.ToString("N0", VN);
            lblTheSo.Text = tk.TheConHieuLuc.ToString("N0", VN);
            lblDangMuonSo.Text = tk.DangMuon.ToString("N0", VN);
            lblQuaHanSo.Text = tk.QuaHan.ToString("N0", VN);
            lblMuonNaySo.Text = tk.MuonHomNay.ToString("N0", VN);
            lblTraNaySo.Text = tk.TraHomNay.ToString("N0", VN);

            // Doanh thu chỉ dành cho quản trị: thủ thư thì thu hàng đó lại (cao 0)
            bool laQuanTri = AppSession.LaQuanTri;
            pnlDtNgay.Visible = laQuanTri;
            pnlDtThang.Visible = laQuanTri;
            tlp.RowStyles[2].Height = laQuanTri ? 120F : 0F;
            if (laQuanTri)
            {
                lblDtNgaySo.Text = (tk.DoanhThuHomNay ?? 0m).ToString("N0", VN) + " đ";
                lblDtThangSo.Text = (tk.DoanhThuThangNay ?? 0m).ToString("N0", VN) + " đ";
            }

            string vaiTro = laQuanTri ? "Quản trị viên" : "Thủ thư";
            lblNguoiDung.Text = AppSession.HoTen + " (" + vaiTro + ")   |   Hôm nay: " +
                                DateTime.Today.ToString("dd/MM/yyyy") + "   |   Cập nhật lúc " +
                                DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
