using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Báo cáo doanh thu (chỉ Quản trị): chọn khoảng ngày rồi xem doanh thu theo loại thu (biểu đồ tròn)
    /// và theo ngày (biểu đồ cột). Giao diện kéo thả trong ucBaoCaoDoanhThu.Designer.cs (chữ cỡ 12);
    /// file này chỉ nạp dữ liệu vào biểu đồ/lưới. GUI chỉ gọi PhieuThuBLL.DoanhThuTheoLoai /
    /// PhieuThuBLL.DoanhThuTheoNgay — toàn bộ tính toán (GROUP BY, SUM) nằm ở PhieuThuDAL.
    /// </summary>
    public partial class ucBaoCaoDoanhThu : UserControl
    {
        // Màu cho từng loại thu, đồng bộ với bảng màu ở "Phiếu thu" (ucThongTinPhieuThu)
        private static readonly Color MauPhiThe = Theme.HangNhan;
        private static readonly Color MauPhatTre = Theme.HangCanhBao;
        private static readonly Color MauDenBu = Theme.HangCam;

        public ucBaoCaoDoanhThu()
        {
            InitializeComponent();
            BackColor = Theme.Nen;
            lblTieuDe.BackColor = MauTrangThai.Xem;
            lblTieuDe.ForeColor = Color.White;

            CauHinhLuoi();
            Load += ucBaoCaoDoanhThu_Load;
        }

        private void ucBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            dtpTu.Value = DateTime.Today.AddMonths(-1);
            dtpDen.Value = DateTime.Today;

            btnXemBaoCao.Click += (s, ev) => TaiBaoCao();
            TaiBaoCao();
        }

        private void CauHinhLuoi()
        {
            GridStyle.Apply(dgvLoai, 12F);
            GridStyle.AddFill(dgvLoai, "Loại thu", "LoaiThu", 110);
            GridStyle.AddText(dgvLoai, "Số phiếu", "SoPhieu", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgvLoai, "Tổng tiền", "TongTien", "N0đ", DataGridViewContentAlignment.MiddleRight);
            GridStyle.ToMauHang(dgvLoai, v => MauTheoLoai(Convert.ToString(v["LoaiThu"])));
        }

        private static Color? MauTheoLoai(string loaiThu)
        {
            if (loaiThu == LoaiThu.PhiThe) return MauPhiThe;
            if (loaiThu == LoaiThu.PhatTre) return MauPhatTre;
            if (loaiThu == LoaiThu.DenBu) return MauDenBu;
            return null;
        }

        private static Color MauChoDiemTron(string loaiThu)
        {
            return MauTheoLoai(loaiThu) ?? Theme.Accent;
        }

        private void TaiBaoCao()
        {
            if (dtpTu.Value.Date > dtpDen.Value.Date)
            {
                MessageBox.Show("\"Từ ngày\" không được lớn hơn \"Đến ngày\".", "Khoảng ngày không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable theoLoai = PhieuThuBLL.DoanhThuTheoLoai(dtpTu.Value, dtpDen.Value);
            DataTable theoNgay = PhieuThuBLL.DoanhThuTheoNgay(dtpTu.Value, dtpDen.Value);

            HienTongQuan(theoLoai);
            HienBieuDoLoai(theoLoai);
            HienBieuDoNgay(theoNgay);
            dgvLoai.DataSource = theoLoai;
        }

        private void HienTongQuan(DataTable theoLoai)
        {
            decimal tongTien = 0;
            int tongPhieu = 0;
            foreach (DataRow r in theoLoai.Rows)
            {
                tongTien += Convert.ToDecimal(r["TongTien"]);
                tongPhieu += Convert.ToInt32(r["SoPhieu"]);
            }

            lblTongKet.Text = string.Format("Từ {0:dd/MM/yyyy} đến {1:dd/MM/yyyy}  |  {2} phiếu thu  |  Tổng doanh thu: {3:N0}đ",
                dtpTu.Value, dtpDen.Value, tongPhieu, tongTien);
        }

        private void HienBieuDoLoai(DataTable theoLoai)
        {
            Series s = chartLoai.Series["Series1"];
            s.Points.Clear();

            if (theoLoai.Rows.Count == 0)
            {
                chartLoai.Titles.Clear();
                chartLoai.Titles.Add("Không có phiếu thu nào trong khoảng ngày đã chọn.");
                return;
            }
            chartLoai.Titles.Clear();

            foreach (DataRow r in theoLoai.Rows)
            {
                string loai = Convert.ToString(r["LoaiThu"]);
                decimal tien = Convert.ToDecimal(r["TongTien"]);
                int idx = s.Points.AddXY(loai, tien);
                s.Points[idx].LegendText = loai + " (#PERCENT{P0})";
                s.Points[idx].Color = MauChoDiemTron(loai);
            }
        }

        private void HienBieuDoNgay(DataTable theoNgay)
        {
            Series s = chartNgay.Series["Series1"];
            s.Points.Clear();

            if (theoNgay.Rows.Count == 0)
            {
                chartNgay.Titles.Clear();
                chartNgay.Titles.Add("Không có phiếu thu nào trong khoảng ngày đã chọn.");
                return;
            }
            chartNgay.Titles.Clear();

            foreach (DataRow r in theoNgay.Rows)
            {
                DateTime ngay = Convert.ToDateTime(r["Ngay"]);
                decimal tien = Convert.ToDecimal(r["TongTien"]);
                s.Points.AddXY(ngay.ToString("dd/MM"), tien);
            }
        }
    }
}
