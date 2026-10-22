using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Phiếu thu khi trả sách: hiện độc giả, mã thẻ, sách, tình trạng, phạt trễ, đền bù, tổng cộng.
    /// Có thể in bản xem trước trước khi trả sách; chỉ nút "Trả sách" mới ghi nhận trả sách và phiếu thu.
    /// Cách dùng (nhúng vào form/dialog): uc.Nap(maCTM, hoTen, maThe, tenSach, tinhTrangBanDau);
    /// lắng nghe DaTraSach (đã trả xong) và Dong (bấm Hủy) để đóng/tải lại danh sách.
    /// </summary>
    public partial class ucTaoPhieuThu : UserControl
    {
        private int _maCTM;
        private int _maThe;
        private string _hoTen, _tenSach;
        private decimal _phat, _den;
        private string _GC;
        private bool _daTra;
        private string _tinhTrangDaTra;
        private DateTime _ngayTra;

        /// <summary>Đã trả sách và lập phiếu thu thành công.</summary>
        public event EventHandler DaTraSach;
        /// <summary>Bấm nút Hủy (hoặc nên đóng khung chứa).</summary>
        public event EventHandler Dong;

        public ucTaoPhieuThu()
        {
            InitializeComponent();
            CauHinhGiaoDien();
            cboTinhTrang.Items.AddRange(new object[] { TinhTrangMuon.BinhThuong, TinhTrangMuon.Hong, TinhTrangMuon.Mat });
            cboTinhTrang.SelectedIndex = 0;
            cboTinhTrang.SelectedIndexChanged += (s, e) => TinhTien();
            btnTra.Click += btnTra_Click;
            btnHuy.Click += (s, e) => { if (Dong != null) Dong(this, EventArgs.Empty); };
            btnIn.Click += btnIn_Click;
            btnIn.Enabled = false;
        }

        private void CauHinhGiaoDien()
        {
            Font = Theme.MakeFont(12f);
            foreach (Label l in new[] { lblDocGia, lblMaThe, lblMaCT, lblSach, lblTinhTrang, lblPhatTre, lblDenBu })
                l.Font = Theme.MakeFont(12f);
            foreach (Label l in new[] { valDocGia, valMaThe, valMaCT, valSach })
            {
                l.Font = Theme.MakeFont(13f, FontStyle.Bold);
                l.ForeColor = Theme.Chu;
                l.AutoEllipsis = true;
            }
            cboTinhTrang.Font = Theme.MakeFont(13f, FontStyle.Bold);
            lblCachTinhPhat.Font = Theme.MakeFont(9.5f, FontStyle.Italic);
            lblCachTinhDen.Font = Theme.MakeFont(9.5f, FontStyle.Italic);
            valPhatTre.Font = Theme.MakeFont(13f);
            valDenBu.Font = Theme.MakeFont(13f);
            lblTongCong.Font = Theme.MakeFont(14f, FontStyle.Bold);
            lblTongCong.ForeColor = Theme.Chu;
            valTong.Font = Theme.MakeFont(24f, FontStyle.Bold);

            btnTra.Font = Theme.MakeFont(12f, FontStyle.Bold);
            btnTra.FlatAppearance.BorderSize = 0;
            btnHuy.Font = Theme.MakeFont(12f);
            btnHuy.ForeColor = Theme.Chu;
            btnHuy.FlatAppearance.BorderColor = Color.FromArgb(190, 195, 200);
            btnIn.Font = Theme.MakeFont(12f);
            btnIn.ForeColor = Theme.Accent;
            btnIn.FlatAppearance.BorderColor = Theme.Accent;
        }

        /// <summary>Nạp một cuốn đang mượn để lập phiếu thu / trả sách.</summary>
        public void Nap(int maCTM, string hoTen, int maThe, string tenSach, string tinhTrang = null)
        {
            _maCTM = maCTM;
            _maThe = maThe;
            _hoTen = hoTen;
            _tenSach = tenSach;
            _daTra = false;
            valDocGia.Text = hoTen;
            valMaThe.Text = maThe.ToString();
            valMaCT.Text = maCTM.ToString();
            btnHuy.Text = "Hủy";
            valSach.Text = tenSach;

            cboTinhTrang.Enabled = true;
            if (!string.IsNullOrEmpty(tinhTrang) && cboTinhTrang.Items.Contains(tinhTrang))
                cboTinhTrang.SelectedItem = tinhTrang;
            else
                cboTinhTrang.SelectedIndex = 0;

            btnIn.Enabled = true;
            btnTra.Enabled = true;
            TinhTien();
        }

        // Xem trước (chưa ghi gì) qua TraBLL.XemTruoc
        private void TinhTien()
        {
            if (_maCTM == 0 || _daTra) return;

            string loi = TraBLL.XemTruoc(_maCTM, (string)cboTinhTrang.SelectedItem, out _phat, out _den);
            if (loi != null)
            {
                _phat = _den = 0;
                HienTien();
                btnTra.Enabled = false;
                //
                btnIn.Enabled = false;
                MessageBox.Show(loi, "Không thể lập phiếu thu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnTra.Enabled = true;
            HienTien();
        }

        private void HienTien()
        {
            valPhatTre.Text = _phat.ToString("N0") + "đ";
            valDenBu.Text = _den.ToString("N0") + "đ";
            valTong.Text = (_phat + _den).ToString("N0") + "đ";
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            _GC = rtbGC.Text.Trim();
            string tinhTrang = (string)cboTinhTrang.SelectedItem;
            decimal tong = _phat + _den;
            string hoi = tong > 0
                ? string.Format("Trả \"{0}\" ({1}).\nPhải thu {2:N0}đ. Đã thu đủ tiền của độc giả chưa?", _tenSach, tinhTrang, tong)
                : string.Format("Xác nhận trả \"{0}\" ({1})?", _tenSach, tinhTrang);
            if (MessageBox.Show(hoi, "Xác nhận trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            decimal phat, den;
            

            string loi = TraBLL.Tra(_maCTM, tinhTrang, true, out phat, out den, _GC);
            if (loi != null)
            {
                MessageBox.Show(loi, "Không thể trả sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _phat = phat;
            _den = den;
            _daTra = true;
            _tinhTrangDaTra = tinhTrang;
            _ngayTra = DateTime.Now;
            HienTien();

            cboTinhTrang.Enabled = false;
            btnTra.Enabled = false;
            btnIn.Enabled = true;
            btnHuy.Text = "Đóng";

            MessageBox.Show(tong > 0 ? "Đã trả sách và lập phiếu thu." : "Đã trả sách.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (DaTraSach != null) DaTraSach(this, EventArgs.Empty);
        }

        // ===== In hóa đơn =====

        private void btnIn_Click(object sender, EventArgs e)
        {
            _ngayTra = DateTime.Now;
            new HoaDonTraSach
            {
                HoTen = _hoTen,
                MaThe = _maThe,
                MaCTM = _maCTM,
                TenSach = _tenSach,
                TinhTrang = _daTra ? _tinhTrangDaTra : (string)cboTinhTrang.SelectedItem,
                Phat = _phat,
                Den = _den,
                Ngay = _daTra ? _ngayTra : DateTime.Now
            }.XemTruocVaIn(this);
        }
    }
}
