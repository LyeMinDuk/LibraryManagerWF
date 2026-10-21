using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Trả sách: chọn một cuốn đang mượn, chọn tình trạng, xem trước tiền, xác nhận đã thu rồi mới trả (BR13).
    /// Luật tính tiền và ghi dữ liệu nằm hết ở TraBLL; GUI chỉ hiển thị và hỏi xác nhận.
    /// Designer chưa có ô chọn tình trạng và ô tiền nên tạo bằng code (cboTinhTrang, txtTien);
    /// nút Sửa/Xóa của khung CRUD cũ không có nghĩa với trả sách nên ẩn đi.
    /// </summary>
    public partial class ucQuanLyTra : UserControl
    {
        private ComboBox cboTinhTrang;
        private TextBox txtTien;

        public ucQuanLyTra()
        {
            InitializeComponent();
            TaoControlThaoTac();
            Load += ucQuanLyTra_Load;
        }

        private void TaoControlThaoTac()
        {
            label2.Text = "Quá hạn:";
            btnXacNhan.Text = "Trả sách";
            btnHuy.Text = "Bỏ chọn";
            btnSua.Visible = false;
            btnXoa.Visible = false;

            var lblTT = new Label { Text = "Tình trạng khi trả:", AutoSize = true, Margin = new Padding(3, 14, 3, 0), Font = btnXacNhan.Font };
            cboTinhTrang = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 170,
                Margin = new Padding(3, 10, 12, 0),
                Font = btnXacNhan.Font
            };
            cboTinhTrang.Items.AddRange(new object[] { TinhTrangMuon.BinhThuong, TinhTrangMuon.Hong, TinhTrangMuon.Mat });
            cboTinhTrang.SelectedIndex = 0;

            txtTien = new TextBox { ReadOnly = true, Width = 430, Margin = new Padding(3, 10, 12, 0), Font = btnXacNhan.Font };

            flpThaoTac.Controls.Add(lblTT);
            flpThaoTac.Controls.Add(cboTinhTrang);
            flpThaoTac.Controls.Add(txtTien);
            flpThaoTac.Controls.SetChildIndex(lblTT, 0);
            flpThaoTac.Controls.SetChildIndex(cboTinhTrang, 1);
            flpThaoTac.Controls.SetChildIndex(txtTien, 2);
        }

        private void ucQuanLyTra_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();
            btnTimKiem.Click += (s, ev) => TaiDuLieu();
            btnLamMoi.Click += btnLamMoi_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            dgv.SelectionChanged += (s, ev) => CapNhatChon();
            cboTinhTrang.SelectedIndexChanged += (s, ev) => XemTruoc();
            btnXacNhan.Click += btnXacNhan_Click;
            btnHuy.Click += (s, ev) => dgv.ClearSelection();
            TaiDuLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            TaiDuLieu();
            txtTimKiem.Focus();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            TaiDuLieu();
        }

        // Cột lấy từ ChiTietMuonDAL.DanhSach; chỉ liệt kê cuốn chưa trả nên không có cột Ngày trả / Tình trạng
        private void CauHinhLuoi()
        {
            GridStyle.Apply(dgv);
            GridStyle.AddText(dgv, "Mã CT", "MaCTM", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Độc giả", "HoTen", 150);
            GridStyle.AddText(dgv, "SĐT", "SDT");
            GridStyle.AddText(dgv, "Mã thẻ", "MaThe", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Tên sách", "TenSach", 180);
            GridStyle.AddText(dgv, "Ngày mượn", "NgayMuon", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Hạn trả", "HanTra", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Số ngày trễ", "SoNgayTre", null, DataGridViewContentAlignment.MiddleCenter);
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
                txtHoTen.Clear();
                txtTTThe.Clear();
                txtTien.Clear();
                btnXacNhan.Enabled = false;
                return;
            }

            int tre = Convert.ToInt32(v["SoNgayTre"]);
            txtHoTen.Text = Convert.ToString(v["HoTen"]);
            txtTTThe.Text = tre > 0 ? "Quá hạn " + tre + " ngày" : "Còn hạn";
            XemTruoc();
        }

        /// <summary>Hỏi TraBLL.XemTruoc (chưa ghi gì) rồi hiện số tiền phải thu.</summary>
        private void XemTruoc()
        {
            DataRowView v = CuonDangChon();
            if (v == null) return;

            decimal phat, den;
            string loi = TraBLL.XemTruoc(Convert.ToInt32(v["MaCTM"]), (string)cboTinhTrang.SelectedItem, out phat, out den);
            if (loi != null)
            {
                txtTien.Text = loi;
                btnXacNhan.Enabled = false;
                return;
            }

            decimal tong = phat + den;
            txtTien.Text = tong > 0
                ? string.Format("Phạt trễ {0:N0}đ + Đền {1:N0}đ = {2:N0}đ", phat, den, tong)
                : "Không phải nộp tiền";
            btnXacNhan.Enabled = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DataRowView v = CuonDangChon();
            if (v == null) return;

            int maCTM = Convert.ToInt32(v["MaCTM"]);
            string tinhTrang = (string)cboTinhTrang.SelectedItem;
            string tenSach = Convert.ToString(v["TenSach"]);

            decimal phat, den;
            string loi = TraBLL.XemTruoc(maCTM, tinhTrang, out phat, out den);
            if (loi != null)
            {
                MessageBox.Show(loi, "Không thể trả sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TaiDuLieu();
                return;
            }

            // BR13: có tiền thì thủ thư phải xác nhận ĐÃ THU rồi mới truyền daThuTien = true
            decimal tong = phat + den;
            string hoi = tong > 0
                ? string.Format("Trả \"{0}\" ({1}).\nPhải thu {2:N0}đ. Đã thu đủ tiền của độc giả chưa?", tenSach, tinhTrang, tong)
                : string.Format("Xác nhận trả \"{0}\" ({1})?", tenSach, tinhTrang);
            if (MessageBox.Show(hoi, "Xác nhận trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            loi = TraBLL.Tra(maCTM, tinhTrang, true, out phat, out den);
            if (loi != null)
            {
                MessageBox.Show(loi, "Không thể trả sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TaiDuLieu();
                return;
            }

            MessageBox.Show(tong > 0 ? "Đã trả sách và lập phiếu thu." : "Đã trả sách.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDuLieu();
        }
    }
}
