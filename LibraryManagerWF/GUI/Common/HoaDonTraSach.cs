using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using LibraryManagerWF.BLL;

namespace LibraryManagerWF.GUI
{
    /// <summary>
    /// Hóa đơn trả sách (khổ ~80mm): giữ dữ liệu cần in và lo phần vẽ/in.
    /// Dùng: new HoaDonTraSach { ... }.XemTruocVaIn(this);
    /// Chỉ vẽ ra giấy, không đụng CSDL hay giao diện nên dùng lại được ở bất kỳ màn hình nào.
    /// </summary>
    public class HoaDonTraSach
    {
        public string HoTen { get; set; }
        public int MaThe { get; set; }
        public int MaCTM { get; set; }
        public string TenSach { get; set; }
        public string TinhTrang { get; set; }
        public decimal Phat { get; set; }
        public decimal Den { get; set; }
        public DateTime Ngay { get; set; }

        /// <summary>Mở cửa sổ xem trước; bấm biểu tượng máy in trong đó để in thật.</summary>
        public void XemTruocVaIn(IWin32Window chu)
        {
            using (var pd = new PrintDocument())
            using (var xem = new PrintPreviewDialog())
            {
                pd.DocumentName = "Hoa don tra sach";
                pd.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 315, 600);   // khổ ~80mm
                pd.DefaultPageSettings.Margins = new Margins(15, 15, 20, 20);
                pd.PrintPage += InTrang;
                xem.Document = pd;
                xem.Width = 520;
                xem.Height = 780;
                xem.ShowDialog(chu);
            }
        }

        private void InTrang(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = e.MarginBounds.Left, w = e.MarginBounds.Width, y = e.MarginBounds.Top;
            using (Font fT = new Font("Segoe UI", 13f, FontStyle.Bold))
            using (Font fB = new Font("Segoe UI", 9.5f))
            using (Font fD = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Font fGhiChu = new Font("Segoe UI", 8f, FontStyle.Italic))
            using (Font fTong = new Font("Segoe UI", 12f, FontStyle.Bold))
            using (var giua = new StringFormat { Alignment = StringAlignment.Center })
            using (var phai = new StringFormat { Alignment = StringAlignment.Far })
            using (var trai = new StringFormat { Trimming = StringTrimming.EllipsisCharacter })
            {
                g.DrawString("HÓA ĐƠN TRẢ SÁCH", fT, Brushes.Black, new RectangleF(x, y, w, 26), giua); y += 30;
                g.DrawString("Thư viện", fB, Brushes.Black, new RectangleF(x, y, w, 18), giua); y += 22;
                g.DrawString(Ngay.ToString("dd/MM/yyyy HH:mm"), fB, Brushes.Black, new RectangleF(x, y, w, 18), giua); y += 22;
                y = Gach(g, x, w, y);

                y = Dong2(g, "Độc giả:", HoTen, fB, fD, x, w, y);
                y = Dong2(g, "Mã thẻ:", MaThe.ToString(), fB, fD, x, w, y);
                y = Dong2(g, "Sách:", TenSach, fB, fD, x, w, y);
                y = Dong2(g, "Tình trạng:", TinhTrang, fB, fD, x, w, y);
                y = Dong2(g, "Mã cuốn mượn:", MaCTM.ToString(), fB, fD, x, w, y);
                y = Gach(g, x, w, y);

                y = Dong2(g, "Phạt trễ", Phat.ToString("N0") + "đ", fB, fB, x, w, y);
                y = DongGhiChu(g, "Phạt trả trễ: 2.000đ/cuốn/ngày (tối đa bằng giá bìa)", fGhiChu, x, w, y);

                y = Dong2(g, "Đền bù", Den.ToString("N0") + "đ", fB, fB, x, w, y);
                y = DongGhiChu(g, "Đền bù: sách hỏng 50% giá bìa · sách mất 100% giá bìa", fGhiChu, x, w, y);
                y = Gach(g, x, w, y);

                g.DrawString("Tổng cộng", fTong, Brushes.Black, new RectangleF(x, y, w * 0.5f, 24), trai);
                g.DrawString((Phat + Den).ToString("N0") + "đ", fTong, Brushes.Black, new RectangleF(x, y, w, 24), phai);
                y += 34;
                y = Gach(g, x, w, y);

                g.DrawString("Thu ngân: " + AppSession.HoTen, fB, Brushes.Black, new RectangleF(x, y, w, 18), trai); y += 24;
                g.DrawString("Cảm ơn quý độc giả!", fB, Brushes.Black, new RectangleF(x, y, w, 18), giua);
            }
            e.HasMorePages = false;
        }

        private static float Gach(Graphics g, float x, float w, float y)
        {
            using (var p = new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                g.DrawLine(p, x, y + 4, x + w, y + 4);
            return y + 12;
        }

        private static float Dong2(Graphics g, string nhan, string giaTri, Font fN, Font fG, float x, float w, float y)
        {
            using (var phai = new StringFormat { Alignment = StringAlignment.Far, Trimming = StringTrimming.EllipsisCharacter })
            {
                g.DrawString(nhan, fN, Brushes.Black, x, y);
                g.DrawString(giaTri, fG, Brushes.Black, new RectangleF(x + w * 0.38f, y, w * 0.62f, 20), phai);
            }
            return y + 22;
        }

        private static float DongGhiChu(Graphics g, string text, Font font, float x, float w, float y)
        {
            using (var giua = new StringFormat { Alignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter })
            {
                float height = Math.Max(16f, g.MeasureString(text, font, new SizeF(w, 1000f)).Height);
                g.DrawString(text, font, Brushes.DimGray, new RectangleF(x, y, w, height), giua);
                return y + height + 2;
            }
        }
    }
}
