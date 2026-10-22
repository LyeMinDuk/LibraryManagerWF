using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI.UC.Cuong
{
    /// <summary>
    /// Thẻ thư viện (BR01, BR10): mỗi độc giả tối đa một thẻ. Cấp thẻ, gia hạn thẻ (cùng lập phiếu thu phí thẻ),
    /// khóa / mở khóa thẻ, xóa thẻ. Giao diện kéo thả trong ucThe.Designer.cs (chữ cỡ 12); file này chỉ chứa xử lý sự kiện.
    /// GUI chỉ gọi TheBLL / DocGiaBLL / CauHinhBLL: hàm ghi trả về lỗi (null = thành công) thì hiện lên;
    /// luật cấp / gia hạn / xóa thẻ và việc tính ngày hết hạn nằm ở BLL.
    /// </summary>
    public partial class ucThe : UserControl
    {
        private TheThuVienDTO _the;                      // thẻ của dòng đang chọn, null nếu chưa có thẻ

        public ucThe()
        {
            InitializeComponent();
            BackColor = Theme.Nen;

            GridStyle.Apply(dgv, 12F);
            GridStyle.AddText(dgv, "Mã thẻ", "MaThe", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Độc giả", "HoTen", 180);
            GridStyle.AddText(dgv, "SĐT", "SDT");
            GridStyle.AddText(dgv, "Ngày hết hạn", "NgayHetHan", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Tình trạng thẻ", "TinhTrangThe", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Trạng thái độc giả", "TrangThaiChu", null, DataGridViewContentAlignment.MiddleCenter);

            Load += ucThe_Load;
        }

        private void ucThe_Load(object sender, EventArgs e)
        {
            cboLoc.SelectedIndex = 0;                    // chọn trước khi gắn sự kiện để khỏi nạp bảng hai lần
            lblPhiThe.Text = "Phí cấp / gia hạn thẻ: " + CauHinhSo("PHI_THE").ToString("N0") + " đ, hiệu lực "
                             + CauHinhSo("THE_SO_THANG") + " tháng (theo Cấu hình đơn giá).";

            TaiDuLieu();
        }

        // ================= Dữ liệu =================

        private static int CauHinhSo(string khoa)
        {
            DataRow[] dong = CauHinhBLL.LayTatCa().Select("Khoa = '" + khoa + "'");
            return dong.Length == 0 ? 0 : Convert.ToInt32(dong[0]["GiaTri"]);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            TaiDuLieu();
        }

        /// <summary>Nạp lại bảng (có lọc theo tình trạng thẻ), giữ dòng đang chọn theo MaDG hoặc chọn độc giả chonMa.</summary>
        private void TaiDuLieu(int chonMa = 0)
        {
            if (chonMa == 0) chonMa = MaDGDangChon();

            DataTable bang = ucDocGia.ThemCotHienThi(DocGiaBLL.TimKiem(txtTimKiem.Text));
            var view = new DataView(bang);
            if (cboLoc.SelectedIndex > 0)                // các giá trị lọc là hằng cố định (không do người dùng gõ)
                view.RowFilter = "TinhTrangThe = '" + cboLoc.SelectedItem + "'";

            dgv.DataSource = view;
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var v = row.DataBoundItem as DataRowView;
                if (v == null || chonMa == 0 || (int)v["MaDG"] != chonMa) continue;
                dgv.CurrentCell = row.Cells[0];
                row.Selected = true;
                break;
            }
            HienThongTinTheoChon();
        }

        private DataRowView DongChon()
        {
            return dgv.SelectedRows.Count > 0 ? dgv.SelectedRows[0].DataBoundItem as DataRowView : null;
        }

        private int MaDGDangChon()
        {
            DataRowView v = DongChon();
            return v == null ? 0 : (int)v["MaDG"];
        }

        // ================= Hiển thị =================

        private void HienThongTinTheoChon()
        {
            DataRowView v = DongChon();
            _the = null;
            if (v == null)
            {
                txtHoTen.Clear();
                txtMaDG.Clear();
                txtMaThe.Clear();
                txtTinhTrang.Clear();
                txtNgayCap.Clear();
                txtNgayHetHan.Clear();
            }
            else
            {
                txtHoTen.Text = v["HoTen"].ToString();
                txtMaDG.Text = v["MaDG"].ToString();
                _the = TheBLL.LayTheoDocGia((int)v["MaDG"]);
                if (_the == null)
                {
                    txtMaThe.Clear();
                    txtNgayCap.Clear();
                    txtNgayHetHan.Clear();
                    txtTinhTrang.Text = ucDocGia.ChuaCoThe;
                }
                else
                {
                    txtMaThe.Text = _the.MaThe.ToString();
                    txtNgayCap.Text = _the.NgayCap.ToString("dd/MM/yyyy");
                    txtNgayHetHan.Text = _the.NgayHetHan.ToString("dd/MM/yyyy");
                    txtTinhTrang.Text = TheBLL.TinhTrangThe(_the.TrangThai, _the.NgayHetHan);
                }
            }
            CapNhatNut();
        }

        private void CapNhatNut()
        {
            bool coDong = DongChon() != null;
            bool coThe = _the != null;
            btnCapThe.Enabled = coDong && !coThe;
            btnGiaHan.Enabled = coThe;
            btnKhoaThe.Enabled = coThe;
            btnXoaThe.Enabled = coThe;
            btnKhoaThe.Text = coThe && !_the.TrangThai ? "Mở khóa thẻ" : "Khóa thẻ";
        }

        // ================= Thao tác =================

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Thẻ thư viện", MessageBoxButtons.OK, icon);
        }

        private static string TienPhi(int phi)
        {
            return phi > 0 ? "\nĐã lập phiếu thu phí thẻ " + phi.ToString("N0") + " đ." : "";
        }

        private void btnCapThe_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null) return;
            int maDG = (int)v["MaDG"];
            string ten = v["HoTen"].ToString();
            int phi = CauHinhSo("PHI_THE");

            if (MessageBox.Show("Cấp thẻ thư viện cho \"" + ten + "\"?\nPhí thẻ " + phi.ToString("N0") + " đ, hiệu lực "
                    + CauHinhSo("THE_SO_THANG") + " tháng. Hệ thống lập phiếu thu phí thẻ.",
                    "Cấp thẻ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            btnCapThe.Enabled = false;                   // chặn bấm hai lần
            try
            {
                DateTime hetHan;
                string loi = TheBLL.CapThe(maDG, out hetHan);
                if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }

                TaiDuLieu(maDG);
                Bao("Đã cấp thẻ cho \"" + ten + "\", hạn dùng đến " + hetHan.ToString("dd/MM/yyyy") + "." + TienPhi(phi), MessageBoxIcon.Information);
            }
            finally
            {
                CapNhatNut();
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null || _the == null) return;
            int maDG = (int)v["MaDG"];
            string ten = v["HoTen"].ToString();
            int phi = CauHinhSo("PHI_THE");

            if (MessageBox.Show("Gia hạn thẻ của \"" + ten + "\"?\nPhí thẻ " + phi.ToString("N0") + " đ, thêm "
                    + CauHinhSo("THE_SO_THANG") + " tháng.\nThẻ còn hạn thì cộng thêm từ ngày hết hạn cũ, thẻ đã hết hạn thì tính từ hôm nay.",
                    "Gia hạn thẻ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            btnGiaHan.Enabled = false;                   // chặn bấm hai lần
            try
            {
                DateTime hetHanMoi;
                string loi = TheBLL.GiaHanThe(_the.MaThe, out hetHanMoi);
                if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }

                TaiDuLieu(maDG);
                Bao("Đã gia hạn thẻ của \"" + ten + "\", hạn mới " + hetHanMoi.ToString("dd/MM/yyyy") + "." + TienPhi(phi), MessageBoxIcon.Information);
            }
            finally
            {
                CapNhatNut();
            }
        }

        private void btnKhoaThe_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null || _the == null) return;
            int maDG = (int)v["MaDG"];
            string ten = v["HoTen"].ToString();
            bool dangHoatDong = _the.TrangThai;

            string hoi = dangHoatDong
                ? "Khóa thẻ của \"" + ten + "\"?\nThẻ bị khóa thì không mượn, gia hạn sách hoặc gia hạn thẻ được."
                : "Mở khóa thẻ của \"" + ten + "\"?";
            if (MessageBox.Show(hoi, dangHoatDong ? "Khóa thẻ" : "Mở khóa thẻ",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            TheBLL.DoiTrangThai(_the.MaThe, !dangHoatDong);
            TaiDuLieu(maDG);
        }

        private void btnXoaThe_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null || _the == null) return;
            int maDG = (int)v["MaDG"];
            string ten = v["HoTen"].ToString();

            if (MessageBox.Show("Xóa thẻ của \"" + ten + "\"?\nThẻ đã phát sinh giao dịch (phiếu mượn, phiếu thu) thì không xóa được, chỉ khóa.",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            string loi = TheBLL.Xoa(_the.MaThe);
            if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }
            TaiDuLieu(maDG);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLoc.SelectedIndex = 0;
            TaiDuLieu();
            txtTimKiem.Focus();
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            HienThongTinTheoChon();
        }
    }
}
