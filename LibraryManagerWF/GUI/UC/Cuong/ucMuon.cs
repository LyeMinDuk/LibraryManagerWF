using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI.UC.Cuong
{
    public partial class ucMuon : UserControl
    {
        private TheThuVienDTO _the;
        private readonly DataTable _gio = new DataTable();
        private int _toiDa, _soNgay;

        public ucMuon()
        {
            InitializeComponent();
            BackColor = Theme.Nen;
            lblTieuDe.BackColor = MauTrangThai.Xem;
            lblTieuDe.ForeColor = Color.White;
            lblThongTinThe.ForeColor = Theme.ChuPhu;

            _gio.Columns.Add("MaSach", typeof(int));
            _gio.Columns.Add("TenSach", typeof(string));
            _gio.Columns.Add("TacGia", typeof(string));

            GridStyle.Apply(dgvDocGia, 12F);
            GridStyle.AddText(dgvDocGia, "Mã ĐG", "MaDG", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgvDocGia, "Họ tên", "HoTen", 150);
            GridStyle.AddText(dgvDocGia, "SĐT", "SDT");
            GridStyle.AddText(dgvDocGia, "Mã thẻ", "MaThe", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgvDocGia, "Ngày hết hạn", "NgayHetHan", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgvDocGia, "Tình trạng thẻ", "TinhTrangThe", null, DataGridViewContentAlignment.MiddleCenter);

            GridStyle.Apply(dgvSach, 12F);
            GridStyle.AddText(dgvSach, "Mã", "MaSach", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgvSach, "Tên sách", "TenSach", 120);
            GridStyle.AddFill(dgvSach, "Tác giả", "TacGia", 90);
            GridStyle.AddText(dgvSach, "Còn", "SoLuongCon", null, DataGridViewContentAlignment.MiddleCenter);

            GridStyle.Apply(dgvPhieu, 12F);
            GridStyle.AddText(dgvPhieu, "Mã", "MaSach", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgvPhieu, "Tên sách", "TenSach", 120);
            GridStyle.AddFill(dgvPhieu, "Tác giả", "TacGia", 90);
            dgvPhieu.DataSource = _gio;

            Load += ucMuon_Load;
        }

        private void ucMuon_Load(object sender, EventArgs e)
        {
            _toiDa = CauHinhSo("MUON_TOI_DA");
            _soNgay = CauHinhSo("MUON_SO_NGAY");
            TaiDocGia();
            TaiSach();
            HienGio();
        }

        private static void PhimEnter(KeyEventArgs e, Action lam)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            e.SuppressKeyPress = true;
            lam();
        }

        private static int CauHinhSo(string khoa)
        {
            DataRow[] dong = CauHinhBLL.LayTatCa().Select("Khoa = '" + khoa + "'");
            return dong.Length == 0 ? 0 : Convert.ToInt32(dong[0]["GiaTri"]);
        }

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Cho mượn", MessageBoxButtons.OK, icon);
        }

        private DataRowView DocGiaChon()
        {
            return dgvDocGia.SelectedRows.Count > 0 ? dgvDocGia.SelectedRows[0].DataBoundItem as DataRowView : null;
        }

        private void TaiDocGia()
        {
            DataRowView cu = DocGiaChon();
            int chonMa = cu == null ? 0 : (int)cu["MaDG"];

            dgvDocGia.DataSource = ucDocGia.ThemCotHienThi(DocGiaBLL.TimKiem(txtTimDG.Text));
            dgvDocGia.ClearSelection();
            foreach (DataGridViewRow row in dgvDocGia.Rows)
            {
                var v = row.DataBoundItem as DataRowView;
                if (v == null || chonMa == 0 || (int)v["MaDG"] != chonMa)
                    continue;
                dgvDocGia.CurrentCell = row.Cells[0];
                row.Selected = true;
                break;
            }
            HienThongTinThe();
        }

        private void HienThongTinThe()
        {
            DataRowView v = DocGiaChon();
            _the = null;
            if (v == null)
            {
                lblThongTinThe.Text = "Chọn một độc giả để lập phiếu mượn.";
                return;
            }

            string ten = v["HoTen"].ToString();
            if (!(bool)v["TrangThai"])
            {
                lblThongTinThe.Text = "Độc giả \"" + ten + "\" đang bị khóa, không mượn được.";
                return;
            }

            _the = TheBLL.LayTheoDocGia((int)v["MaDG"]);
            if (_the == null)
            {
                lblThongTinThe.Text = "Độc giả \"" + ten + "\" chưa có thẻ. Hãy cấp thẻ ở tab \"Thẻ thư viện\" trước.";
                return;
            }

            string tinhTrang = TheBLL.TinhTrangThe(_the.TrangThai, _the.NgayHetHan);
            int dangMuon = MuonBLL.DanhSachMuon("", _the.MaThe, 1).Rows.Count;
            int quaHan = MuonBLL.DanhSachMuon("", _the.MaThe, 2).Rows.Count;
            lblThongTinThe.Text = "Thẻ " + _the.MaThe + ": " + tinhTrang + ", hạn " + _the.NgayHetHan.ToString("dd/MM/yyyy")
                                  + "  |  đang mượn " + dangMuon + "/" + _toiDa + " cuốn"
                                  + (quaHan > 0 ? "  |  " + quaHan + " cuốn quá hạn (phải trả trước khi mượn)" : "");
        }

        private void TaiSach()
        {
            var view = new DataView(SachBLL.TimKiem(txtTimSach.Text, 0, 1));
            string loc = "SoLuongCon > 0";
            if (_gio.Rows.Count > 0)
                loc += " AND MaSach NOT IN (" + string.Join(",", _gio.Rows.Cast<DataRow>().Select(r => ((int)r["MaSach"]).ToString())) + ")";
            view.RowFilter = loc;
            dgvSach.DataSource = view;
            dgvSach.ClearSelection();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            DataRowView v = dgvSach.SelectedRows.Count > 0 ? dgvSach.SelectedRows[0].DataBoundItem as DataRowView : null;
            if (v == null)
            {
                Bao("Hãy chọn một cuốn sách trong danh sách bên trái.", MessageBoxIcon.Information);
                return;
            }

            _gio.Rows.Add((int)v["MaSach"], v["TenSach"].ToString(), v["TacGia"].ToString());
            HienGio();
            TaiSach();
        }

        private void HienGio()
        {
            int n = _gio.Rows.Count;
            lblTongKet.Text = (n == 0 ? "Phiếu chưa có cuốn nào." : "Phiếu có " + n + " cuốn.")
                              + "\nHạn mức " + _toiDa + " cuốn/thẻ, mượn " + _soNgay + " ngày (theo Cấu hình đơn giá).";
            btnBoSach.Enabled = n > 0;
            btnBoHet.Enabled = n > 0;
            btnLapPhieu.Enabled = n > 0;
        }

        private void btnBoSach_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0)
            {
                Bao("Hãy chọn cuốn cần bỏ khỏi phiếu.", MessageBoxIcon.Information);
                return;
            }
            var v = dgvPhieu.SelectedRows[0].DataBoundItem as DataRowView;
            if (v == null)
                return;
            v.Row.Delete();
            _gio.AcceptChanges();
            HienGio();
            TaiSach();
        }

        private void btnBoHet_Click(object sender, EventArgs e)
        {
            if (_gio.Rows.Count == 0)
                return;
            if (MessageBox.Show("Bỏ hết " + _gio.Rows.Count + " cuốn khỏi phiếu?", "Cho mượn",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            _gio.Clear();
            HienGio();
            TaiSach();
        }

        private void btnTimDG_Click(object sender, EventArgs e)
        {
            TaiDocGia();
        }

        private void txtTimDG_KeyDown(object sender, KeyEventArgs e)
        {
            PhimEnter(e, TaiDocGia);
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            TaiSach();
        }

        private void dgvDocGia_SelectionChanged(object sender, EventArgs e)
        {
            HienThongTinThe();
        }

        private void txtTimSach_KeyDown(object sender, KeyEventArgs e)
        {
            PhimEnter(e, TaiSach);
        }

        private void dgvSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
                btnThemSach.PerformClick();
        }

        private void dgvPhieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnBoSach.PerformClick();
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            DataRowView v = DocGiaChon();
            if (v == null)
            {
                Bao("Hãy chọn độc giả ở bảng phía trên.", MessageBoxIcon.Information);
                return;
            }
            if (_the == null)
            {
                Bao(lblThongTinThe.Text, MessageBoxIcon.Warning);
                return;
            }
            if (_gio.Rows.Count == 0)
            {
                Bao("Phiếu chưa có cuốn nào.", MessageBoxIcon.Information);
                return;
            }

            string ten = v["HoTen"].ToString();
            int soCuon = _gio.Rows.Count;
            if (MessageBox.Show("Lập phiếu mượn " + soCuon + " cuốn cho \"" + ten + "\" (thẻ " + _the.MaThe + ")?",
                    "Lập phiếu mượn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            btnLapPhieu.Enabled = false;
            try
            {
                List<int> ds = _gio.Rows.Cast<DataRow>().Select(r => (int)r["MaSach"]).ToList();
                DateTime hanTra;
                string loi = MuonBLL.Muon(_the.MaThe, ds, out hanTra);
                if (loi != null)
                {
                    Bao(loi, MessageBoxIcon.Warning);
                    return;
                }

                _gio.Clear();
                TaiSach();
                HienThongTinThe();
                Bao("Đã lập phiếu mượn " + soCuon + " cuốn cho \"" + ten + "\".\nHạn trả: " + hanTra.ToString("dd/MM/yyyy") + ".", MessageBoxIcon.Information);
            }
            finally
            {
                HienGio();
            }
        }
    }
}
