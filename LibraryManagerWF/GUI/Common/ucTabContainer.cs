using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// UC "cha" dùng chung cho mọi module: thanh tiêu đề (đổi màu theo trạng thái của UC con) + hàng nút chuyển tab + vùng nội dung.
    /// Thay cho 3 UC cha giống hệt nhau của bản cũ (ucFrmQuanLyTaiLieu / BanDoc / PhanQuyen).
    /// </summary>
    public partial class ucTabContainer : UserControl
    {
        private readonly List<Button> _nut = new List<Button>();
        private readonly string _tieuDeMacDinh;
        private Button _dangChon;

        public ucTabContainer() : this("QUẢN LÝ", new TabInfo[0])
        {
        }

        public ucTabContainer(string tieuDeMacDinh, params TabInfo[] tabs)
        {
            InitializeComponent();
            _tieuDeMacDinh = tieuDeMacDinh;
            DatTieuDe(tieuDeMacDinh, MauTrangThai.Xem, Color.White);

            foreach (TabInfo t in tabs)
            {
                TabInfo tab = t;
                var nut = new Button
                {
                    Text = tab.Ten,
                    Size = new Size(190, 36),
                    Margin = new Padding(0, 0, 8, 0),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Consolas", 12F),
                    Cursor = Cursors.Hand,
                    TabStop = false
                };
                nut.FlatAppearance.BorderColor = Color.FromArgb(48, 52, 129);
                nut.Click += (s, e) => ChonTab(nut, tab);
                KieuThuong(nut);
                _nut.Add(nut);
                flpTab.Controls.Add(nut);
            }
            Load += (s, e) => { if (_nut.Count > 0) _nut[0].PerformClick(); };
        }

        private static void KieuThuong(Button b)
        {
            b.BackColor = Color.WhiteSmoke;
            b.ForeColor = Color.FromArgb(48, 52, 129);
            b.Font = new Font("Consolas", 12F, FontStyle.Regular);
        }

        private void ChonTab(Button nut, TabInfo tab)
        {
            if (_dangChon != null) KieuThuong(_dangChon);
            _dangChon = nut;
            nut.BackColor = Color.FromArgb(48, 52, 129);
            nut.ForeColor = Color.White;
            nut.Font = new Font("Consolas", 12F, FontStyle.Bold);

            pnlNoiDung.SuspendLayout();
            foreach (Control c in pnlNoiDung.Controls.Cast<Control>().ToList())
            {
                pnlNoiDung.Controls.Remove(c);
                c.Dispose();
            }
            UserControl uc = tab.Tao();
            uc.Dock = DockStyle.Fill;
            var pt = uc as IPhatTrangThai;
            if (pt != null) pt.OnStatusRequest += (s, e) => DatTieuDe(e.TitleText, e.BackColor, e.ForeColor);
            else DatTieuDe(_tieuDeMacDinh, MauTrangThai.Xem, Color.White);
            pnlNoiDung.Controls.Add(uc);
            pnlNoiDung.ResumeLayout();
        }

        private void DatTieuDe(string chu, Color nen, Color mau)
        {
            pnlTieuDe.BackColor = nen;
            lblTieuDe.ForeColor = mau;
            lblTieuDe.Text = chu;
        }
    }

}
