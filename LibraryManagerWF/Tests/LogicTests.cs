using System;
using LibraryManagerWF.BLL;
using LibraryManagerWF.DTO;

class LogicTests
{
    static int ok = 0, bad = 0;

    static void Eq(object mongDoi, object thucTe, string ten)
    {
        if (Equals(mongDoi, thucTe))
            ok++;
        else
        {
            bad++;
            Console.WriteLine("FAIL: " + ten + "  (mong doi " + mongDoi + ", thuc te " + thucTe + ")");
        }
    }

    static void BiChan(Action f, string ten)
    {
        bool nem = false;
        try
        {
            f();
        }
        catch (UnauthorizedAccessException)
        {
            nem = true;
        }
        Eq(true, nem, ten);
    }

    static void Main()
    {
        DateTime today = DateTime.Today;

        Eq(16, TinhPhatBLL.SoNgayTre(today.AddDays(-16), today), "Tre 16 ngay");
        Eq(0, TinhPhatBLL.SoNgayTre(today, today), "Dung han = 0 ngay");
        Eq(0, TinhPhatBLL.SoNgayTre(today.AddDays(3), today), "Truoc han = 0 ngay");

        Eq(32000m, TinhPhatBLL.TienPhatTre(120000m, 16, 2000), "Phat 16 ngay");
        Eq(0m, TinhPhatBLL.TienPhatTre(79000m, 0, 2000), "Dung han khong phat");
        Eq(45000m, TinhPhatBLL.TienPhatTre(45000m, 40, 2000), "Phat toi da bang gia bia");

        Eq(60000m, TinhPhatBLL.TienDen(120000m, 50), "Den hong 50%");
        Eq(120000m, TinhPhatBLL.TienDen(120000m, 100), "Den mat 100%");
        Eq(39501m, TinhPhatBLL.TienDen(79001m, 50), "Lam tron nua len (39500.5 -> 39501)");

        Eq("Hoạt động", TheBLL.TinhTrangThe(true, today), "The het han dung hom nay = hoat dong");
        Eq("Hết hạn", TheBLL.TinhTrangThe(true, today.AddDays(-1)), "The het han hom qua");
        Eq("Khóa", TheBLL.TinhTrangThe(false, today.AddDays(30)), "The khoa");
        Eq("Khóa", TheBLL.TinhTrangThe(false, today.AddDays(-30)), "The khoa va het han = khoa");

        Func<string, string, int, int?, decimal, int, SachDTO> sach = (ten, tg, tl, nam, gia, sl) =>
            new SachDTO { TenSach = ten, TacGia = tg, MaTL = tl, NamXB = nam, GiaBia = gia, SoLuongTong = sl };
        Eq(null, SachBLL.KiemTra(sach("Dế Mèn", "Tô Hoài", 1, 2020, 50000m, 3)), "Sach hop le");
        Eq(true, SachBLL.KiemTra(sach("", "Tô Hoài", 1, null, 50000m, 3)) != null, "Thieu ten sach");
        Eq(true, SachBLL.KiemTra(sach("A", "B", 1, null, 0m, 3)) != null, "Gia bia = 0");
        Eq(true, SachBLL.KiemTra(sach("A", "B", 1, null, 1000m, 0)) != null, "So luong = 0");
        Eq(true, SachBLL.KiemTra(sach("A", "B", 1, today.Year + 1, 1000m, 1)) != null, "Nam xuat ban tuong lai");

        Func<DateTime, string, string, DocGiaDTO> dg = (ns, sdt, email) =>
            new DocGiaDTO { HoTen = "Nguyễn Văn A", NgaySinh = ns, GioiTinh = "Nam", SDT = sdt, Email = email };
        Eq(null, DocGiaBLL.KiemTra(dg(new DateTime(2000, 1, 1), "0912345678", null)), "Doc gia hop le");
        Eq(true, DocGiaBLL.KiemTra(dg(new DateTime(2000, 1, 1), "091234567", null)) != null, "SDT 9 so");
        Eq(true, DocGiaBLL.KiemTra(dg(new DateTime(2000, 1, 1), "0912345678", "abc")) != null, "Email sai");
        Eq(true, DocGiaBLL.KiemTra(dg(today, "0912345678", null)) != null, "Ngay sinh = hom nay");

        string h = AuthBLL.TaoMatKhauHash("abc123");
        Eq(true, AuthBLL.KiemTraMatKhau("abc123", h), "Hash dung");
        Eq(false, AuthBLL.KiemTraMatKhau("abc124", h), "Hash sai");
        Eq(true, AuthBLL.TaoMatKhauHash("abc123") != h, "Cung mat khau, salt khac nen hash khac");
        Eq(false, AuthBLL.KiemTraMatKhau("abc123", "khong-co-dau-do-la"), "Hash luu sai dinh dang");
        Eq(true, AuthBLL.KiemTraMatKhau("abc123", h.ToLower()), "Hash luu chu thuong van khop");
        Eq(false, AuthBLL.KiemTraMatKhau("abc123", h.Substring(0, h.Length - 2)), "Hash bi cat ngan");
        Eq(true, AuthBLL.KiemTraMatKhauMoi("12345") != null, "Mat khau moi 5 ky tu");
        Eq(null, AuthBLL.KiemTraMatKhauMoi("123456"), "Mat khau moi 6 ky tu");

        Eq(true, AuthBLL.KiemTraMatKhau("admin123", "a1b2c3d4e5f60718$9879A6C081970A685052BDAF0CBA84347009C2F6F758C7A05257F5DCD6485CA8"), "Seed admin");
        Eq(true, AuthBLL.KiemTraMatKhau("123456", "0f9e8d7c6b5a4321$D6E0E3A70926BD813BA5F7068928C05540DC0D0F312CC8958546C596E926052B"), "Seed thuthu1");

        AuthBLL.DangXuat();
        decimal phat, den;
        DateTime han;
        BiChan(() => TraBLL.Tra(1, TinhTrangMuon.BinhThuong, true, out phat, out den), "Tra khi chua dang nhap");
        BiChan(() => MuonBLL.Muon(1, new System.Collections.Generic.List<int> { 1 }, out han), "Muon khi chua dang nhap");
        BiChan(() => SachBLL.Xoa(1), "Xoa sach khi chua dang nhap");
        BiChan(() => TaiKhoanBLL.LayTatCa(), "Xem tai khoan khi chua dang nhap");

        AppSession.MaTK = 2; AppSession.HoTen = "Thủ thư"; AppSession.VaiTro = VaiTro.ThuThu;
        BiChan(() => TaiKhoanBLL.LayTatCa(), "ThuThu xem tai khoan");
        BiChan(() => TaiKhoanBLL.Them("abc", "123456", "A", VaiTro.ThuThu), "ThuThu them tai khoan");
        BiChan(() => CauHinhBLL.CapNhat("PHI_THE", "1000"), "ThuThu doi cau hinh");
        BiChan(() => PhieuThuBLL.DoanhThuTheoLoai(today, today), "ThuThu xem doanh thu");

        AppSession.VaiTro = VaiTro.QuanTri;
        bool qua = true;
        try
        {
            Quyen.YeuCauDangNhap();
            Quyen.YeuCauQuanTri();
        }
        catch (UnauthorizedAccessException)
        {
            qua = false;
        }
        Eq(true, qua, "QuanTri qua ca hai muc quyen");
        AuthBLL.DangXuat();

        Console.WriteLine("PASS: " + ok + "  FAIL: " + bad);
    }
}
