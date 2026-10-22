using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI.UC.Duc
{
    /// <summary>
    /// Cấu hình đơn giá và quy định (BR01 đến BR07, chỉ QuanTri): xem các tham số trong bảng CauHinh và sửa giá trị.
    /// Giao diện kéo thả trong ucCauHinh.Designer.cs (chữ cỡ 12); file này chỉ chứa xử lý sự kiện.
    /// Không thêm / xóa tham số: bộ khóa cố định do nghiệp vụ cần. GUI chỉ gọi CauHinhBLL; việc kiểm tra giá trị
    /// (số nguyên không âm) và quyền QuanTri nằm ở BLL. Giá trị mới chỉ áp dụng cho giao dịch từ lúc đổi trở đi.
    /// Màu hàng theo nhóm: xanh dương = thẻ thư viện, xanh lá = mượn và gia hạn, cam = phạt và đền bù.
    /// </summary>
    public partial class ucCauHinh : UserControl
    {
        // Đơn vị hiển thị cạnh giá trị (chỉ để dễ đọc, không lưu vào CSDL)
        private static readonly Dictionary<string, string> DonVi = new Dictionary<string, string>
        {
            { "THE_SO_THANG", "tháng" },
            { "PHI_THE", "đồng" },
            { "MUON_TOI_DA", "cuốn" },
            { "MUON_SO_NGAY", "ngày" },
            { "GIA_HAN_TOI_DA", "lần" },
            { "GIA_HAN_SO_NGAY", "ngày" },
            { "PHAT_TRE_MOI_NGAY", "đồng / cuốn / ngày" },
            { "DEN_HONG_PHAN_TRAM", "% giá bìa" },
            { "DEN_MAT_PHAN_TRAM", "% giá bìa" }
        };

        private EditState _st = EditState.Read;
        private string _khoaDangSua;

        public ucCauHinh()
        {
            InitializeComponent();
            BackColor = Theme.Nen;
            lblTieuDe.Font = new Font(Font, FontStyle.Bold);

            GridStyle.Apply(dgv, 12F);
            GridStyle.AddFill(dgv, "Quy định", "MoTa", 300);
            GridStyle.AddText(dgv, "Mã tham số", "Khoa");
            GridStyle.AddText(dgv, "Giá trị", "GiaTri", null, DataGridViewContentAlignment.MiddleRight);
            GridStyle.AddText(dgv, "Đơn vị", "DonVi");      // cột phụ, điền trong CellFormatting
            GridStyle.ToMauHang(dgv, v =>
            {
                string khoa = Convert.ToString(v["Khoa"]);
                if (khoa == "THE_SO_THANG" || khoa == "PHI_THE") return Theme.HangNhan;
                if (khoa.StartsWith("MUON_") || khoa.StartsWith("GIA_HAN_")) return Color.FromArgb(220, 240, 220);
                if (khoa.StartsWith("PHAT_") || khoa.StartsWith("DEN_")) return Theme.HangCam;
                return null;
            });

            Load += ucCauHinh_Load;
        }

        private void ucCauHinh_Load(object sender, EventArgs e)
        {
            btnLamMoi.Click += (s, ev) => TaiDuLieu();
            txtGiaTri.KeyDown += txtGiaTri_KeyDown;
            dgv.SelectionChanged += dgv_SelectionChanged;
            dgv.CellFormatting += dgv_CellFormatting;
            btnSua.Click += btnSua_Click;
            btnXacNhan.Click += btnXacNhan_Click;
            btnHuy.Click += (s, ev) => DatTrangThai(EditState.Read);

            TaiDuLieu();
            DatTrangThai(EditState.Read);
        }

        // ================= Dữ liệu =================

        private void txtGiaTri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || _st == EditState.Read) return;
            e.SuppressKeyPress = true;
            btnXacNhan.PerformClick();
        }

        /// <summary>Nạp lại bảng, giữ dòng đang chọn (theo mã tham số).</summary>
        private void TaiDuLieu(string chonKhoa = null)
        {
            if (chonKhoa == null) chonKhoa = KhoaDangChon();

            dgv.DataSource = CauHinhBLL.LayTatCa();
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var v = row.DataBoundItem as DataRowView;
                if (v == null || chonKhoa == null) continue;
                if (!string.Equals(v["Khoa"].ToString(), chonKhoa, StringComparison.Ordinal)) continue;
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

        private string KhoaDangChon()
        {
            DataRowView v = DongChon();
            return v == null ? null : v["Khoa"].ToString();
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var v = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v == null) return;

            string cot = dgv.Columns[e.ColumnIndex].Name;
            if (cot == "DonVi")
            {
                string dv;
                e.Value = DonVi.TryGetValue(v["Khoa"].ToString(), out dv) ? dv : "";
                e.FormattingApplied = true;
            }
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
                txtKhoa.Clear();
                txtGiaTri.Clear();
                txtMoTa.Clear();
            }
            else
            {
                txtKhoa.Text = v["Khoa"].ToString();
                txtGiaTri.Text = v["GiaTri"].ToString();
                txtMoTa.Text = v["MoTa"] == DBNull.Value ? "" : v["MoTa"].ToString();
            }
            btnSua.Enabled = v != null;
        }

        private void DatTrangThai(EditState st)
        {
            _st = st;
            bool dangSua = st == EditState.Update;

            StatusRequestEventArgs tt = MauTrangThai.Tao(st, "cấu hình", "THÔNG TIN CẤU HÌNH");
            lblTieuDe.Text = tt.TitleText;
            lblTieuDe.BackColor = tt.BackColor;
            lblTieuDe.ForeColor = tt.ForeColor;

            txtGiaTri.ReadOnly = !dangSua;                  // mã tham số và mô tả luôn chỉ đọc

            dgv.Enabled = !dangSua;                         // đang sửa thì khóa lưới, khỏi đổi dòng giữa chừng
            btnSua.Visible = !dangSua;
            btnLamMoi.Visible = !dangSua;
            btnXacNhan.Visible = dangSua;
            btnHuy.Visible = dangSua;

            if (!dangSua) HienThongTinTheoChon();
        }

        // ================= Thao tác =================

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Cấu hình", MessageBoxButtons.OK, icon);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string khoa = KhoaDangChon();
            if (khoa == null) return;
            _khoaDangSua = khoa;
            DatTrangThai(EditState.Update);
            txtGiaTri.Focus();
            txtGiaTri.SelectAll();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;                 // chặn bấm hai lần
            try
            {
                string loi = CauHinhBLL.CapNhat(_khoaDangSua, txtGiaTri.Text.Trim());
                if (loi != null) { Bao(loi, MessageBoxIcon.Warning); return; }

                DatTrangThai(EditState.Read);
                TaiDuLieu(_khoaDangSua);
                Bao("Đã cập nhật \"" + _khoaDangSua + "\". Giá trị mới áp dụng cho các giao dịch từ bây giờ.", MessageBoxIcon.Information);
            }
            finally
            {
                btnXacNhan.Enabled = true;
            }
        }
    }
}
