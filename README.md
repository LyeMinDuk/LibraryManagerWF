# LibraryManagerWF

Phần mềm **quản lý thư viện** cho thủ thư, viết bằng **C# WinForms (.NET Framework 4.7.2)** và **SQL Server**. Bài tập lớn môn *Lập trình trực quan*.

Thủ thư quản lý sách, độc giả, thẻ thư viện và việc mượn – trả tại quầy; mọi khoản thu (phí thẻ, phạt trả trễ, đền sách hỏng/mất) đều sinh phiếu thu để lập báo cáo doanh thu. Độc giả **không** đăng nhập: chỉ là hồ sơ do thủ thư quản lý.

## Tính năng

| Nhóm | Chức năng |
|---|---|
| Sách | CRUD sách và thể loại, tìm kiếm, khóa/mở khóa sách |
| Độc giả & thẻ | CRUD độc giả, cấp thẻ, gia hạn thẻ (thu phí), khóa/mở khóa |
| Mượn – trả | Cho mượn nhiều cuốn trong một phiếu, gia hạn sách, trả sách (bình thường / hỏng / mất), tính phạt và tiền đền tự động, in hóa đơn trả sách |
| Theo dõi | Danh sách đang mượn, quá hạn, đã trả; tra cứu theo độc giả |
| Phiếu thu | Tra cứu theo ngày và loại thu (Phí thẻ, Phạt trễ, Đền bù) |
| Trang chủ | Thống kê nhanh: đầu sách, số cuốn còn trên kệ, độc giả, thẻ còn hiệu lực, đang mượn, quá hạn |
| Quản trị | Báo cáo doanh thu (xuất Excel), quản lý tài khoản, cấu hình đơn giá và quy tắc |

### Phân quyền

Hai vai trò lưu trong `TaiKhoan.VaiTro`; **QuanTri bao trùm ThuThu**.

| Chức năng | ThuThu | QuanTri |
|---|:-:|:-:|
| Sách, thể loại, độc giả, thẻ | ✓ | ✓ |
| Cho mượn, trả, gia hạn sách, xem phiếu thu | ✓ | ✓ |
| Báo cáo doanh thu | | ✓ |
| Quản lý tài khoản, cấu hình đơn giá | | ✓ |

## Công nghệ

- C# WinForms, .NET Framework 4.7.2, Visual Studio 2022 trở lên
- SQL Server (Express hoặc LocalDB), truy cập bằng `System.Data.SqlClient`, truy vấn tham số hóa (`@0, @1...`)
- [ClosedXML](https://github.com/ClosedXML/ClosedXML) 0.105.1 để xuất báo cáo Excel (cài tự động qua NuGet)

## Kiến trúc 3 lớp

Một project, ba lớp tách bằng thư mục và namespace. **GUI chỉ gọi BLL**, SQL chỉ nằm trong DAL, luật nghiệp vụ chỉ nằm trong BLL.

```
GUI  →  BLL  →  DAL  →  SQL Server
          ↘  DTO  ↙
```

```
LibraryManagerWF/
├── LibraryManagerWF.slnx
├── README.md
└── LibraryManagerWF/
    ├── DTO/        Lớp dữ liệu thuần (9 entity + ThongKeDTO)
    ├── DAL/        Chỉ SQL; DbHelpers (kết nối, transaction), XxxDAL
    ├── BLL/        Toàn bộ quy tắc BR01–BR13, phân quyền, mật khẩu, tính phạt
    ├── GUI/        Form, UserControl theo từng module; Theme, GridStyle...
    ├── Database/   01_schema_seed.sql, 02_doi_soat.sql
    ├── Docs/       Đề cương, phản biện, danh sách hàm BLL
    ├── Tests/      LogicTests.cs (kiểm thử logic thuần, chạy console)
    ├── App.config.example
    └── Program.cs  Đăng nhập → màn hình chính → đăng xuất, bắt lỗi chung
```

Quy ước chung của BLL (chi tiết ở [`Docs/API_BLL.md`](LibraryManagerWF/Docs/API_BLL.md)):

1. Hàm ghi trả `string`: **`null` = thành công**, khác `null` = lỗi nghiệp vụ.
2. Hàm đọc trả `DataTable` (gán thẳng vào `DataGridView`) hoặc DTO.
3. Thiếu quyền thì ném `UnauthorizedAccessException`; `Program.cs` bắt lỗi chung.
4. Nghiệp vụ ghi nhiều bảng (mượn, trả, cấp/gia hạn thẻ) chạy trong **một transaction**; thao tác đổi trạng thái dùng `UPDATE ... WHERE <điều kiện cũ>` và kiểm tra số dòng bị ảnh hưởng để chặn bấm hai lần.

## Cơ sở dữ liệu

9 bảng, đạt 3NF: `TheLoai`, `Sach`, `DocGia`, `TheThuVien`, `TaiKhoan`, `PhieuMuon`, `ChiTietMuon`, `PhieuThu`, `CauHinh`.

Các quy tắc nghiệp vụ lưu trong bảng `CauHinh`, có thể chỉnh trong ứng dụng (mặc định):

| Mã | Quy tắc | Mặc định |
|---|---|---|
| BR01 | Hiệu lực thẻ, phí cấp/gia hạn | 12 tháng, 50.000đ |
| BR02 | Hạn mức mượn cùng lúc trên một thẻ | 5 cuốn |
| BR03 | Thời hạn mượn; gia hạn | 14 ngày; 1 lần, +7 ngày |
| BR04 | Không mượn/gia hạn nếu chưa có thẻ, độc giả hoặc thẻ bị khóa, thẻ hết hạn, hoặc đang có sách quá hạn | |
| BR05 | Không mượn khi sách hết hoặc bị khóa | |
| BR06 | Phạt trả trễ, tối đa bằng giá bìa | 2.000đ/cuốn/ngày |
| BR07 | Đền sách hỏng; sách mất (theo giá bìa) | 50%; 100% |
| BR08 | Mỗi khoản thu sinh một phiếu thu | |
| BR10 | Dữ liệu đã phát sinh giao dịch chỉ khóa, không xóa | |
| BR11 | Mật khẩu lưu hash, phân quyền, tài khoản khóa không đăng nhập được | |
| BR12 | Kiểm tra nhập liệu: SĐT 10 số, email hợp lệ, ngày sinh < hôm nay, giá và số lượng > 0 | |
| BR13 | Thu ngay, không công nợ: trả sách chỉ hoàn tất khi phiếu thu được tạo cùng transaction | |

Mật khẩu lưu dạng `salt$hash`, với hash = SHA-256(salt + mật khẩu), hex in hoa. Mức này đủ cho đồ án; hệ thống thật nên dùng thuật toán chậm như PBKDF2, bcrypt hoặc Argon2.

## Cài đặt và chạy

### Yêu cầu

- Windows, Visual Studio 2022+ với workload *.NET desktop development* (kèm .NET Framework 4.7.2)
- SQL Server Express hoặc LocalDB, cùng SSMS hoặc Azure Data Studio để chạy script

### Các bước

1. **Clone repo**
   ```bash
   git clone https://github.com/LyeMinDuk/LibraryManagerWF.git
   ```
2. **Tạo cơ sở dữ liệu:** mở `LibraryManagerWF/Database/01_schema_seed.sql` trong SSMS rồi chạy toàn bộ. Script tạo CSDL `LibraryDB`, các bảng và dữ liệu mẫu.
   > Script có `DROP`/tạo lại `LibraryDB` ở đầu; đừng chạy trên CSDL đang có dữ liệu cần giữ.
3. **Cấu hình chuỗi kết nối:** sao chép `LibraryManagerWF/App.config.example` thành `LibraryManagerWF/App.config` (file này đã được `.gitignore`), sửa `Server` cho khớp máy bạn:
   ```xml
   <add name="LibraryDB"
        connectionString="Server=.\SQLEXPRESS;Database=LibraryDB;Integrated Security=True;"
        providerName="System.Data.SqlClient" />
   ```
   Dùng LocalDB thì đổi thành `Server=(localdb)\MSSQLLocalDB`. Khóa phải tên `LibraryDB` vì `DbHelpers` đọc đúng khóa này.
4. Mở `LibraryManagerWF.slnx` trong Visual Studio, để NuGet khôi phục gói, rồi nhấn **F5**.

### Tài khoản mẫu

| Tên đăng nhập | Mật khẩu | Vai trò |
|---|---|---|
| `admin` | `admin123` | QuanTri |
| `thuthu1` | `123456` | ThuThu |

Nên đổi mật khẩu sau lần đăng nhập đầu (menu đổi mật khẩu trong ứng dụng).

## Dữ liệu mẫu và kiểm thử

Seed có sẵn giao dịch mẫu để thử ngay các tình huống:

- **An** có sách quá hạn: thử trả *Hỏng* kèm trễ (2 phiếu thu), trả *Mất* (chỉ đền, không phạt trễ), và thử mượn/gia hạn bị BR04 chặn.
- **Dung** có sách hạn trả là hôm nay: trả đúng hạn không bị phạt; gia hạn thành công.
- **Bình** có thẻ hết hạn: không mượn được nhưng vẫn trả sách và nộp phạt.
- **Cường** chưa có thẻ: thử cấp thẻ.

## Nhóm thực hiện

| Thành viên | Phụ trách |
|---|---|
| Lê Minh Đức | Nền tảng, CSDL, sách, thể loại, tài khoản, cấu hình, đăng nhập, khung giao diện |
| Nguyễn Hữu Thành | Trả sách, tính phạt, theo dõi mượn trả, phiếu thu, báo cáo doanh thu |
| Trần Xuân Tuấn Cường | Độc giả, thẻ, cho mượn, gia hạn sách |
