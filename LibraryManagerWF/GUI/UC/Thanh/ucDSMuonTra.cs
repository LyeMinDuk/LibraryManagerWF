using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    public partial class ucDSMuonTra : UserControl
    {
        //private readonly LocMuon _loc;

        //public ucDSMuonTra()
        //    : this(LocMuon.TatCa)
        //{
        //}

        //public ucDSMuonTra(LocMuon loc)
        //{
        //    InitializeComponent();
        //    _loc = loc;
        //    Load += ucDSMuonTra_Load;
        //}

        //private void ucDSMuonTra_Load(object sender, EventArgs e)
        //{
        //    CauHinhLuoi();
        //    btnTimKiem.Click += btnTimKiem_Click;
        //    btnLamMoi.Click += btnLamMoi_Click;
        //    txtTimKiem.KeyDown += txtTimKiem_KeyDown;
        //    dgv.DataBindingComplete += dgv_DataBindingComplete;


        //    TaiDuLieu();
        //}

        //private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    ToMauTinhTrang();
        //}

        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    TaiDuLieu();
        //}

        //private void btnLamMoi_Click(object sender, EventArgs e)
        //{
        //    txtTimKiem.Clear();
        //    TaiDuLieu();
        //    txtTimKiem.Focus();
        //}

        //private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode != Keys.Enter) return;

        //    e.SuppressKeyPress = true;
        //    TaiDuLieu();
        //}

        //private void CauHinhLuoi()
        //{
        //    GridStyle.Apply(dgv);
        //    //GridStyle.AddText(dgv, "Mã CT mượn", "MaCTM", null, DataGridViewContentAlignment.MiddleCenter);
        //    //GridStyle.AddText(dgv, "Mã phiếu", "MaPM", null, DataGridViewContentAlignment.MiddleCenter);
        //    GridStyle.AddText(dgv, "Mã độc giả", "MaDG", null, DataGridViewContentAlignment.MiddleCenter);
        //    GridStyle.AddFill(dgv, "Độc giả", "HoTenDG", 150);
        //    GridStyle.AddText(dgv, "SĐT", "SDT");
        //    GridStyle.AddText(dgv, "Mã thẻ", "MaThe", null, DataGridViewContentAlignment.MiddleCenter);
        //    //GridStyle.AddText(dgv, "Mã sách", "MaSach", null, DataGridViewContentAlignment.MiddleCenter);
        //    GridStyle.AddFill(dgv, "Tên sách", "TenSach", 180);
        //    //GridStyle.AddText(dgv, "Giá bìa", "GiaBia", "N0", DataGridViewContentAlignment.MiddleRight);
        //    GridStyle.AddText(dgv, "Ngày mượn", "NgayMuon", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
        //    //GridStyle.AddText(dgv, "Hạn trả", "HanTra", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
        //    //GridStyle.AddText(dgv, "Gia hạn", "SoLanGiaHan", null, DataGridViewContentAlignment.MiddleCenter);
        //    GridStyle.AddText(dgv, "Ngày trả", "NgayTra", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
        //    GridStyle.AddText(dgv, "Tình trạng", "TinhTrang");
            
        //    //GridStyle.AddText(dgv, "Quá hạn", "QuaHan");
        //    GridStyle.AddText(dgv, "Số ngày trễ", "SoNgayTre", null, DataGridViewContentAlignment.MiddleCenter);
        //    GridStyle.AddText(dgv, "Phạt dự kiến", "PhatDuKien", "N0", DataGridViewContentAlignment.MiddleRight);
        //}

        //private void TaiDuLieu()
        //{
        //    Result<List<MuonHienThi>> result = TheoDoiBLL.TimKiem(
        //        txtTimKiem.Text.Trim(), null, null, _loc);
        //    if (!result.Ok)
        //    {
        //        MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    dgv.DataSource = null;
        //    dgv.DataSource = result.Data;

        //    dgv.ClearSelection();
        //}

        //private void ToMauTinhTrang()
        //{
        //    foreach (DataGridViewRow row in dgv.Rows)
        //    {
        //        string tt = Convert.ToString(row.Cells["TinhTrang"].Value).Trim();

        //        switch (tt)
        //        {
        //            case Constants.TinhTrang.ChuaTra:
        //                row.DefaultCellStyle.BackColor = Color.Khaki;
        //                row.DefaultCellStyle.SelectionBackColor = Color.Khaki;
        //                row.DefaultCellStyle.ForeColor = Color.Black;
        //                row.DefaultCellStyle.SelectionForeColor = Color.Black;
        //                break;

        //            case Constants.TinhTrang.Mat:
        //                row.DefaultCellStyle.BackColor = Color.IndianRed;
        //                row.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
        //                row.DefaultCellStyle.ForeColor = Color.White;
        //                row.DefaultCellStyle.SelectionForeColor = Color.White;
        //                break;

        //            case Constants.TinhTrang.Hong:
        //                row.DefaultCellStyle.BackColor = Color.Orange;
        //                row.DefaultCellStyle.SelectionBackColor = Color.Orange;
        //                row.DefaultCellStyle.ForeColor = Color.Black;
        //                row.DefaultCellStyle.SelectionForeColor = Color.Black;
        //                break;

        //            case Constants.TinhTrang.BinhThuong:
        //                row.DefaultCellStyle.BackColor = Color.LightGreen;
        //                row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
        //                row.DefaultCellStyle.ForeColor = Color.Black;
        //                row.DefaultCellStyle.SelectionForeColor = Color.Black;
        //                break;
        //        }
        //    }
        //}
    }
}
