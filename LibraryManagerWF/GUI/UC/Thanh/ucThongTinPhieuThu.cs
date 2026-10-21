using System;
using System.Data;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Tra cứu phiếu thu theo khoảng ngày và loại thu (PhieuThuBLL.TimKiem). Chỉ xem: phiếu thu là sổ ghi tiền
    /// do nghiệp vụ tự sinh (BR08), không sửa/xóa nên khung nút Xác nhận/Sửa/Xóa/Hủy của designer cũ được ẩn.
    /// </summary>
    public partial class ucThongTinPhieuThu : UserControl
    {
        public ucThongTinPhieuThu()
        {
            InitializeComponent();
            gbThaoTac.Visible = false;
            foreach (TextBox t in new[] { txt, txtLoaiThu, txtSoTien, txtGanVoi, txtNguoiThu, txtGhiChu })
                t.ReadOnly = true;
            dtpNgayThu.Enabled = false;
            dtpNgayThu.Format = DateTimePickerFormat.Custom;
            dtpNgayThu.CustomFormat = "dd/MM/yyyy HH:mm";
            Load += ucThongTinPhieuThu_Load;
        }

        private void ucThongTinPhieuThu_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();
            DoCombobox();
            DatLaiBoLoc();
            btnTimKiem.Click += (s, ev) => TaiDuLieu();
            btnLamMoi.Click += (s, ev) => { DatLaiBoLoc(); TaiDuLieu(); };
            cboLoaiThu.SelectedIndexChanged += (s, ev) => TaiDuLieu();
            dgv.SelectionChanged += (s, ev) => HienChiTiet();
            TaiDuLieu();
        }

        private void DoCombobox()
        {
            cboLoaiThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiThu.Items.AddRange(new object[] { "Tất cả loại thu", LoaiThu.PhiThe, LoaiThu.PhatTre, LoaiThu.DenBu });
            cboLoaiThu.SelectedIndex = 0;
        }

        private void DatLaiBoLoc()
        {
            dtpTu.Value = DateTime.Today.AddDays(-30);
            dtpDen.Value = DateTime.Today;
            cboLoaiThu.SelectedIndex = 0;
        }

        // Tên thuộc tính trùng tên cột của PhieuThuDAL.TimKiem
        private void CauHinhLuoi()
        {
            GridStyle.Apply(dgv);
            var maPT = GridStyle.AddText(dgv, "Mã PT", "MaPT", "PT00");
            var loai = GridStyle.AddText(dgv, "Loại thu", "LoaiThu");
            var tien = GridStyle.AddText(dgv, "Số tiền", "SoTien", "N0'đ'", System.Windows.Forms.DataGridViewContentAlignment.MiddleRight);
            var ngay = GridStyle.AddText(dgv, "Ngày thu", "NgayThu", "dd/MM/yyyy HH:mm");
            var ghiChu = GridStyle.AddFill(dgv, "Ghi chú", "GhiChu", 150);

            maPT.FillWeight = 10;
            loai.FillWeight = 16;
            tien.FillWeight = 16;
            ngay.FillWeight = 20;
            ghiChu.FillWeight = 38;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 42;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void TaiDuLieu()
        {
            if (dtpTu.Value.Date > dtpDen.Value.Date)
            {
                MessageBox.Show("\"Từ ngày\" không được lớn hơn \"Đến ngày\".", "Khoảng ngày không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loai = cboLoaiThu.SelectedIndex <= 0 ? "" : cboLoaiThu.Text;
            DataTable dt = PhieuThuBLL.TimKiem(dtpTu.Value, dtpDen.Value, loai);
            dgv.DataSource = dt;

            object tong = dt.Compute("SUM(SoTien)", "");
            lblSoPhieu.Text = dt.Rows.Count + " phiếu thu";
            lblTongTien.Text = "Tổng: " + (tong == DBNull.Value ? 0m : Convert.ToDecimal(tong)).ToString("N0") + "đ";

            dgv.ClearSelection();
            HienChiTiet();
        }

        private void HienChiTiet()
        {
            DataRowView v = dgv.SelectedRows.Count > 0 ? dgv.SelectedRows[0].DataBoundItem as DataRowView : null;
            if (v == null)
            {
                foreach (TextBox t in new[] { txt, txtLoaiThu, txtSoTien, txtGanVoi, txtNguoiThu, txtGhiChu })
                    t.Clear();
                return;
            }

            txt.Text = "PT" + Convert.ToInt32(v["MaPT"]).ToString("00");
            txtLoaiThu.Text = Convert.ToString(v["LoaiThu"]);
            txtSoTien.Text = Convert.ToDecimal(v["SoTien"]).ToString("N0") + "đ";
            dtpNgayThu.Value = Convert.ToDateTime(v["NgayThu"]);
            txtGanVoi.Text = v["MaThe"] != DBNull.Value
                ? "Thẻ #" + v["MaThe"]
                : "Cuốn mượn #" + v["MaCTM"];
            txtNguoiThu.Text = Convert.ToString(v["NguoiThu"]);
            txtGhiChu.Text = Convert.ToString(v["GhiChu"]);
        }
    }
}
