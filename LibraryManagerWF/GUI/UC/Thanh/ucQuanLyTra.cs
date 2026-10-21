using LibraryManagerWF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    public partial class ucQuanLyTra : UserControl
    {
        public ucQuanLyTra()
        {
            InitializeComponent();
            Load += ucQuanLyTra_Load;
        }

        private void ucQuanLyTra_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
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

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;
            TaiDuLieu();
        }

        private void CauHinhLuoi()
        {
            GridStyle.Apply(dgv);
            //GridStyle.AddText(dgv, "Mã CT mượn", "MaCTM", null, DataGridViewContentAlignment.MiddleCenter);
            //GridStyle.AddText(dgv, "Mã phiếu", "MaPM", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Mã độc giả", "MaDG", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Độc giả", "HoTenDG", 150);
            GridStyle.AddText(dgv, "SĐT", "SDT");
            GridStyle.AddText(dgv, "Mã thẻ", "MaThe", null, DataGridViewContentAlignment.MiddleCenter);
            //GridStyle.AddText(dgv, "Mã sách", "MaSach", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddFill(dgv, "Tên sách", "TenSach", 180);
            //GridStyle.AddText(dgv, "Giá bìa", "GiaBia", "N0", DataGridViewContentAlignment.MiddleRight);
            GridStyle.AddText(dgv, "Ngày mượn", "NgayMuon", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            //GridStyle.AddText(dgv, "Hạn trả", "HanTra", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            //GridStyle.AddText(dgv, "Gia hạn", "SoLanGiaHan", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Ngày trả", "NgayTra", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Tình trạng", "TinhTrang");
            //GridStyle.AddText(dgv, "Quá hạn", "QuaHan");
            GridStyle.AddText(dgv, "Số ngày trễ", "SoNgayTre", null, DataGridViewContentAlignment.MiddleCenter);
            GridStyle.AddText(dgv, "Phạt dự kiến", "PhatDuKien", "N0", DataGridViewContentAlignment.MiddleRight);
        }

        private void TaiDuLieu()
        {
        }
    }
}
