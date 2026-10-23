using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI.UC.Duc
{
    public partial class ucSach : UserControl
    {
        private EditState _st = EditState.Read;
        private int _maDangSua;
        private bool _dangNap;

        public ucSach()
        {
            InitializeComponent();
            BackColor = Theme.Nen;
            lblTieuDe.Font = new Font(Font, FontStyle.Bold);

            GridStyle.Apply(dgv, 12F);
            GridStyle.AddText(dgv, "Mã", "MaSach", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Tên sách", "TenSach", 200);
            GridStyle.AddFill(dgv, "Tác giả", "TacGia", 150);
            GridStyle.AddText(dgv, "Thể loại", "TenTL");
            GridStyle.AddText(dgv, "NXB", "NXB");
            GridStyle.AddText(dgv, "Năm XB", "NamXB", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Giá bìa", "GiaBia", "N0'đ'", DataGridViewContentAlignment.MiddleRight);
            GridStyle.AddText(dgv, "Tổng", "SoLuongTong", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Còn", "SoLuongCon", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Trạng thái", "TrangThai", null, DataGridViewContentAlignment.MiddleCenter);

            Load += ucSach_Load;
        }

        private void ucSach_Load(object sender, EventArgs e)
        {
            NapComboTheLoai();

            foreach (Control o in new Control[] { txtTenSach, txtTacGia, txtNXB, txtNamXB, nudGiaBia, nudSoLuongTong })
                o.KeyDown += oNhap_KeyDown;

            TaiDuLieu();
            DatTrangThai(EditState.Read);
        }

        private void NapComboTheLoai()
        {
            _dangNap = true;
            try
            {
                DataTable ds = TheLoaiBLL.LayTatCa();

                DataTable loc = ds.Copy();
                DataRow tatCa = loc.NewRow();
                tatCa["MaTL"] = 0;
                tatCa["TenTL"] = "Tất cả thể loại";
                loc.Rows.InsertAt(tatCa, 0);
                cboLocTheLoai.DisplayMember = "TenTL";
                cboLocTheLoai.ValueMember = "MaTL";
                cboLocTheLoai.DataSource = loc;

                cboTheLoai.DisplayMember = "TenTL";
                cboTheLoai.ValueMember = "MaTL";
                cboTheLoai.DataSource = ds.Copy();
                cboTheLoai.SelectedIndex = -1;

                cboLocTrangThai.SelectedIndex = 0;
            }
            finally
            {
                _dangNap = false;
            }
        }

        private void DatLaiBoLoc()
        {
            _dangNap = true;
            try
            {
                txtTimKiem.Clear();
                if (cboLocTheLoai.Items.Count > 0)
                    cboLocTheLoai.SelectedIndex = 0;
                cboLocTrangThai.SelectedIndex = 0;
            }
            finally
            {
                _dangNap = false;
            }
        }

        private static int MaChon(ComboBox c)
        {
            object o = c.SelectedValue;
            return (o == null || o is DataRowView) ? 0 : Convert.ToInt32(o);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            e.SuppressKeyPress = true;
            TaiDuLieu();
        }

        private void oNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || _st == EditState.Read)
                return;
            e.SuppressKeyPress = true;
            btnXacNhan.PerformClick();
        }

        private void TaiDuLieu(int chonMa = 0, string chonTen = null)
        {
            if (chonMa == 0 && chonTen == null)
                chonMa = MaDangChon();

            int trangThai = cboLocTrangThai.SelectedIndex == 1 ? 1 : (cboLocTrangThai.SelectedIndex == 2 ? 0 : -1);
            dgv.DataSource = SachBLL.TimKiem(txtTimKiem.Text.Trim(), MaChon(cboLocTheLoai), trangThai);
            dgv.ClearSelection();

            DataGridViewRow chon = null;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var v = row.DataBoundItem as DataRowView;
                if (v == null)
                    continue;
                bool khop = (chonMa > 0 && (int)v["MaSach"] == chonMa)
                            || (chonTen != null && string.Equals(v["TenSach"].ToString(), chonTen, StringComparison.OrdinalIgnoreCase));
                if (!khop)
                    continue;
                chon = row;
                if (chonMa > 0)
                    break;
            }
            if (chon != null)
            {
                dgv.CurrentCell = chon.Cells[0];
                chon.Selected = true;
            }
            HienThongTinTheoChon();
        }

        private DataRowView DongChon()
        {
            return dgv.SelectedRows.Count > 0 ? dgv.SelectedRows[0].DataBoundItem as DataRowView : null;
        }

        private int MaDangChon()
        {
            DataRowView v = DongChon();
            return v == null ? 0 : (int)v["MaSach"];
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dgv.Columns[e.ColumnIndex].Name != "TrangThai")
                return;
            var v = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v == null)
                return;
            e.Value = (bool)v["TrangThai"] ? "Hoạt động" : "Đã khóa";
            e.FormattingApplied = true;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_st == EditState.Read)
                HienThongTinTheoChon();
        }

        private void HienThongTinTheoChon()
        {
            DataRowView v = DongChon();
            if (v == null)
            {
                XoaONhap();
            }
            else
            {
                txtTenSach.Text = v["TenSach"].ToString();
                txtTacGia.Text = v["TacGia"].ToString();
                cboTheLoai.SelectedValue = (int)v["MaTL"];
                txtNXB.Text = v["NXB"] == DBNull.Value ? "" : v["NXB"].ToString();
                txtNamXB.Text = v["NamXB"] == DBNull.Value ? "" : v["NamXB"].ToString();
                nudGiaBia.Value = Math.Min(nudGiaBia.Maximum, Convert.ToDecimal(v["GiaBia"]));
                nudSoLuongTong.Value = Math.Min(nudSoLuongTong.Maximum, Convert.ToInt32(v["SoLuongTong"]));
                txtSoLuongCon.Text = v["SoLuongCon"].ToString();
            }
            CapNhatNut();
        }

        private void XoaONhap()
        {
            txtTenSach.Clear();
            txtTacGia.Clear();
            cboTheLoai.SelectedIndex = -1;
            txtNXB.Clear();
            txtNamXB.Clear();
            nudGiaBia.Value = 0;
            nudSoLuongTong.Value = 0;
            txtSoLuongCon.Clear();
        }

        private void CapNhatNut()
        {
            DataRowView v = DongChon();
            bool coDong = v != null;
            bool hoatDong = coDong && (bool)v["TrangThai"];

            btnThem.Enabled = true;
            btnSua.Enabled = coDong;
            btnKhoa.Enabled = coDong;
            btnKhoa.Text = (coDong && !hoatDong) ? "Mở khóa" : "Khóa sách";
            btnXoa.Enabled = coDong;
        }

        private void DatTrangThai(EditState st)
        {
            _st = st;
            bool dangNhap = st != EditState.Read;

            StatusRequestEventArgs tt = MauTrangThai.Tao(st, "sách", "THÔNG TIN SÁCH");
            lblTieuDe.Text = tt.TitleText;
            lblTieuDe.BackColor = tt.BackColor;
            lblTieuDe.ForeColor = tt.ForeColor;

            txtTenSach.ReadOnly = !dangNhap;
            txtTacGia.ReadOnly = !dangNhap;
            cboTheLoai.Enabled = dangNhap;
            txtNXB.ReadOnly = !dangNhap;
            txtNamXB.ReadOnly = !dangNhap;
            nudGiaBia.ReadOnly = !dangNhap;
            nudSoLuongTong.ReadOnly = !dangNhap;

            dgv.Enabled = !dangNhap;
            gbTimKiem.Enabled = !dangNhap;
            foreach (Button b in new[] { btnThem, btnSua, btnKhoa, btnXoa })
                b.Visible = !dangNhap;
            btnXacNhan.Visible = dangNhap;
            btnHuy.Visible = dangNhap;

            if (!dangNhap)
                HienThongTinTheoChon();
        }

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Sách", MessageBoxButtons.OK, icon);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DatTrangThai(EditState.Create);
            XoaONhap();
            nudSoLuongTong.Value = 1;
            txtTenSach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null)
                return;
            _maDangSua = (int)v["MaSach"];
            DatTrangThai(EditState.Update);
            txtTenSach.Focus();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;
            try
            {
                int? nam = null;
                string namChu = txtNamXB.Text.Trim();
                if (namChu.Length > 0)
                {
                    int n;
                    if (!int.TryParse(namChu, out n))
                    {
                        Bao("Năm xuất bản phải là số.", MessageBoxIcon.Warning);
                        txtNamXB.Focus();
                        return;
                    }
                    nam = n;
                }

                var s = new SachDTO
                {
                    MaSach = _st == EditState.Update ? _maDangSua : 0,
                    TenSach = txtTenSach.Text,
                    TacGia = txtTacGia.Text,
                    MaTL = MaChon(cboTheLoai),
                    NXB = txtNXB.Text,
                    NamXB = nam,
                    GiaBia = nudGiaBia.Value,
                    SoLuongTong = (int)nudSoLuongTong.Value
                };

                if (_st == EditState.Create)
                {
                    string loi = SachBLL.Them(s);
                    if (loi != null)
                    {
                        Bao(loi, MessageBoxIcon.Warning);
                        return;
                    }

                    string tenMoi = s.TenSach.Trim();
                    DatLaiBoLoc();
                    DatTrangThai(EditState.Read);
                    TaiDuLieu(0, tenMoi);
                    Bao("Đã thêm sách \"" + tenMoi + "\".", MessageBoxIcon.Information);
                }
                else if (_st == EditState.Update)
                {
                    string loi = SachBLL.Sua(s);
                    if (loi != null)
                    {
                        Bao(loi, MessageBoxIcon.Warning);
                        return;
                    }

                    DatTrangThai(EditState.Read);
                    TaiDuLieu(_maDangSua);
                }
            }
            finally
            {
                btnXacNhan.Enabled = true;
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null)
                return;
            int ma = (int)v["MaSach"];
            string ten = v["TenSach"].ToString();
            bool dangHoatDong = (bool)v["TrangThai"];

            string hoi = dangHoatDong
                ? "Khóa sách \"" + ten + "\"?\nSách bị khóa sẽ không cho mượn cho đến khi được mở khóa."
                : "Mở khóa sách \"" + ten + "\"?";
            if (MessageBox.Show(hoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            SachBLL.DoiTrangThai(ma, !dangHoatDong);
            TaiDuLieu(ma);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null)
                return;
            int ma = (int)v["MaSach"];
            string ten = v["TenSach"].ToString();

            if (MessageBox.Show("Xóa vĩnh viễn sách \"" + ten + "\"?\nSách đã có giao dịch mượn thì không xóa được, chỉ khóa.",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            string loi = SachBLL.Xoa(ma);
            if (loi != null)
            {
                Bao(loi, MessageBoxIcon.Warning);
                return;
            }
            TaiDuLieu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DatLaiBoLoc();
            TaiDuLieu();
            txtTimKiem.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DatTrangThai(EditState.Read);
        }

        private void cboLocTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dangNap)
                TaiDuLieu();
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dangNap)
                TaiDuLieu();
        }
    }
}
