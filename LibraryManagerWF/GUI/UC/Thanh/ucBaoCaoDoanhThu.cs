using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        // Dữ liệu của lần xem báo cáo gần nhất, dùng lại khi xuất Excel
        private DataTable _theoLoai;
        private DataTable _theoNgay;

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
            btnXuatExcel.Click += btnXuatExcel_Click;
            TaiBaoCao();
        }

        private void CauHinhLuoi()
        {
            GridStyle.Apply(dgvLoai, 12F);
            GridStyle.AddFill(dgvLoai, "Loại thu", "LoaiThu", 110);
            GridStyle.AddText(dgvLoai, "Số phiếu", "SoPhieu", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgvLoai, "Tổng tiền", "TongTien", "N0đ", DataGridViewContentAlignment.MiddleRight);
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

        /// <summary>Nạp báo cáo theo khoảng ngày đang chọn. Trả về false nếu khoảng ngày không hợp lệ.</summary>
        private bool TaiBaoCao()
        {
            if (dtpTu.Value.Date > dtpDen.Value.Date)
            {
                MessageBox.Show("\"Từ ngày\" không được lớn hơn \"Đến ngày\".", "Khoảng ngày không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DataTable theoLoai = PhieuThuBLL.DoanhThuTheoLoai(dtpTu.Value, dtpDen.Value);
            DataTable theoNgay = PhieuThuBLL.DoanhThuTheoNgay(dtpTu.Value, dtpDen.Value);

            HienTongQuan(theoLoai);
            HienBieuDoLoai(theoLoai);
            HienBieuDoNgay(theoNgay);
            dgvLoai.DataSource = theoLoai;

            _theoLoai = theoLoai;
            _theoNgay = theoNgay;
            return true;
        }

        /// <summary>
        /// Xuất báo cáo các ngày đang chọn ra Excel, tên file gợi ý: bcdt_tungay_denngay.xlsx
        /// (vd: bcdt_22-09-2026_22-10-2026.xlsx). Phần vẽ file nằm ở ExcelBaoCaoDoanhThu.
        /// </summary>
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Nạp lại theo đúng khoảng ngày trên màn hình (kể cả khi chưa bấm "Xem báo cáo")
            if (!TaiBaoCao()) return;

            DateTime tu = dtpTu.Value.Date;
            DateTime den = dtpDen.Value.Date;
            string duongDan;

            using (var hop = new SaveFileDialog())
            {
                hop.Title = "Xuất báo cáo doanh thu";
                hop.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                hop.DefaultExt = "xlsx";
                hop.AddExtension = true;
                hop.OverwritePrompt = true;
                hop.FileName = string.Format("bcdt_{0:dd-MM-yyyy}_{1:dd-MM-yyyy}.xlsx", tu, den);
                if (hop.ShowDialog(this) != DialogResult.OK) return;
                duongDan = hop.FileName;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable chiTiet = PhieuThuBLL.TimKiem(tu, den, "");
                ExcelBaoCaoDoanhThu.Xuat(duongDan, tu, den, _theoLoai, _theoNgay, chiTiet);
            }
            catch (IOException)
            {
                MessageBox.Show("Không ghi được file. Có thể file đang được mở trong Excel hoặc thư mục không cho ghi.\nHãy đóng file đó (hoặc chọn tên/thư mục khác) rồi xuất lại.",
                    "Xuất Excel thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất Excel thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (MessageBox.Show("Đã xuất báo cáo:\n" + duongDan + "\n\nMở file ngay?", "Xuất Excel thành công",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                Process.Start(duongDan);
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

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            TaiBaoCao();
        }
    }
}
