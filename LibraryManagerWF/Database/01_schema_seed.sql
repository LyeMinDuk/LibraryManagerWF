/* =====================================================================
   LibraryDB - tạo CSDL + dữ liệu mẫu (schema 3NF, chỉ thủ thư/quản trị)
   CẢNH BÁO: script này XÓA và TẠO LẠI database LibraryDB.
   Ai đổi schema thì sửa FILE NÀY và báo cả nhóm chạy lại.
   Tài khoản mẫu: admin/admin123 (QuanTri), thuthu1/123456 (ThuThu)
   Chưa chạy thử trên SQL Server thật - hãy chạy và báo lỗi nếu có.
   ===================================================================== */
USE master;
GO
IF DB_ID(N'LibraryDB') IS NOT NULL
BEGIN
    ALTER DATABASE LibraryDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE LibraryDB;
END
GO
CREATE DATABASE LibraryDB COLLATE Vietnamese_CI_AS;
GO
USE LibraryDB;
GO
-- Bắt buộc cho filtered index (SqlClient mặc định đã ON, sqlcmd thì không)
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO

/* ---------- 1. Bảng ---------- */
CREATE TABLE TheLoai (
    MaTL  INT IDENTITY(1,1) CONSTRAINT PK_TheLoai PRIMARY KEY,
    TenTL NVARCHAR(100) NOT NULL CONSTRAINT UQ_TheLoai_Ten UNIQUE
);

CREATE TABLE Sach (
    MaSach      INT IDENTITY(1,1) CONSTRAINT PK_Sach PRIMARY KEY,
    TenSach     NVARCHAR(200) NOT NULL,
    TacGia      NVARCHAR(150) NOT NULL,
    MaTL        INT NOT NULL CONSTRAINT FK_Sach_TheLoai REFERENCES TheLoai(MaTL),
    NXB         NVARCHAR(150) NULL,
    NamXB       INT NULL CONSTRAINT CK_Sach_NamXB CHECK (NamXB IS NULL OR NamXB > 0),
    GiaBia      DECIMAL(12,0) NOT NULL CONSTRAINT CK_Sach_GiaBia CHECK (GiaBia > 0),
    SoLuongTong INT NOT NULL CONSTRAINT CK_Sach_SLTong CHECK (SoLuongTong >= 0),
    -- SoLuongCon = SoLuongTong - (số ChiTietMuon 'Chưa trả'). Dư thừa dẫn xuất CÓ KIỂM SOÁT:
    -- chỉ SachBLL và các transaction mượn/trả được sửa; đối soát bằng 02_doi_soat.sql
    SoLuongCon  INT NOT NULL CONSTRAINT CK_Sach_SLCon CHECK (SoLuongCon >= 0),
    TrangThai   BIT NOT NULL CONSTRAINT DF_Sach_TT DEFAULT 1,      -- 1 = hoạt động, 0 = khóa
    CONSTRAINT CK_Sach_Con_Tong CHECK (SoLuongCon <= SoLuongTong)
);

CREATE TABLE TaiKhoan (
    MaTK        INT IDENTITY(1,1) CONSTRAINT PK_TaiKhoan PRIMARY KEY,
    TenDN       VARCHAR(50) NOT NULL CONSTRAINT UQ_TaiKhoan_TenDN UNIQUE,
    MatKhauHash VARCHAR(200) NOT NULL,          -- dạng  salt$SHA256HEX(salt+matkhau)
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20) NOT NULL CONSTRAINT CK_TaiKhoan_VaiTro CHECK (VaiTro IN ('QuanTri','ThuThu')),
    TrangThai   BIT NOT NULL CONSTRAINT DF_TaiKhoan_TT DEFAULT 1   -- 1 = hoạt động, 0 = khóa
);

CREATE TABLE DocGia (
    MaDG      INT IDENTITY(1,1) CONSTRAINT PK_DocGia PRIMARY KEY,
    HoTen     NVARCHAR(100) NOT NULL,
    NgaySinh  DATE NOT NULL,
    GioiTinh  NVARCHAR(10) NOT NULL,
    DiaChi    NVARCHAR(200) NULL,
    SDT       VARCHAR(10) NOT NULL
              CONSTRAINT CK_DocGia_SDT CHECK (SDT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    Email     VARCHAR(100) NULL CONSTRAINT CK_DocGia_Email CHECK (Email IS NULL OR Email LIKE '_%@_%._%'),
    TrangThai BIT NOT NULL CONSTRAINT DF_DocGia_TT DEFAULT 1       -- 1 = hoạt động, 0 = khóa (chỉ đổi bằng tay)
);

CREATE TABLE TheThuVien (
    MaThe      INT IDENTITY(1,1) CONSTRAINT PK_TheThuVien PRIMARY KEY,
    MaDG       INT NOT NULL CONSTRAINT FK_The_DocGia REFERENCES DocGia(MaDG)
               CONSTRAINT UQ_The_MaDG UNIQUE,                       -- mỗi độc giả tối đa 1 thẻ
    NgayCap    DATE NOT NULL,
    NgayHetHan DATE NOT NULL,
    TrangThai  BIT NOT NULL CONSTRAINT DF_The_TT DEFAULT 1,         -- 1 = hoạt động, 0 = khóa. "Hết hạn" KHÔNG lưu, tính từ NgayHetHan
    CONSTRAINT CK_The_Ngay CHECK (NgayHetHan > NgayCap)
);

CREATE TABLE PhieuMuon (
    MaPM     INT IDENTITY(1,1) CONSTRAINT PK_PhieuMuon PRIMARY KEY,
    MaThe    INT NOT NULL CONSTRAINT FK_PM_The REFERENCES TheThuVien(MaThe),
    NgayMuon DATE NOT NULL,
    MaTK     INT NOT NULL CONSTRAINT FK_PM_TaiKhoan REFERENCES TaiKhoan(MaTK)
    -- "Mỗi phiếu có >= 1 chi tiết" không khai báo được bằng SQL: MuonBLL.Muon tạo phiếu + chi tiết trong 1 transaction
);

CREATE TABLE ChiTietMuon (
    MaCTM       INT IDENTITY(1,1) CONSTRAINT PK_ChiTietMuon PRIMARY KEY,
    MaPM        INT NOT NULL CONSTRAINT FK_CTM_PM REFERENCES PhieuMuon(MaPM),
    MaSach      INT NOT NULL CONSTRAINT FK_CTM_Sach REFERENCES Sach(MaSach),
    HanTra      DATE NOT NULL,
    SoLanGiaHan INT NOT NULL CONSTRAINT DF_CTM_GH DEFAULT 0 CONSTRAINT CK_CTM_GH CHECK (SoLanGiaHan >= 0),
    NgayTra     DATE NULL,      -- ngày ĐÓNG giao dịch của cuốn (ngày trả hoặc ngày ghi nhận mất); NULL = chưa trả
    TinhTrang   NVARCHAR(20) NOT NULL CONSTRAINT DF_CTM_TT DEFAULT N'Chưa trả'
                CONSTRAINT CK_CTM_TT CHECK (TinhTrang IN (N'Chưa trả', N'Bình thường', N'Hỏng', N'Mất')),
    CONSTRAINT UQ_CTM_PM_Sach UNIQUE (MaPM, MaSach),
    CONSTRAINT CK_CTM_NgayTra CHECK (
        (TinhTrang = N'Chưa trả' AND NgayTra IS NULL) OR
        (TinhTrang <> N'Chưa trả' AND NgayTra IS NOT NULL))
);

CREATE TABLE PhieuThu (
    MaPT    INT IDENTITY(1,1) CONSTRAINT PK_PhieuThu PRIMARY KEY,
    LoaiThu NVARCHAR(20) NOT NULL CONSTRAINT CK_PT_Loai CHECK (LoaiThu IN (N'Phí thẻ', N'Phạt trễ', N'Đền bù')),
    SoTien  DECIMAL(12,0) NOT NULL CONSTRAINT CK_PT_SoTien CHECK (SoTien > 0),   -- 0đ thì không sinh phiếu
    NgayThu DATETIME NOT NULL,      -- BLL truyền vào (Clock.Now): một nguồn thời gian, KHÔNG dùng GETDATE() mặc định
    MaThe   INT NULL CONSTRAINT FK_PT_The REFERENCES TheThuVien(MaThe),         -- chỉ dùng cho Phí thẻ
    MaCTM   INT NULL CONSTRAINT FK_PT_CTM REFERENCES ChiTietMuon(MaCTM),        -- chỉ dùng cho Phạt trễ / Đền bù
    MaTK    INT NOT NULL CONSTRAINT FK_PT_TaiKhoan REFERENCES TaiKhoan(MaTK),
    GhiChu  NVARCHAR(300) NULL,
    -- XOR: Phí thẻ gắn với thẻ; Phạt trễ/Đền bù gắn với một cuốn mượn
    CONSTRAINT CK_PT_XOR CHECK (
        (LoaiThu = N'Phí thẻ' AND MaThe IS NOT NULL AND MaCTM IS NULL) OR
        (LoaiThu IN (N'Phạt trễ', N'Đền bù') AND MaCTM IS NOT NULL AND MaThe IS NULL))
);
-- Mỗi cuốn mượn tối đa 1 phiếu Phạt trễ + 1 phiếu Đền bù => tối đa 2 phiếu.
-- Phải là FILTERED index: phí thẻ có MaCTM = NULL và được phép lặp (gia hạn nhiều lần).
CREATE UNIQUE INDEX UX_PT_CTM_Loai ON PhieuThu(MaCTM, LoaiThu) WHERE MaCTM IS NOT NULL;

CREATE TABLE CauHinh (
    Khoa   VARCHAR(50) NOT NULL CONSTRAINT PK_CauHinh PRIMARY KEY,
    GiaTri NVARCHAR(100) NOT NULL,
    MoTa   NVARCHAR(200) NULL
);

CREATE INDEX IX_CTM_MaSach   ON ChiTietMuon(MaSach);
CREATE INDEX IX_CTM_HanTra   ON ChiTietMuon(NgayTra, HanTra);
CREATE INDEX IX_PT_Ngay_Loai ON PhieuThu(NgayThu, LoaiThu);
CREATE INDEX IX_PT_MaThe     ON PhieuThu(MaThe) WHERE MaThe IS NOT NULL;
GO

/* ---------- 2. Dữ liệu mẫu ---------- */
DECLARE @h DATE = CAST(GETDATE() AS DATE);   -- mọi ngày mẫu tính tương đối theo hôm nay

INSERT INTO CauHinh(Khoa, GiaTri, MoTa) VALUES
 ('THE_SO_THANG',       N'12',    N'BR01: Thời hạn thẻ (tháng)'),
 ('PHI_THE',            N'50000', N'BR01: Phí cấp/gia hạn thẻ (đồng)'),
 ('MUON_TOI_DA',        N'5',     N'BR02: Số cuốn tối đa mượn cùng lúc trên một thẻ'),
 ('MUON_SO_NGAY',       N'14',    N'BR03: Số ngày được mượn'),
 ('GIA_HAN_TOI_DA',     N'1',     N'BR03: Số lần gia hạn tối đa cho mỗi cuốn'),
 ('GIA_HAN_SO_NGAY',    N'7',     N'BR03: Số ngày cộng thêm vào HanTra mỗi lần gia hạn'),
 ('PHAT_TRE_MOI_NGAY',  N'2000',  N'BR06: Phạt trả trễ (đồng/cuốn/ngày), tối đa bằng giá bìa'),
 ('DEN_HONG_PHAN_TRAM', N'50',    N'BR07: % giá bìa phải đền khi sách hỏng'),
 ('DEN_MAT_PHAN_TRAM',  N'100',   N'BR07: % giá bìa phải đền khi sách mất');

-- Mật khẩu: salt$SHA256(salt+matkhau) viết HOA. HỢP ĐỒNG cho AuthBLL.Bam():
-- chuỗi đầu vào = salt + matkhau (không dấu phân cách), mã hóa UTF-8, SHA-256, hex HOA, lưu "salt$hash".
INSERT INTO TaiKhoan(TenDN, MatKhauHash, HoTen, VaiTro, TrangThai) VALUES
 ('admin',   'a1b2c3d4e5f60718$' + CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'a1b2c3d4e5f60718' + 'admin123'), 2), N'Quản trị viên', 'QuanTri', 1),
 ('thuthu1', '0f9e8d7c6b5a4321$' + CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '0f9e8d7c6b5a4321' + '123456'),   2), N'Thủ thư 1',     'ThuThu', 1);

INSERT INTO TheLoai(TenTL) VALUES
 (N'Công nghệ thông tin'), (N'Văn học'), (N'Kinh tế'), (N'Khoa học'), (N'Thiếu nhi');

-- SoLuongTong/SoLuongCon ĐÃ phản ánh các giao dịch mượn/trả mẫu bên dưới
-- (Con = Tong - số cuốn 'Chưa trả'; sách 6 đã mất 1 cuốn nên Tong giảm từ 2 xuống 1). Kiểm lại bằng 02_doi_soat.sql.
INSERT INTO Sach(TenSach, TacGia, MaTL, NXB, NamXB, GiaBia, SoLuongTong, SoLuongCon, TrangThai) VALUES
 (N'Lập trình C# căn bản',     N'Nguyễn Văn A',      1, N'NXB Giáo dục',  2020, 120000,  5,  4, 1),   -- MaSach 1: CTM1 đang mượn (quá hạn)
 (N'Cơ sở dữ liệu SQL Server', N'Trần Thị B',        1, N'NXB Bách khoa', 2019, 150000,  3,  2, 1),   -- MaSach 2: CTM2 đang mượn (quá hạn)
 (N'Dế Mèn phiêu lưu ký',      N'Tô Hoài',           5, N'NXB Kim Đồng',  2018,  45000, 10,  9, 1),   -- MaSach 3: CTM3 đang mượn
 (N'Nhà giả kim',              N'Paulo Coelho',      2, N'NXB Văn học',   2017,  79000,  4,  3, 1),   -- MaSach 4: CTM4 đang mượn
 (N'Kinh tế học vi mô',        N'N. Gregory Mankiw', 3, N'NXB Thống kê',  2016, 250000,  2,  1, 1),   -- MaSach 5: CTM5 đang mượn
 (N'Lược sử thời gian',        N'Stephen Hawking',   4, N'NXB Trẻ',       2015,  98000,  1,  1, 1);   -- MaSach 6: đã mất 1 cuốn (CTM8)

INSERT INTO DocGia(HoTen, NgaySinh, GioiTinh, DiaChi, SDT, Email, TrangThai) VALUES
 (N'Nguyễn Văn An', '2003-05-12', N'Nam', N'Hà Nội',    '0901234567', 'an@example.com',   1),   -- MaDG 1
 (N'Trần Thị Bình', '2002-11-30', N'Nữ',  N'Hải Phòng', '0912345678', 'binh@example.com', 1),   -- MaDG 2
 (N'Lê Văn Cường',  '2004-02-20', N'Nam', N'Đà Nẵng',   '0923456789', NULL,               1),   -- MaDG 3
 (N'Phạm Thị Dung', '2001-09-09', N'Nữ',  N'Huế',       '0934567890', 'dung@example.com', 1);   -- MaDG 4

INSERT INTO TheThuVien(MaDG, NgayCap, NgayHetHan, TrangThai) VALUES
 (1, DATEADD(MONTH, -3,  @h), DATEADD(MONTH,  9, @h), 1),   -- MaThe 1: An, còn hạn
 (2, DATEADD(MONTH, -14, @h), DATEADD(MONTH, -2, @h), 1),   -- MaThe 2: Bình, ĐÃ HẾT HẠN (test BR04)
 (4, DATEADD(DAY,   -60, @h), DATEADD(MONTH, 10, @h), 1);   -- MaThe 3: Dung, còn hạn. Cường (MaDG 3) chưa có thẻ.

/* ---- Giao dịch mượn mẫu (MaPM 1..5, MaCTM 1..8 theo đúng thứ tự chèn) ----
   An    : CTM1, CTM2 quá hạn 16 ngày (test trả Hỏng + trễ, trả Mất; An bị chặn mượn/gia hạn theo BR04)
           CTM3 còn hạn (nhưng An vẫn bị BR04 chặn gia hạn vì còn 2 cuốn quá hạn)
   Dung  : CTM4 HanTra = hôm nay (trả đúng ngày KHÔNG phạt; gia hạn được), CTM5 còn 11 ngày (gia hạn được)
   Bình  : lịch sử đã đóng: CTM6 Bình thường trễ 6 ngày, CTM7 Hỏng trễ 6 ngày, CTM8 Mất (có phiếu thu mẫu)   */
INSERT INTO PhieuMuon(MaThe, NgayMuon, MaTK) VALUES
 (1, DATEADD(DAY, -30, @h), 2),   -- MaPM 1
 (1, DATEADD(DAY,  -5, @h), 2),   -- MaPM 2
 (3, DATEADD(DAY, -14, @h), 2),   -- MaPM 3
 (3, DATEADD(DAY,  -3, @h), 2),   -- MaPM 4
 (2, DATEADD(DAY, -90, @h), 2);   -- MaPM 5

INSERT INTO ChiTietMuon(MaPM, MaSach, HanTra, SoLanGiaHan, NgayTra, TinhTrang) VALUES
 (1, 1, DATEADD(DAY, -16, @h), 0, NULL,                    N'Chưa trả'),      -- CTM1
 (1, 2, DATEADD(DAY, -16, @h), 0, NULL,                    N'Chưa trả'),      -- CTM2
 (2, 3, DATEADD(DAY,   9, @h), 0, NULL,                    N'Chưa trả'),      -- CTM3
 (3, 4, @h,                    0, NULL,                    N'Chưa trả'),      -- CTM4
 (4, 5, DATEADD(DAY,  11, @h), 0, NULL,                    N'Chưa trả'),      -- CTM5
 (5, 3, DATEADD(DAY, -76, @h), 0, DATEADD(DAY, -70, @h),   N'Bình thường'),   -- CTM6: trễ 6 ngày
 (5, 4, DATEADD(DAY, -76, @h), 0, DATEADD(DAY, -70, @h),   N'Hỏng'),          -- CTM7: trễ 6 ngày + hỏng
 (5, 6, DATEADD(DAY, -76, @h), 0, DATEADD(DAY, -70, @h),   N'Mất');           -- CTM8: mất, không phạt trễ

-- Phiếu thu mẫu (LoaiThu, SoTien, NgayThu, MaThe, MaCTM, MaTK, GhiChu) - đúng XOR: phí thẻ chỉ MaThe; phạt/đền chỉ MaCTM
INSERT INTO PhieuThu(LoaiThu, SoTien, NgayThu, MaThe, MaCTM, MaTK, GhiChu) VALUES
 (N'Phí thẻ',  50000, DATEADD(MONTH, -3,  @h), 1,    NULL, 1, N'Cấp thẻ'),
 (N'Phí thẻ',  50000, DATEADD(MONTH, -14, @h), 2,    NULL, 1, N'Cấp thẻ'),
 (N'Phí thẻ',  50000, DATEADD(DAY,   -60, @h), 3,    NULL, 2, N'Cấp thẻ'),
 (N'Phạt trễ', 12000, DATEADD(DAY,   -70, @h), NULL, 6,    2, N'Trễ 6 ngày x 2.000đ'),
 (N'Phạt trễ', 12000, DATEADD(DAY,   -70, @h), NULL, 7,    2, N'Trễ 6 ngày x 2.000đ'),
 (N'Đền bù',   39500, DATEADD(DAY,   -70, @h), NULL, 7,    2, N'Sách hỏng 50% x 79.000đ'),
 (N'Đền bù',   98000, DATEADD(DAY,   -70, @h), NULL, 8,    2, N'Sách mất 100% x 98.000đ');
GO

SELECT 'OK' AS KetQua,
       (SELECT COUNT(*) FROM CauHinh) AS CauHinh, (SELECT COUNT(*) FROM TaiKhoan) AS TaiKhoan,
       (SELECT COUNT(*) FROM Sach) AS Sach, (SELECT COUNT(*) FROM DocGia) AS DocGia,
       (SELECT COUNT(*) FROM ChiTietMuon) AS ChiTietMuon, (SELECT COUNT(*) FROM PhieuThu) AS PhieuThu;
GO
