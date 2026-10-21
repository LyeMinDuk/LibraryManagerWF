using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI.UC.Duc
{
    /// <summary>
    /// Quản lý tài khoản (chỉ QuanTri, BR10 và BR11): xem, thêm, sửa họ tên / vai trò, đặt lại mật khẩu, khóa / mở khóa, xóa.
    /// Giao diện kéo thả trong ucTaiKhoan.Designer.cs; file này chỉ chứa xử lý sự kiện.
    /// GUI chỉ gọi TaiKhoanBLL / AuthBLL: hàm ghi trả về lỗi (null = thành công) thì hiện lên, mọi luật (trùng tên, độ dài,
    /// không tự khóa / hạ quyền / xóa mình, tài khoản đã lập phiếu chỉ khóa) nằm ở BLL.
    /// Ba trạng thái Read / Create / Update dùng chung EditState và màu thanh tiêu đề (MauTrangThai) như các module khác.
    /// Các nút nhắm vào chính tài khoản đang đăng nhập bị tắt để người dùng khỏi bấm vào lỗi; BLL vẫn chặn lại lần nữa.
    /// </summary>
    public partial class ucTaiKhoan : UserControl
    {
        /// <summary>Một mục của ô chọn vai trò: Gia = giá trị lưu CSDL, Hien = chữ hiển thị.</summary>
        public sealed class MucVaiTro
        {
            public string Gia { get; private set; }
            public string Hien { get; private set; }
            public MucVaiTro(string gia, string hien) { Gia = gia; Hien = hien; }
        }

        private DataTable _bang;
        private EditState _st = EditState.Read;
        private int _maDangSua;

        public ucTaiKhoan()
        {
            InitializeComponent();
            Font = Theme.MakeFont(10.5F);
            BackColor = Theme.Nen;
            lblTieuDe.Font = Theme.MakeFont(10.5F, FontStyle.Bold);

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
            btnTimKiem.Click += (s, ev) => TaiDuLieu();
            btnLamMoi.Click += (s, ev) => { txtTimKiem.Clear(); TaiDuLieu(); txtTimKiem.Focus(); };
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            txtTenDN.KeyDown += oNhap_KeyDown;
            txtHoTen.KeyDown += oNhap_KeyDown;
            txtMatKhau.KeyDown += oNhap_KeyDown;
            dgv.SelectionChanged += dgv_SelectionChanged;
            dgv.CellFormatting += dgv_CellFormatting;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnDatLai.Click += btnDatLai_Click;
            btnKhoa.Click += btnKhoa_Click;
            btnXoa.Click += btnXoa_Click;
            btnDoiMkToi.Click += btnDoiMkToi_Click;
            btnXacNhan.Click += btnXacNhan_Click;
            btnHuy.Click += (s, ev) => DatTrangThai(EditState.Read);

            TaiDuLieu();
            DatTrangThai(EditState.Read);
        }

        // ================= Dữ liệu =================

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            TaiDuLieu();
        }

        /// <summary>Enter trong các ô nhập (khi đang thêm / sửa) = bấm Xác nhận.</summary>
        private void oNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || _st == EditState.Read) return;
            e.SuppressKeyPress = true;
            btnXacNhan.PerformClick();
        }

        private static bool Chua(object o, string tuKhoa)
        {
            return o != null && o.ToString().IndexOf(tuKhoa, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        /// <summary>Nạp lại bảng, giữ dòng đang chọn (theo MaTK), hoặc chọn dòng có tên đăng nhập vừa thêm.</summary>
        private void TaiDuLieu(int chonMa = 0, string chonTenDN = null)
        {
            if (chonMa == 0 && chonTenDN == null) chonMa = MaDangChon();

            _bang = TaiKhoanBLL.LayTatCa();
            var view = new DataView(_bang);

            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa.Length > 0)
            {
                // Lọc bằng danh sách mã để khỏi phải escape ký tự đặc biệt của RowFilter
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
                if (v == null) continue;
                bool khop = (chonMa > 0 && (int)v["MaTK"] == chonMa)
                            || (chonTenDN != null && string.Equals(v["TenDN"].ToString(), chonTenDN, StringComparison.OrdinalIgnoreCase));
                if (!khop) continue;
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
            if (e.RowIndex < 0) return;
            var v = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v == null) return;

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

            if (!(bool)v["TrangThai"]) e.CellStyle.ForeColor = Color.FromArgb(160, 60, 60);   // tài khoản đã khóa
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_st == EditState.Read) HienThongTinTheoChon();
        }

        // ================= Trạng thái màn hình =================

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
            btnDatLai.Enabled = coDong;                 // BLL cho phép đặt lại cả mật khẩu của chính mình
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

            txtTenDN.ReadOnly = st != EditState.Create;     // tên đăng nhập không đổi sau khi tạo
            txtHoTen.ReadOnly = !dangNhap;
            cboVaiTro.Enabled = dangNhap;

            // Cùng một ô ở góc dưới phải: thêm mới thì nhập mật khẩu, còn lại chỉ xem trạng thái
            bool nhapMatKhau = st == EditState.Create;
            lblCot2.Text = nhapMatKhau ? "Mật khẩu:" : "Trạng thái:";
            txtMatKhau.Visible = nhapMatKhau;
            txtTrangThai.Visible = !nhapMatKhau;
            if (!nhapMatKhau) txtMatKhau.Clear();

            dgv.Enabled = !dangNhap;                        // đang nhập thì khóa lưới, khỏi đổi dòng giữa chừng
            gbTimKiem.Enabled = !dangNhap;
            foreach (Button b in new[] { btnThem, btnSua, btnDatLai, btnKhoa, btnXoa, btnDoiMkToi })
                b.Visible = !dangNhap;
            btnXacNhan.Visible = dangNhap;
            btnHuy.Visible = dangNhap;

            if (!dangNhap) HienThongTinTheoChon();
        }

        // ================= Thao tác =================

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
            if (v == null) return;
            _maDangSua = (int)v["MaTK"];
            DatTrangThai(EditState.Update);
            txtHoTen.Focus();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;                 // chặn bấm hai lần
            try
            {
                string vaiTro = cboVaiTro.SelectedValue as string;
                if (_st == EditState.Create)
                {
                    string loi = TaiKhoanBLL.Them(txtTenDN.Text, txtMatKhau.Text, txtHoTen.Text, vaiTro);
                    if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }

                    string tenMoi = txtTenDN.Text.Trim();
                    txtTimKiem.Clear();                 // tránh bộ lọc cũ che mất dòng vừa thêm
                    DatTrangThai(EditState.Read);
                    TaiDuLieu(0, tenMoi);
                    Bao("Đã thêm tài khoản \"" + tenMoi + "\".", MessageBoxIcon.Information);
                }
                else if (_st == EditState.Update)
                {
                    string loi = TaiKhoanBLL.Sua(_maDangSua, txtHoTen.Text, vaiTro);
                    if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }

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
            if (v == null) return;
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
            if (v == null) return;
            int ma = (int)v["MaTK"];
            string ten = v["TenDN"].ToString();
            bool dangHoatDong = (bool)v["TrangThai"];

            string hoi = dangHoatDong
                ? "Khóa tài khoản \"" + ten + "\"?\nNgười này sẽ không đăng nhập được cho đến khi được mở khóa."
                : "Mở khóa tài khoản \"" + ten + "\"?";
            if (MessageBox.Show(hoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            string loi = TaiKhoanBLL.DoiTrangThai(ma, !dangHoatDong);
            if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }
            TaiDuLieu(ma);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null) return;
            int ma = (int)v["MaTK"];
            string ten = v["TenDN"].ToString();

            if (MessageBox.Show("Xóa vĩnh viễn tài khoản \"" + ten + "\"?\nTài khoản đã lập phiếu thì không xóa được, chỉ khóa.",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            string loi = TaiKhoanBLL.Xoa(ma);
            if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }
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

    }
}
