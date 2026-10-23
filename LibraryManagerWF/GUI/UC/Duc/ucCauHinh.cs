using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI.UC.Duc
{
    public partial class ucCauHinh : UserControl
    {
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
            GridStyle.AddText(dgv, "Đơn vị", "DonVi");

            Load += ucCauHinh_Load;
        }

        private void ucCauHinh_Load(object sender, EventArgs e)
        {

            TaiDuLieu();
            DatTrangThai(EditState.Read);
        }

        private void txtGiaTri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || _st == EditState.Read)
                return;
            e.SuppressKeyPress = true;
            btnXacNhan.PerformClick();
        }

        private void TaiDuLieu(string chonKhoa = null)
        {
            if (chonKhoa == null)
                chonKhoa = KhoaDangChon();

            dgv.DataSource = CauHinhBLL.LayTatCa();
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var v = row.DataBoundItem as DataRowView;
                if (v == null || chonKhoa == null)
                    continue;
                if (!string.Equals(v["Khoa"].ToString(), chonKhoa, StringComparison.Ordinal))
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

        private string KhoaDangChon()
        {
            DataRowView v = DongChon();
            return v == null ? null : v["Khoa"].ToString();
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var v = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v == null)
                return;

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
            if (_st == EditState.Read)
                HienThongTinTheoChon();
        }

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

            txtGiaTri.ReadOnly = !dangSua;

            dgv.Enabled = !dangSua;
            btnSua.Visible = !dangSua;
            btnLamMoi.Visible = !dangSua;
            btnXacNhan.Visible = dangSua;
            btnHuy.Visible = dangSua;

            if (!dangSua)
                HienThongTinTheoChon();
        }

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Cấu hình", MessageBoxButtons.OK, icon);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string khoa = KhoaDangChon();
            if (khoa == null)
                return;
            _khoaDangSua = khoa;
            DatTrangThai(EditState.Update);
            txtGiaTri.Focus();
            txtGiaTri.SelectAll();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;
            try
            {
                string loi = CauHinhBLL.CapNhat(_khoaDangSua, txtGiaTri.Text.Trim());
                if (loi != null)
                {
                    Bao(loi, MessageBoxIcon.Warning);
                    return;
                }

                DatTrangThai(EditState.Read);
                TaiDuLieu(_khoaDangSua);
                Bao("Đã cập nhật \"" + _khoaDangSua + "\". Giá trị mới áp dụng cho các giao dịch từ bây giờ.", MessageBoxIcon.Information);
            }
            finally
            {
                btnXacNhan.Enabled = true;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DatTrangThai(EditState.Read);
        }
    }
}
