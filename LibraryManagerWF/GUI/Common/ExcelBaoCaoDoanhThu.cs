using System;
using System.Data;
using System.Drawing;
using ClosedXML.Excel;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.GUI
{
    public static class ExcelBaoCaoDoanhThu
    {
        const string FmtTien = "#,##0\" đ\"";
        const string FmtTienCoGach = "#,##0\" đ\";-#,##0\" đ\";\"-\"";

        static readonly string[] Thu = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };

        public static void Xuat(string duongDan, DateTime tuNgay, DateTime denNgay,
            DataTable theoLoai, DataTable theoNgay, DataTable chiTiet)
        {
            tuNgay = tuNgay.Date;
            denNgay = denNgay.Date;

            using (var wb = new XLWorkbook())
            {
                wb.Properties.Title = "Báo cáo doanh thu";
                wb.Properties.Author = AppSession.HoTen ?? "";

                VeSheetBaoCao(wb.Worksheets.Add("Báo cáo doanh thu"), tuNgay, denNgay, theoLoai, theoNgay);
                VeSheetChiTiet(wb.Worksheets.Add("Chi tiết phiếu thu"), tuNgay, denNgay, chiTiet);

                wb.SaveAs(duongDan);
            }
        }

        static void VeSheetBaoCao(IXLWorksheet ws, DateTime tu, DateTime den,
            DataTable theoLoai, DataTable theoNgay)
        {
            double[] rong = { 2, 8, 24, 16, 20, 16, 3 };
            for (int i = 0; i < rong.Length; i++)
                ws.Column(i + 1).Width = rong[i];

            decimal tongTien = 0; int tongPhieu = 0;
            foreach (DataRow r in theoLoai.Rows)
            {
                tongTien += Convert.ToDecimal(r["TongTien"]);
                tongPhieu += Convert.ToInt32(r["SoPhieu"]);
            }
            ws.Cell("B1").Value = "BÁO CÁO DOANH THU";
            ws.Cell("B1").Style.Font.Bold = true;
            ws.Cell("B2").Value = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tu, den);

            int r0 = 4;
            TieuDeMuc(ws, r0, "I. DOANH THU THEO LOẠI THU");
            Header(ws, r0 + 1, "STT", "Loại thu", "Số phiếu", "Tổng tiền", "Tỷ trọng");

            int row = r0 + 2;
            int stt = 1;
            foreach (DataRow r in theoLoai.Rows)
            {
                string loai = Convert.ToString(r["LoaiThu"]);
                decimal tien = Convert.ToDecimal(r["TongTien"]);
                ws.Cell(row, 2).Value = stt++;
                ws.Cell(row, 3).Value = loai;
                ws.Cell(row, 4).Value = Convert.ToInt32(r["SoPhieu"]);
                ws.Cell(row, 5).Value = (double)tien;
                ws.Cell(row, 6).Value = tongTien > 0 ? (double)(tien / tongTien) : 0.0;

                var hang = ws.Range(row, 2, row, 6);
                hang.Style.Fill.BackgroundColor = XLColor.FromColor(MauLoai(loai));
                ws.Cell(row, 5).Style.NumberFormat.Format = FmtTien;
                ws.Cell(row, 6).Style.NumberFormat.Format = "0.0%";
                CanLe(ws, row, true);
                row++;
            }
            if (theoLoai.Rows.Count == 0)
            {
                var trong = ws.Range(row, 2, row, 6).Merge();
                trong.FirstCell().Value = "Không có phiếu thu nào trong khoảng ngày đã chọn.";
                row++;
            }
            TongCong(ws, row, tongPhieu, tongTien, true);
            row += 2;

            TieuDeMuc(ws, row, "II. DOANH THU THEO TỪNG NGÀY");
            Header(ws, row + 1, "STT", "Ngày", "Thứ", "Số phiếu", "Tổng tiền");
            int dauNgay = row + 2;

            row = dauNgay;
            stt = 1;
            foreach (DataRow r in theoNgay.Rows)
            {
                DateTime d = Convert.ToDateTime(r["Ngay"]).Date;
                ws.Cell(row, 2).Value = stt++;
                ws.Cell(row, 3).Value = d;
                ws.Cell(row, 3).Style.DateFormat.Format = "dd/MM/yyyy";
                ws.Cell(row, 4).Value = Thu[(int)d.DayOfWeek];
                ws.Cell(row, 5).Value = Convert.ToInt32(r["SoPhieu"]);
                ws.Cell(row, 6).Value = (double)Convert.ToDecimal(r["TongTien"]);
                ws.Cell(row, 6).Style.NumberFormat.Format = FmtTienCoGach;
                ws.Cell(row, 5).Style.NumberFormat.Format = "0;-0;\"-\"";

                CanLe(ws, row, false);
                row++;
            }
            TongCong(ws, row, tongPhieu, tongTien, false);

            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
            ws.PageSetup.PagesWide = 1;
            ws.PageSetup.PagesTall = 0;
            ws.PageSetup.CenterHorizontally = true;
        }

        static void VeSheetChiTiet(IXLWorksheet ws, DateTime tu, DateTime den, DataTable ct)
        {
            double[] rong = { 2, 10, 18, 20, 18, 10, 10, 22, 34 };
            for (int i = 0; i < rong.Length; i++)
                ws.Column(i + 1).Width = rong[i];

            ws.Cell("B1").Value = "CHI TIẾT PHIẾU THU";
            ws.Cell("B1").Style.Font.Bold = true;
            ws.Cell("B2").Value = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tu, den);

            string[] tieuDeCot = { "Mã PT", "Ngày thu", "Loại thu", "Số tiền", "Mã thẻ", "Mã CTM", "Người thu", "Ghi chú" };
            for (int i = 0; i < tieuDeCot.Length; i++)
            {
                var c = ws.Cell(4, i + 2);
                c.Value = tieuDeCot[i];
                c.Style.Font.Bold = true;
                c.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int row = 5;
            decimal tong = 0;
            foreach (DataRow r in ct.Rows)
            {
                string loai = Convert.ToString(r["LoaiThu"]);
                decimal tien = Convert.ToDecimal(r["SoTien"]);
                tong += tien;

                ws.Cell(row, 2).Value = Convert.ToInt32(r["MaPT"]);
                ws.Cell(row, 3).Value = Convert.ToDateTime(r["NgayThu"]);
                ws.Cell(row, 3).Style.DateFormat.Format = "dd/MM/yyyy HH:mm";
                ws.Cell(row, 4).Value = loai;
                ws.Cell(row, 5).Value = (double)tien;
                ws.Cell(row, 5).Style.NumberFormat.Format = FmtTien;
                if (r["MaThe"] != DBNull.Value)
                    ws.Cell(row, 6).Value = Convert.ToInt32(r["MaThe"]);
                if (r["MaCTM"] != DBNull.Value)
                    ws.Cell(row, 7).Value = Convert.ToInt32(r["MaCTM"]);
                ws.Cell(row, 8).Value = Convert.ToString(r["NguoiThu"]);
                ws.Cell(row, 9).Value = Convert.ToString(r["GhiChu"]);

                ws.Cell(row, 4).Style.Fill.BackgroundColor = XLColor.FromColor(MauLoai(loai));

                foreach (int c in new[] { 2, 3, 4, 6, 7 })
                    ws.Cell(row, c).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Row(row).Height = 20;
                row++;
            }

            var nhan = ws.Range(row, 2, row, 4).Merge();
            nhan.FirstCell().Value = string.Format("TỔNG CỘNG ({0} phiếu)", ct.Rows.Count);
            nhan.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(row, 5).Value = (double)tong;
            ws.Cell(row, 5).Style.NumberFormat.Format = FmtTien;
            ws.Cell(row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            var tr = ws.Range(row, 2, row, 9);
            tr.Style.Font.Bold = true;

            ws.SheetView.FreezeRows(4);
            ws.Range(4, 2, row - 1, 9).SetAutoFilter();

            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
            ws.PageSetup.PagesWide = 1;
            ws.PageSetup.PagesTall = 0;
            ws.PageSetup.SetRowsToRepeatAtTop(4, 4);
        }

        static Color MauLoai(string loai)
        {
            if (loai == LoaiThu.PhiThe)
                return Theme.HangNhan;
            if (loai == LoaiThu.PhatTre)
                return Theme.HangCanhBao;
            if (loai == LoaiThu.DenBu)
                return Theme.HangCam;
            return Color.White;
        }

        static void TieuDeMuc(IXLWorksheet ws, int row, string text)
        {
            ws.Cell(row, 2).Value = text;
            ws.Cell(row, 2).Style.Font.Bold = true;
        }

        static void Header(IXLWorksheet ws, int row, params string[] cot)
        {
            for (int i = 0; i < cot.Length; i++)
            {
                var c = ws.Cell(row, i + 2);
                c.Value = cot[i];
                c.Style.Font.Bold = true;
                c.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }
        }

        static void CanLe(IXLWorksheet ws, int row, bool bangLoai)
        {
            ws.Cell(row, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(row, 3).Style.Alignment.Horizontal = bangLoai ? XLAlignmentHorizontalValues.Left : XLAlignmentHorizontalValues.Center;
            ws.Cell(row, 4).Style.Alignment.Horizontal = bangLoai ? XLAlignmentHorizontalValues.Center : XLAlignmentHorizontalValues.Left;
            ws.Cell(row, 5).Style.Alignment.Horizontal = bangLoai ? XLAlignmentHorizontalValues.Right : XLAlignmentHorizontalValues.Center;
            ws.Cell(row, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            ws.Cell(row, 3).Style.Alignment.Indent = bangLoai ? 1 : 0;
            ws.Row(row).Height = 20;
            ws.Range(row, 2, row, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        }

        static void TongCong(IXLWorksheet ws, int row, int tongPhieu, decimal tongTien, bool bangLoai)
        {
            var nhan = ws.Range(row, 2, row, bangLoai ? 3 : 4).Merge();
            nhan.FirstCell().Value = "TỔNG CỘNG";
            nhan.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            if (bangLoai)
            {
                ws.Cell(row, 4).Value = tongPhieu;
                ws.Cell(row, 5).Value = (double)tongTien;
                ws.Cell(row, 5).Style.NumberFormat.Format = FmtTien;
                ws.Cell(row, 6).Value = tongTien > 0 ? 1.0 : 0.0;
                ws.Cell(row, 6).Style.NumberFormat.Format = "0.0%";
                ws.Cell(row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            }
            else
            {
                ws.Cell(row, 5).Value = tongPhieu;
                ws.Cell(row, 6).Value = (double)tongTien;
                ws.Cell(row, 6).Style.NumberFormat.Format = FmtTien;
                ws.Cell(row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }
            ws.Cell(row, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            var h = ws.Range(row, 2, row, 6);
            h.Style.Font.Bold = true;
            h.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        }
    }
}
