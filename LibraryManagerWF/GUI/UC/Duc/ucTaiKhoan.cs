using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI.UC.Duc
{
    public partial class ucTaiKhoan : UserControl
    {
        public sealed class MucVaiTro
        {
            public string Gia { get; private set; }
            public string Hien { get; private set; }
            public MucVaiTro(string gia, string hien)
            {
                Gia = gia;
                Hien = hien;
            }
        }

        private DataTable _bang;
        private EditState _st = EditState.Read;
        private int _maDangSua;

        public ucTaiKhoan()
        {
            InitializeComponent();
            Font = new Font("Microsoft Sans Serif", 12F);
            BackColor = Theme.Nen;
            lblTieuDe.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);

            cboVaiTro.DataSource = new[] { new MucVaiTro(VaiTro.ThuThu, "Thủ thư"), new MucVaiTro(VaiTro.QuanTri, "Quản trị viên") };
            cboVaiTro.DisplayMember = "Hien";
            cboVaiTro.ValueMember = "Gia";

            GridStyle.Apply(dgv);
            GridStyle.AddText(dgv, "Mã TK", "MaTK", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Tên đăng nhập", "TenDN");
            GridStyle.AddFill(dgv, "Họ tên", "HoTen", 180);
            GridStyle.AddText(dgv, "Vai trò", "VaiTro");
            GridStyle.AddText(dgv, "Trạng thái", "TrangThai", null, DataGridViewContentAlignment.MiddleCenter);

            Load += ucTaiKhoan_Load;
        }

        private void ucTaiKhoan_Load(object sender, EventArgs e)
        {
            txtMatKhau.KeyDown += oNhap_KeyDown;
            dgv.SelectionChanged += dgv_SelectionChanged;
            dgv.CellFormatting += dgv_CellFormatting;
            btnXacNhan.Click += btnXacNhan_Click;
            btnHuy.Click += (s, ev) => DatTrangThai(EditState.Read);

            TaiDuLieu();
            DatTrangThai(EditState.Read);
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

        private static bool Chua(object o, string tuKhoa)
        {
            return o != null && o.ToString().IndexOf(tuKhoa, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void TaiDuLieu(int chonMa = 0, string chonTenDN = null)
        {
            if (chonMa == 0 && chonTenDN == null)
                chonMa = MaDangChon();

            _bang = TaiKhoanBLL.LayTatCa();
            var view = new DataView(_bang);

            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa.Length > 0)
            {
                var ids = _bang.Rows.Cast<DataRow>()
                    .Where(r => Chua(r["TenDN"], tuKhoa) || Chua(r["HoTen"], tuKhoa))
                    .Select(r => ((int)r["MaTK"]).ToString())
                    .ToList();
                view.RowFilter = ids.Count == 0 ? "1 = 0" : "MaTK IN (" + string.Join(",", ids) + ")";
            }

            dgv.DataSource = view;
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var v = row.DataBoundItem as DataRowView;
                if (v == null)
                    continue;
                bool khop = (chonMa > 0 && (int)v["MaTK"] == chonMa)
                            || (chonTenDN != null && string.Equals(v["TenDN"].ToString(), chonTenDN, StringComparison.OrdinalIgnoreCase));
                if (!khop)
                    continue;
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

        private int MaDangChon()
        {
            DataRowView v = DongChon();
            return v == null ? 0 : (int)v["MaTK"];
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var v = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v == null)
                return;

            string cot = dgv.Columns[e.ColumnIndex].Name;
            if (cot == "VaiTro")
            {
                e.Value = v["VaiTro"].ToString() == VaiTro.QuanTri ? "Quản trị viên" : "Thủ thư";
                e.FormattingApplied = true;
            }
            else if (cot == "TrangThai")
            {
                e.Value = (bool)v["TrangThai"] ? "Hoạt động" : "Đã khóa";
                e.FormattingApplied = true;
            }
            else if (cot == "TenDN" && (int)v["MaTK"] == AppSession.MaTK)
            {
                e.Value = v["TenDN"] + "  (bạn)";
                e.FormattingApplied = true;
            }

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
                txtTenDN.Clear();
                txtHoTen.Clear();
                cboVaiTro.SelectedIndex = -1;
                txtTrangThai.Clear();
            }
            else
            {
                txtTenDN.Text = v["TenDN"].ToString();
                txtHoTen.Text = v["HoTen"].ToString();
                cboVaiTro.SelectedValue = v["VaiTro"].ToString();
                txtTrangThai.Text = (bool)v["TrangThai"] ? "Hoạt động" : "Đã khóa";
            }
            CapNhatNut();
        }

        private void CapNhatNut()
        {
            DataRowView v = DongChon();
            bool coDong = v != null;
            bool laMinh = coDong && (int)v["MaTK"] == AppSession.MaTK;
            bool hoatDong = coDong && (bool)v["TrangThai"];

            btnThem.Enabled = true;
            btnSua.Enabled = coDong && !laMinh;
            btnDatLai.Enabled = coDong;
            btnKhoa.Enabled = coDong && !laMinh;
            btnKhoa.Text = (coDong && !hoatDong) ? "Mở khóa" : "Khóa";
            btnXoa.Enabled = coDong && !laMinh;
            btnDoiMkToi.Enabled = true;
        }

        private void DatTrangThai(EditState st)
        {
            _st = st;
            bool dangNhap = st != EditState.Read;

            StatusRequestEventArgs tt = MauTrangThai.Tao(st, "tài khoản", "THÔNG TIN TÀI KHOẢN");
            lblTieuDe.Text = tt.TitleText;
            lblTieuDe.BackColor = tt.BackColor;
            lblTieuDe.ForeColor = tt.ForeColor;

            txtTenDN.ReadOnly = st != EditState.Create;
            txtHoTen.ReadOnly = !dangNhap;
            cboVaiTro.Enabled = dangNhap;

            bool nhapMatKhau = st == EditState.Create;
            lblCot2.Text = nhapMatKhau ? "Mật khẩu:" : "Trạng thái:";
            txtMatKhau.Visible = nhapMatKhau;
            txtTrangThai.Visible = !nhapMatKhau;
            if (!nhapMatKhau)
                txtMatKhau.Clear();

            dgv.Enabled = !dangNhap;
            gbTimKiem.Enabled = !dangNhap;
            foreach (Button b in new[] { btnThem, btnSua, btnDatLai, btnKhoa, btnXoa, btnDoiMkToi })
                b.Visible = !dangNhap;
            btnXacNhan.Visible = dangNhap;
            btnHuy.Visible = dangNhap;

            if (!dangNhap)
                HienThongTinTheoChon();
        }

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Tài khoản", MessageBoxButtons.OK, icon);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DatTrangThai(EditState.Create);
            txtTenDN.Clear();
            txtHoTen.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedValue = VaiTro.ThuThu;
            txtTenDN.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null)
                return;
            _maDangSua = (int)v["MaTK"];
            DatTrangThai(EditState.Update);
            txtHoTen.Focus();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;
            try
            {
                string vaiTro = cboVaiTro.SelectedValue as string;
                if (_st == EditState.Create)
                {
                    string loi = TaiKhoanBLL.Them(txtTenDN.Text, txtMatKhau.Text, txtHoTen.Text, vaiTro);
                    if (loi != null)
                    {
                        Bao(loi, MessageBoxIcon.Warning);
                        return;
                    }

                    string tenMoi = txtTenDN.Text.Trim();
                    txtTimKiem.Clear();
                    DatTrangThai(EditState.Read);
                    TaiDuLieu(0, tenMoi);
                    Bao("Đã thêm tài khoản \"" + tenMoi + "\".", MessageBoxIcon.Information);
                }
                else if (_st == EditState.Update)
                {
                    string loi = TaiKhoanBLL.Sua(_maDangSua, txtHoTen.Text, vaiTro);
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

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null)
                return;
            int ma = (int)v["MaTK"];
            string ten = v["TenDN"].ToString();

            using (var f = new frmDoiMatKhau("Đặt lại mật khẩu: " + ten, false, (cu, moi) => TaiKhoanBLL.DatLaiMatKhau(ma, moi)))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    Bao("Đã đặt lại mật khẩu cho \"" + ten + "\".", MessageBoxIcon.Information);
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null)
                return;
            int ma = (int)v["MaTK"];
            string ten = v["TenDN"].ToString();
            bool dangHoatDong = (bool)v["TrangThai"];

            string hoi = dangHoatDong
                ? "Khóa tài khoản \"" + ten + "\"?\nNgười này sẽ không đăng nhập được cho đến khi được mở khóa."
                : "Mở khóa tài khoản \"" + ten + "\"?";
            if (MessageBox.Show(hoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string loi = TaiKhoanBLL.DoiTrangThai(ma, !dangHoatDong);
            if (loi != null)
            {
                Bao(loi, MessageBoxIcon.Warning);
                return;
            }
            TaiDuLieu(ma);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null)
                return;
            int ma = (int)v["MaTK"];
            string ten = v["TenDN"].ToString();

            if (MessageBox.Show("Xóa vĩnh viễn tài khoản \"" + ten + "\"?\nTài khoản đã lập phiếu thì không xóa được, chỉ khóa.",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            string loi = TaiKhoanBLL.Xoa(ma);
            if (loi != null)
            {
                Bao(loi, MessageBoxIcon.Warning);
                return;
            }
            TaiDuLieu();
        }

        private void btnDoiMkToi_Click(object sender, EventArgs e)
        {
            using (var f = new frmDoiMatKhau("Đổi mật khẩu của tôi", true, (cu, moi) => AuthBLL.DoiMatKhau(cu, moi)))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    Bao("Đã đổi mật khẩu.", MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            TaiDuLieu();
            txtTimKiem.Focus();
        }
    }
}
