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
    /// <summary>
    /// Cho mượn (BR02, BR04, BR05): chọn độc giả (có thẻ) → chọn sách còn trong kho → lập phiếu mượn.
    /// Giao diện kéo thả trong ucMuon.Designer.cs (chữ cỡ 12); file này chỉ chứa xử lý sự kiện.
    /// GUI chỉ gọi MuonBLL / TheBLL / DocGiaBLL / SachBLL / CauHinhBLL: điều kiện được mượn, hạn mức, hạn trả,
    /// trừ kho đều do MuonBLL.Muon xử lý trong một transaction; GUI chỉ hiện lỗi BLL trả về.
    /// Màu hàng ở bảng độc giả: vàng = chưa có thẻ, đỏ = thẻ hết hạn, xám = độc giả / thẻ bị khóa.
    /// </summary>
    public partial class ucMuon : UserControl
    {
        private TheThuVienDTO _the;                          // thẻ của độc giả đang chọn, null nếu chưa có thẻ
        private readonly DataTable _gio = new DataTable();   // sách đã chọn cho phiếu mượn
        private int _toiDa, _soNgay;                         // chỉ để hiển thị; BLL mới là nơi áp dụng luật

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
            GridStyle.ToMauHang(dgvDocGia, v =>
            {
                string tt = v["TinhTrangThe"].ToString();
                if (!(bool)v["TrangThai"] || tt == "Khóa") return Theme.HangKhoa;
                if (tt == "Hết hạn") return Theme.HangLoi;
                if (tt == ucDocGia.ChuaCoThe) return Theme.HangCanhBao;
                return null;
            });

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

            btnTimDG.Click += (s, ev) => TaiDocGia();
            txtTimDG.KeyDown += (s, ev) => PhimEnter(ev, TaiDocGia);
            dgvDocGia.SelectionChanged += (s, ev) => HienThongTinThe();

            btnTimSach.Click += (s, ev) => TaiSach();
            txtTimSach.KeyDown += (s, ev) => PhimEnter(ev, TaiSach);
            btnThemSach.Click += btnThemSach_Click;
            dgvSach.CellDoubleClick += (s, ev) => { if (ev.RowIndex >= 0) btnThemSach.PerformClick(); };

            btnBoSach.Click += btnBoSach_Click;
            btnBoHet.Click += btnBoHet_Click;
            btnLapPhieu.Click += btnLapPhieu_Click;
            dgvPhieu.CellDoubleClick += (s, ev) => { if (ev.RowIndex >= 0) btnBoSach.PerformClick(); };

            TaiDocGia();
            TaiSach();
            HienGio();
        }

        private static void PhimEnter(KeyEventArgs e, Action lam)
        {
            if (e.KeyCode != Keys.Enter) return;
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

        // ================= Độc giả =================

        private DataRowView DocGiaChon()
        {
            return dgvDocGia.SelectedRows.Count > 0 ? dgvDocGia.SelectedRows[0].DataBoundItem as DataRowView : null;
        }

        /// <summary>Nạp lại bảng độc giả, giữ độc giả đang chọn (theo MaDG).</summary>
        private void TaiDocGia()
        {
            DataRowView cu = DocGiaChon();
            int chonMa = cu == null ? 0 : (int)cu["MaDG"];

            dgvDocGia.DataSource = ucDocGia.ThemCotHienThi(DocGiaBLL.TimKiem(txtTimDG.Text));
            dgvDocGia.ClearSelection();
            foreach (DataGridViewRow row in dgvDocGia.Rows)
            {
                var v = row.DataBoundItem as DataRowView;
                if (v == null || chonMa == 0 || (int)v["MaDG"] != chonMa) continue;
                dgvDocGia.CurrentCell = row.Cells[0];
                row.Selected = true;
                break;
            }
            HienThongTinThe();
        }

        /// <summary>Lấy thẻ của độc giả đang chọn và hiện tình trạng, số cuốn đang mượn, số cuốn quá hạn.</summary>
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

        // ================= Sách =================

        /// <summary>Nạp sách đang hoạt động, còn trong kho và chưa nằm trong phiếu.</summary>
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
            if (v == null) { Bao("Hãy chọn một cuốn sách trong danh sách bên trái.", MessageBoxIcon.Information); return; }

            _gio.Rows.Add((int)v["MaSach"], v["TenSach"].ToString(), v["TacGia"].ToString());
            HienGio();
            TaiSach();
        }

        // ================= Phiếu mượn =================

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
            if (dgvPhieu.SelectedRows.Count == 0) { Bao("Hãy chọn cuốn cần bỏ khỏi phiếu.", MessageBoxIcon.Information); return; }
            var v = dgvPhieu.SelectedRows[0].DataBoundItem as DataRowView;
            if (v == null) return;
            v.Row.Delete();
            _gio.AcceptChanges();
            HienGio();
            TaiSach();
        }

        private void btnBoHet_Click(object sender, EventArgs e)
        {
            if (_gio.Rows.Count == 0) return;
            if (MessageBox.Show("Bỏ hết " + _gio.Rows.Count + " cuốn khỏi phiếu?", "Cho mượn",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            _gio.Clear();
            HienGio();
            TaiSach();
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            DataRowView v = DocGiaChon();
            if (v == null) { Bao("Hãy chọn độc giả ở bảng phía trên.", MessageBoxIcon.Information); return; }
            if (_the == null) { Bao(lblThongTinThe.Text, MessageBoxIcon.Warning); return; }
            if (_gio.Rows.Count == 0) { Bao("Phiếu chưa có cuốn nào.", MessageBoxIcon.Information); return; }

            string ten = v["HoTen"].ToString();
            int soCuon = _gio.Rows.Count;
            if (MessageBox.Show("Lập phiếu mượn " + soCuon + " cuốn cho \"" + ten + "\" (thẻ " + _the.MaThe + ")?",
                    "Lập phiếu mượn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            btnLapPhieu.Enabled = false;                    // chặn bấm hai lần
            try
            {
                List<int> ds = _gio.Rows.Cast<DataRow>().Select(r => (int)r["MaSach"]).ToList();
                DateTime hanTra;
                string loi = MuonBLL.Muon(_the.MaThe, ds, out hanTra);
                if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }

                _gio.Clear();
                TaiSach();                                  // kho đã đổi
                HienThongTinThe();                          // số cuốn đang mượn đã đổi
                Bao("Đã lập phiếu mượn " + soCuon + " cuốn cho \"" + ten + "\".\nHạn trả: " + hanTra.ToString("dd/MM/yyyy") + ".", MessageBoxIcon.Information);
            }
            finally
            {
                HienGio();
            }
        }
    }
}
