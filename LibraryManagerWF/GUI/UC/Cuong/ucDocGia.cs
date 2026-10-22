using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI.UC.Cuong
{
    /// <summary>
    /// Hồ sơ độc giả (BR10, BR12): xem, tìm theo họ tên / số điện thoại, thêm, sửa, khóa / mở khóa, xóa.
    /// Giao diện kéo thả trong ucDocGia.Designer.cs (chữ cỡ 12); file này chỉ chứa xử lý sự kiện.
    /// GUI chỉ gọi DocGiaBLL / TheBLL: hàm ghi trả về lỗi (null = thành công) thì hiện lên; mọi luật
    /// (họ tên, ngày sinh, SĐT 10 số, email, độc giả đã có thẻ thì không xóa) nằm ở BLL.
    /// Màu hàng: xám = độc giả bị khóa, vàng = chưa có thẻ.
    /// </summary>
    public partial class ucDocGia : UserControl
    {
        private EditState _st = EditState.Read;
        private int _maDangSua;

        public ucDocGia()
        {
            InitializeComponent();
            BackColor = Theme.Nen;

            GridStyle.Apply(dgv, 12F);
            GridStyle.AddText(dgv, "Mã ĐG", "MaDG", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Họ tên", "HoTen");
            GridStyle.AddText(dgv, "Ngày sinh", "NgaySinh", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Giới tính", "GioiTinh", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "SĐT", "SDT");
            GridStyle.AddText(dgv, "Email", "Email");
            GridStyle.AddFill(dgv, "Địa chỉ", "DiaChi", 150);
            GridStyle.AddText(dgv, "Trạng thái", "TrangThaiChu", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Thẻ", "TinhTrangThe", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.ToMauHang(dgv, v =>
            {
                if (!(bool)v["TrangThai"]) return Theme.HangKhoa;                      // độc giả bị khóa
                if (v["TinhTrangThe"].ToString() == ChuaCoThe) return Theme.HangCanhBao;   // chưa có thẻ
                return null;
            });

            Load += ucDocGia_Load;
        }

        internal const string ChuaCoThe = "Chưa có thẻ";

        /// <summary>
        /// Thêm hai cột hiển thị vào bảng DocGiaBLL.TimKiem trả về: TrangThaiChu (Hoạt động / Khóa) và
        /// TinhTrangThe (Chưa có thẻ / Hoạt động / Hết hạn / Khóa, do TheBLL.TinhTrangThe tính). Dùng chung với ucThe.
        /// </summary>
        internal static DataTable ThemCotHienThi(DataTable bang)
        {
            bang.Columns.Add("TrangThaiChu", typeof(string));
            bang.Columns.Add("TinhTrangThe", typeof(string));
            foreach (DataRow r in bang.Rows)
            {
                r["TrangThaiChu"] = (bool)r["TrangThai"] ? "Hoạt động" : "Khóa";
                r["TinhTrangThe"] = r["MaThe"] == DBNull.Value
                    ? ChuaCoThe
                    : TheBLL.TinhTrangThe((bool)r["TrangThaiThe"], (DateTime)r["NgayHetHan"]);
            }
            return bang;
        }

        private void ucDocGia_Load(object sender, EventArgs e)
        {
            foreach (Control c in new Control[] { txtHoTen, txtSDT, txtEmail, txtDiaChi })
                c.KeyDown += oNhap_KeyDown;

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

        /// <summary>Enter trong ô nhập (khi đang thêm / sửa) = bấm Xác nhận.</summary>
        private void oNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || _st == EditState.Read) return;
            e.SuppressKeyPress = true;
            btnXacNhan.PerformClick();
        }

        /// <summary>
        /// Nạp lại bảng, giữ dòng đang chọn (theo MaDG). Truyền chonMa để chọn một độc giả cụ thể,
        /// hoặc chonDongDau = true để chọn dòng đầu (bảng sắp mã giảm dần nên đó là độc giả vừa thêm).
        /// </summary>
        private void TaiDuLieu(int chonMa = 0, bool chonDongDau = false)
        {
            if (chonMa == 0 && !chonDongDau) chonMa = MaDangChon();

            dgv.DataSource = ThemCotHienThi(DocGiaBLL.TimKiem(txtTimKiem.Text));
            dgv.ClearSelection();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var v = dgv.Rows[i].DataBoundItem as DataRowView;
                if (v == null) continue;
                if (!(chonDongDau ? i == 0 : (chonMa > 0 && (int)v["MaDG"] == chonMa))) continue;
                dgv.CurrentCell = dgv.Rows[i].Cells[0];
                dgv.Rows[i].Selected = true;
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
            return v == null ? 0 : (int)v["MaDG"];
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_st == EditState.Read) HienThongTinTheoChon();
        }

        // ================= Trạng thái màn hình =================

        private static string ChuoiHoacRong(object o)
        {
            return o == null || o == DBNull.Value ? "" : o.ToString();
        }

        private void XoaTrangForm()
        {
            txtMaDG.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            cboGioiTinh.SelectedIndex = -1;
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTrangThai.Clear();
        }

        private void HienThongTinTheoChon()
        {
            DataRowView v = DongChon();
            if (v == null)
            {
                XoaTrangForm();
            }
            else
            {
                txtMaDG.Text = v["MaDG"].ToString();
                txtHoTen.Text = v["HoTen"].ToString();
                dtpNgaySinh.Value = ((DateTime)v["NgaySinh"]).Date;
                cboGioiTinh.SelectedItem = v["GioiTinh"].ToString();
                txtSDT.Text = v["SDT"].ToString();
                txtEmail.Text = ChuoiHoacRong(v["Email"]);
                txtDiaChi.Text = ChuoiHoacRong(v["DiaChi"]);
                txtTrangThai.Text = v["TrangThaiChu"].ToString();
            }
            CapNhatNut();
        }

        private void CapNhatNut()
        {
            DataRowView v = DongChon();
            bool coDong = v != null;
            btnThem.Enabled = true;
            btnSua.Enabled = coDong;
            btnXoa.Enabled = coDong;
            btnKhoa.Enabled = coDong;
            btnKhoa.Text = coDong && !(bool)v["TrangThai"] ? "Mở khóa" : "Khóa độc giả";
        }

        private void DatTrangThai(EditState st)
        {
            _st = st;
            bool dangNhap = st != EditState.Read;

            StatusRequestEventArgs tt = MauTrangThai.Tao(st, "độc giả", "THÔNG TIN ĐỘC GIẢ");
            lblTieuDe.Text = tt.TitleText;
            lblTieuDe.BackColor = tt.BackColor;
            lblTieuDe.ForeColor = tt.ForeColor;

            txtHoTen.ReadOnly = !dangNhap;
            txtSDT.ReadOnly = !dangNhap;
            txtEmail.ReadOnly = !dangNhap;
            txtDiaChi.ReadOnly = !dangNhap;
            dtpNgaySinh.Enabled = dangNhap;
            cboGioiTinh.Enabled = dangNhap;

            dgv.Enabled = !dangNhap;                        // đang nhập thì khóa lưới, khỏi đổi dòng giữa chừng
            gbTimKiem.Enabled = !dangNhap;
            foreach (Button b in new[] { btnThem, btnSua, btnKhoa, btnXoa })
                b.Visible = !dangNhap;
            btnXacNhan.Visible = dangNhap;
            btnHuy.Visible = dangNhap;

            if (!dangNhap) HienThongTinTheoChon();
        }

        // ================= Thao tác =================

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Độc giả", MessageBoxButtons.OK, icon);
        }

        private DocGiaDTO DocTuForm(int maDG)
        {
            return new DocGiaDTO
            {
                MaDG = maDG,
                HoTen = txtHoTen.Text,
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = cboGioiTinh.SelectedItem as string,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                Email = txtEmail.Text
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DatTrangThai(EditState.Create);
            XoaTrangForm();
            cboGioiTinh.SelectedIndex = 0;
            txtTrangThai.Text = "Hoạt động";
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null) return;
            _maDangSua = (int)v["MaDG"];
            DatTrangThai(EditState.Update);
            txtHoTen.Focus();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;                 // chặn bấm hai lần
            try
            {
                if (_st == EditState.Create)
                {
                    DocGiaDTO d = DocTuForm(0);
                    string loi = DocGiaBLL.Them(d);
                    if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }

                    txtTimKiem.Clear();                 // tránh bộ lọc cũ che mất dòng vừa thêm
                    DatTrangThai(EditState.Read);
                    TaiDuLieu(0, true);
                    Bao("Đã thêm độc giả \"" + d.HoTen + "\".\nSang tab \"Thẻ thư viện\" để cấp thẻ cho độc giả này.", MessageBoxIcon.Information);
                }
                else if (_st == EditState.Update)
                {
                    string loi = DocGiaBLL.Sua(DocTuForm(_maDangSua));
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

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null) return;
            int ma = (int)v["MaDG"];
            string ten = v["HoTen"].ToString();
            bool dangHoatDong = (bool)v["TrangThai"];

            string hoi = dangHoatDong
                ? "Khóa độc giả \"" + ten + "\"?\nĐộc giả bị khóa không được mượn hoặc gia hạn sách, nhưng vẫn trả sách và nộp phạt.\nThẻ thư viện không bị khóa theo."
                : "Mở khóa độc giả \"" + ten + "\"?";
            if (MessageBox.Show(hoi, dangHoatDong ? "Khóa độc giả" : "Mở khóa độc giả",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            DocGiaBLL.DoiTrangThai(ma, !dangHoatDong);
            TaiDuLieu(ma);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null) return;
            int ma = (int)v["MaDG"];
            string ten = v["HoTen"].ToString();

            if (MessageBox.Show("Xóa độc giả \"" + ten + "\"?\nĐộc giả đã có thẻ thì không xóa được, chỉ khóa.",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            string loi = DocGiaBLL.Xoa(ma);
            if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }
            TaiDuLieu();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DatTrangThai(EditState.Read);
        }
    }
}
