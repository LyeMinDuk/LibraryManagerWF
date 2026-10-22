using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI.UC.Duc
{
    /// <summary>
    /// Quản lý thể loại sách (BR10): xem, tìm theo tên, thêm, sửa tên, xóa.
    /// Giao diện kéo thả trong ucTheLoai.Designer.cs (chữ cỡ 12); file này chỉ chứa xử lý sự kiện.
    /// GUI chỉ gọi TheLoaiBLL: hàm ghi trả về lỗi (null = thành công) thì hiện lên; mọi luật
    /// (tên không rỗng, tối đa 100 ký tự, không trùng, thể loại còn sách thì không xóa) nằm ở BLL.
    /// </summary>
    public partial class ucTheLoai : UserControl
    {
        private EditState _st = EditState.Read;
        private int _maDangSua;

        public ucTheLoai()
        {
            InitializeComponent();
            BackColor = Theme.Nen;
            lblTieuDe.Font = new Font(Font, FontStyle.Bold);

            GridStyle.Apply(dgv, 12F);
            GridStyle.AddText(dgv, "Mã TL", "MaTL", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Tên thể loại", "TenTL", 200);
            GridStyle.AddText(dgv, "Số sách", "SoSach", null, DataGridViewContentAlignment.MiddleCenter);

            Load += ucTheLoai_Load;
        }

        private void ucTheLoai_Load(object sender, EventArgs e)
        {

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

        private static bool Chua(object o, string tuKhoa)
        {
            return o != null && o.ToString().IndexOf(tuKhoa, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        /// <summary>Nạp lại bảng, giữ dòng đang chọn (theo MaTL), hoặc chọn thể loại vừa thêm (theo tên).</summary>
        private void TaiDuLieu(int chonMa = 0, string chonTen = null)
        {
            if (chonMa == 0 && chonTen == null) chonMa = MaDangChon();

            DataTable bang = TheLoaiBLL.LayTatCa();
            var view = new DataView(bang);

            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa.Length > 0)
            {
                // Lọc bằng danh sách mã để khỏi phải escape ký tự đặc biệt của RowFilter
                var ids = bang.Rows.Cast<DataRow>()
                    .Where(r => Chua(r["TenTL"], tuKhoa))
                    .Select(r => ((int)r["MaTL"]).ToString())
                    .ToList();
                view.RowFilter = ids.Count == 0 ? "1 = 0" : "MaTL IN (" + string.Join(",", ids) + ")";
            }

            dgv.DataSource = view;
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var v = row.DataBoundItem as DataRowView;
                if (v == null) continue;
                bool khop = (chonMa > 0 && (int)v["MaTL"] == chonMa)
                            || (chonTen != null && string.Equals(v["TenTL"].ToString(), chonTen, StringComparison.OrdinalIgnoreCase));
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
            return v == null ? 0 : (int)v["MaTL"];
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
                txtMaTL.Clear();
                txtTenTL.Clear();
                txtSoSach.Clear();
            }
            else
            {
                txtMaTL.Text = v["MaTL"].ToString();
                txtTenTL.Text = v["TenTL"].ToString();
                txtSoSach.Text = v["SoSach"].ToString();
            }
            CapNhatNut();
        }

        private void CapNhatNut()
        {
            bool coDong = DongChon() != null;
            btnThem.Enabled = true;
            btnSua.Enabled = coDong;
            btnXoa.Enabled = coDong;
        }

        private void DatTrangThai(EditState st)
        {
            _st = st;
            bool dangNhap = st != EditState.Read;

            StatusRequestEventArgs tt = MauTrangThai.Tao(st, "thể loại", "THÔNG TIN THỂ LOẠI");
            lblTieuDe.Text = tt.TitleText;
            lblTieuDe.BackColor = tt.BackColor;
            lblTieuDe.ForeColor = tt.ForeColor;

            txtTenTL.ReadOnly = !dangNhap;

            dgv.Enabled = !dangNhap;                        // đang nhập thì khóa lưới, khỏi đổi dòng giữa chừng
            gbTimKiem.Enabled = !dangNhap;
            foreach (Button b in new[] { btnThem, btnSua, btnXoa })
                b.Visible = !dangNhap;
            btnXacNhan.Visible = dangNhap;
            btnHuy.Visible = dangNhap;

            if (!dangNhap) HienThongTinTheoChon();
        }

        // ================= Thao tác =================

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Thể loại", MessageBoxButtons.OK, icon);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DatTrangThai(EditState.Create);
            txtMaTL.Clear();
            txtTenTL.Clear();
            txtSoSach.Clear();
            txtTenTL.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null) return;
            _maDangSua = (int)v["MaTL"];
            DatTrangThai(EditState.Update);
            txtTenTL.Focus();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;                 // chặn bấm hai lần
            try
            {
                if (_st == EditState.Create)
                {
                    string loi = TheLoaiBLL.Them(txtTenTL.Text);
                    if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }

                    string tenMoi = txtTenTL.Text.Trim();
                    txtTimKiem.Clear();                 // tránh bộ lọc cũ che mất dòng vừa thêm
                    DatTrangThai(EditState.Read);
                    TaiDuLieu(0, tenMoi);
                    Bao("Đã thêm thể loại \"" + tenMoi + "\".", MessageBoxIcon.Information);
                }
                else if (_st == EditState.Update)
                {
                    string loi = TheLoaiBLL.Sua(_maDangSua, txtTenTL.Text);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView v = DongChon();
            if (v == null) return;
            int ma = (int)v["MaTL"];
            string ten = v["TenTL"].ToString();

            if (MessageBox.Show("Xóa thể loại \"" + ten + "\"?\nThể loại còn sách thì không xóa được.",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            string loi = TheLoaiBLL.Xoa(ma);
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
