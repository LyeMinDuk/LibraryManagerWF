using LibraryManagerWF.BLL;
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
    public partial class ucThongTinPhieuThu : UserControl
    {
        public ucThongTinPhieuThu()
        {
            InitializeComponent();
        }
        //public ucThongTinPhieuThu()
        //{
        //    InitializeComponent();
        //    Load += ucQuanLyPhieuThu_Load;
        //}

        //private void ucQuanLyPhieuThu_Load(object sender, EventArgs e)
        //{
        //    CauHinhLuoi();
        //    DoCombobox();
        //    btnTimKiem.Click += btnTimKiem_Click;
        //    btnLamMoi.Click += btnLamMoi_Click;
        //    cboLoaiThu.SelectedIndexChanged += cboLoaiThu_SelectedIndexChanged;


        //    TaiDuLieu();
        //}

        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    TaiDuLieu();
        //}

        //private void btnLamMoi_Click(object sender, EventArgs e)
        //{

        //}

        //private void cboLoaiThu_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    TaiDuLieu();
        //}

        //private void dgvPhieuThu_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (!(dgv.CurrentRow?.DataBoundItem is PhieuThu pt))
        //    {
        //        return;
        //    }

        //    var kq = PhieuThuBLL.LayTheoId(pt.MaPT);
        //    if (kq.Ok) HienThiChiTiet(kq.Data);
        //}

        //private void TaiDuLieu()
        //{
        //    DateTime? tu = dtpTu.Checked ? dtpTu.Value.Date : (DateTime?)null;
        //    DateTime? den = dtpDen.Checked ? dtpDen.Value.Date : (DateTime?)null;
        //    string loai = cboLoaiThu.SelectedIndex == 0 ? null : cboLoaiThu.Text;

        //    var kq = PhieuThuBLL.TimKiem(tu, den, loai, null);
        //    if (!kq.Ok) { MessageBox.Show(kq.Message); return; }

        //    dgv.DataSource = kq.Data;
        //    lblSoPhieu.Text = $"{kq.Data.Count} phiếu thu";
        //    lblTongTien.Text = "Tổng: " + kq.Data.Sum(x => x.SoTien).ToString("N0") + "đ";
        //}

        //private void DoCombobox()
        //{
        //    cboLoaiThu.Items.Add("Tất cả");
        //    cboLoaiThu.Items.Add("Phí thẻ");
        //    cboLoaiThu.Items.Add("Phạt trễ");
        //    cboLoaiThu.Items.Add("Đền bù");
        //    cboLoaiThu.SelectedIndex = 0;
        //}

        //private void HienThiChiTiet(PhieuThu pt)
        //{
        //    //lblMaPT.Text = pt.MaPT.ToString();
        //    //lblLoaiThu.Text = pt.LoaiThu;
        //    //lblSoTien.Text = pt.SoTien.ToString("N0") + "đ";
        //    //lblNgayThu.Text = pt.NgayThu.ToString("dd/MM/yyyy HH:mm");
        //    //lblGhiChu.Text = pt.GhiChu;
        //}

        //private void CauHinhLuoi()
        //{
        //    GridStyle.Apply(dgv);

        //    DataGridViewTextBoxColumn maPT = GridStyle.AddText(
        //        dgv, "Mã PT", "MaPT", "PT00", DataGridViewContentAlignment.MiddleLeft);
        //    DataGridViewTextBoxColumn loaiThu = GridStyle.AddText(dgv, "Loại thu", "LoaiThu");
        //    DataGridViewTextBoxColumn soTien = GridStyle.AddText(
        //        dgv, "Số tiền", "SoTien", "0'đ'", DataGridViewContentAlignment.MiddleRight);
        //    DataGridViewTextBoxColumn ngayThu = GridStyle.AddText(
        //        dgv, "Ngày thu", "NgayThu", "dd/MM/yyyy HH:mm");
        //    DataGridViewTextBoxColumn ghiChu = GridStyle.AddFill(dgv, "Ghi chú", "GhiChu", 150);

        //    maPT.FillWeight = 10;
        //    loaiThu.FillWeight = 16;
        //    soTien.FillWeight = 16;
        //    ngayThu.FillWeight = 20;
        //    ghiChu.FillWeight = 38;
        //    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgv.RowTemplate.Height = 42;
        //    dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //}
    }
}
