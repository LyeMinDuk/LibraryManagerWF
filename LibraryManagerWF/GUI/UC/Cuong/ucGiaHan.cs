using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI.UC.Cuong
{
    public partial class ucGiaHan : UserControl
    {
        private int _toiDa, _soNgay;

        public ucGiaHan()
        {
            InitializeComponent();
            BackColor = Theme.Nen;
            lblTieuDe.BackColor = MauTrangThai.Xem;
            lblTieuDe.ForeColor = Color.White;
            lblChiTiet.ForeColor = Theme.ChuPhu;

            CauHinhLuoi();
            Load += ucGiaHan_Load;
        }

        private void ucGiaHan_Load(object sender, EventArgs e)
        {
            _toiDa = CauHinhSo("GIA_HAN_TOI_DA");
            _soNgay = CauHinhSo("GIA_HAN_SO_NGAY");

            TaiDuLieu();
        }

        private static int CauHinhSo(string khoa)
        {
            DataRow[] dong = CauHinhBLL.LayTatCa().Select("Khoa = '" + khoa + "'");
            return dong.Length == 0 ? 0 : Convert.ToInt32(dong[0]["GiaTri"]);
        }

        private static void Bao(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(noiDung, "Gia hạn sách", MessageBoxButtons.OK, icon);
        }

        private void CauHinhLuoi()
        {
            GridStyle.Apply(dgv, 12F);
            GridStyle.AddText(dgv, "Mã CT", "MaCTM", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Độc giả", "HoTen", 150);
            GridStyle.AddText(dgv, "SĐT", "SDT");
            GridStyle.AddText(dgv, "Mã thẻ", "MaThe", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Tên sách", "TenSach", 180);
            GridStyle.AddText(dgv, "Ngày mượn", "NgayMuon", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Hạn trả", "HanTra", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Số ngày trễ", "SoNgayTre", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Đã gia hạn", "SoLanGiaHan", null, DataGridViewContentAlignment.MiddleCenter);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            e.SuppressKeyPress = true;
            TaiDuLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            TaiDuLieu();
            txtTimKiem.Focus();
        }

        private void TaiDuLieu()
        {
            dgv.DataSource = MuonBLL.DanhSachMuon(txtTimKiem.Text.Trim(), 0, (int)LocMuon.DangMuon);
            dgv.ClearSelection();
            CapNhatChon();
        }

        private DataRowView CuonDangChon()
        {
            return dgv.SelectedRows.Count > 0 ? dgv.SelectedRows[0].DataBoundItem as DataRowView : null;
        }

        private void CapNhatChon()
        {
            DataRowView v = CuonDangChon();
            if (v == null)
            {
                lblChiTiet.Text = "Chọn một dòng trong danh sách để xem chi tiết.";
                btnGiaHan.Enabled = false;
                return;
            }

            int tre = Convert.ToInt32(v["SoNgayTre"]);
            int daGiaHan = Convert.ToInt32(v["SoLanGiaHan"]);
            DateTime hanTra = Convert.ToDateTime(v["HanTra"]);
            string ten = Convert.ToString(v["HoTen"]);
            string sach = Convert.ToString(v["TenSach"]);

            if (tre > 0)
            {
                lblChiTiet.Text = "\"" + sach + "\" (" + ten + ") đã quá hạn " + tre + " ngày — không gia hạn được, phải trả sách.";
                btnGiaHan.Enabled = false;
            }
            else if (daGiaHan >= _toiDa)
            {
                lblChiTiet.Text = "\"" + sach + "\" (" + ten + ") đã gia hạn tối đa " + _toiDa + " lần, hạn trả " + hanTra.ToString("dd/MM/yyyy") + ".";
                btnGiaHan.Enabled = false;
            }
            else
            {
                DateTime hanMoiDuKien = hanTra.AddDays(_soNgay);
                lblChiTiet.Text = "\"" + sach + "\" (" + ten + ") hạn trả " + hanTra.ToString("dd/MM/yyyy")
                                   + ", đã gia hạn " + daGiaHan + "/" + _toiDa + " lần."
                                   + " Gia hạn thêm " + _soNgay + " ngày → hạn mới dự kiến " + hanMoiDuKien.ToString("dd/MM/yyyy") + ".";
                btnGiaHan.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            CapNhatChon();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnGiaHan.Enabled)
                btnGiaHan.PerformClick();
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            DataRowView v = CuonDangChon();
            if (v == null)
                return;

            int maCTM = Convert.ToInt32(v["MaCTM"]);
            string ten = Convert.ToString(v["HoTen"]);
            string sach = Convert.ToString(v["TenSach"]);

            if (MessageBox.Show("Gia hạn \"" + sach + "\" cho \"" + ten + "\"?", "Xác nhận gia hạn",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            btnGiaHan.Enabled = false;
            try
            {
                DateTime hanMoi;
                string loi = MuonBLL.GiaHan(maCTM, out hanMoi);
                if (loi != null)
                {
                    Bao(loi, MessageBoxIcon.Warning);
                    TaiDuLieu();
                    return;
                }

                Bao("Đã gia hạn \"" + sach + "\" cho \"" + ten + "\".\nHạn trả mới: " + hanMoi.ToString("dd/MM/yyyy") + ".", MessageBoxIcon.Information);
                TaiDuLieu();
            }
            finally
            {
                CapNhatChon();
            }
        }
    }
}
