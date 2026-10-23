using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    public enum LocMuon
    {
        TatCa = 0, DangMuon = 1, QuaHan = 2, DaTra = 3
    }

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
            if (e.KeyCode != Keys.Enter)
                return;
            e.SuppressKeyPress = true;
            TaiDuLieu();
        }

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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }
    }
}
