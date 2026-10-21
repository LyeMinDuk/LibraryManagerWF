using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    /// <summary>Bộ lọc danh sách mượn trả. Giá trị số khớp tham số loc của MuonBLL.DanhSachMuon.</summary>
    public enum LocMuon { TatCa = 0, DangMuon = 1, QuaHan = 2, DaTra = 3 }

    /// <summary>Danh sách cuốn mượn/trả. Chỉ gọi MuonBLL.DanhSachMuon, gán thẳng DataTable vào lưới.</summary>
    public partial class ucDSMuonTra : UserControl
    {
        private readonly LocMuon _loc;

        public ucDSMuonTra() : this(LocMuon.TatCa)
        {
        }

        public ucDSMuonTra(LocMuon loc)
        {
            InitializeComponent();
            _loc = loc;
            Load += ucDSMuonTra_Load;
        }

        private void ucDSMuonTra_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();
            btnTimKiem.Click += (s, ev) => TaiDuLieu();
            btnLamMoi.Click += btnLamMoi_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            dgv.DataBindingComplete += (s, ev) => ToMauTinhTrang();
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

        // Tên thuộc tính trùng tên cột của ChiTietMuonDAL.DanhSach
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
            GridStyle.AddText(dgv, "Ngày trả", "NgayTra", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Tình trạng", "TinhTrang");
            GridStyle.AddText(dgv, "Số ngày trễ", "SoNgayTre", null, DataGridViewContentAlignment.MiddleCenter);
        }

        private void TaiDuLieu()
        {
            dgv.DataSource = MuonBLL.DanhSachMuon(txtTimKiem.Text.Trim(), 0, (int)_loc);
            dgv.ClearSelection();
        }

        private void ToMauTinhTrang()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRowView v = row.DataBoundItem as DataRowView;
                if (v == null) continue;

                string tt = Convert.ToString(v["TinhTrang"]).Trim();
                bool quaHan = Convert.ToInt32(v["SoNgayTre"]) > 0;

                Color nen;
                if (tt == TinhTrangMuon.Mat) nen = Color.IndianRed;
                else if (tt == TinhTrangMuon.Hong) nen = Color.Orange;
                else if (tt == TinhTrangMuon.BinhThuong) nen = Color.LightGreen;
                else nen = quaHan ? Color.LightCoral : Color.Khaki;   // Chưa trả: quá hạn đỏ nhạt, còn hạn vàng

                row.DefaultCellStyle.BackColor = nen;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
