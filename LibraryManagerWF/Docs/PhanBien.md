# Phản biện nhanh (bản 3 lớp)

## Mô hình
Thủ thư dùng phần mềm; độc giả chỉ là hồ sơ. Tiền chỉ phát sinh từ 3 nguồn: **Phí thẻ**, **Phạt trễ**, **Đền bù**. Mỗi khoản thu sinh **một phiếu thu**; doanh thu = tổng phiếu thu.

## Luồng chạy
Form (sau này) gọi `XxxBLL.HamNao(...)` → BLL kiểm tra quyền và luật, mở `DataBaseProcess` (và transaction nếu ghi nhiều bảng) → gọi `XxxDAL` → DAL viết SQL, chạy qua `DataBaseProcess`. SQL chỉ nằm trong DAL, luật chỉ nằm trong BLL.

## Ba quy ước
1. **Hàm ghi trả về `string`: `null` = thành công, khác `null` = lỗi nghiệp vụ** (kết quả thêm trả qua `out`).
2. **Hàm đọc trả về `DataTable`** (gán thẳng vào `DataGridView`) hoặc DTO.
3. **Thiếu quyền thì `throw UnauthorizedAccessException`** (`Quyen.YeuCauDangNhap/YeuCauQuanTri`); không `try/catch` từng hàm, lỗi hệ thống bắt chung ở `Program.cs`.

## Vai trò
Hai vai trò trong một cột `TaiKhoan.VaiTro`; **QuanTri bao trùm ThuThu**. QuanTri thêm đúng ba việc: quản lý tài khoản, chỉnh `CauHinh`, xem báo cáo doanh thu. Không tách luồng riêng vì nghiệp vụ còn lại hai vai trò làm giống hệt nhau.

## Mật khẩu
`salt$hash` với hash = SHA-256(salt + matkhau), hex HOA; salt là chuỗi ngẫu nhiên riêng mỗi tài khoản, lưu ngay cạnh hash. Salt làm hai người cùng mật khẩu ra hash khác nhau và vô hiệu "bảng hash dựng sẵn". Mức này đủ cho đồ án; hệ thống thật nên dùng thuật toán chậm có chủ đích (PBKDF2, bcrypt, Argon2). Vì SQL Server có `HASHBYTES('SHA2_256')` nên seed tính hash ngay trong script.

## Hàm DataBaseProcess (giống slide)
`DocBang(sql, ...)` = DataReader trong slide; `CapNhat(sql, ...)` = DataChange. Khác slide: giá trị truyền qua `@0, @1...` thay vì nối chuỗi.
Thêm `LayMotGiaTri` (COUNT, lấy 1 ô), `ThemLayMa` (INSERT trả mã tự tăng), `BatDauGiaoDich` / `XacNhan`.

## Luồng nghiệp vụ
**Cấp / gia hạn thẻ** (`TheBLL`): một transaction = tạo hoặc đổi hạn thẻ + 1 phiếu thu "Phí thẻ". Gia hạn: còn hạn thì cộng từ hạn cũ, hết hạn thì tính từ hôm nay.

**Mượn** (`MuonBLL.Muon`): một transaction, 4 bước:
1. `KiemTraDuocMuon`: độc giả, thẻ không khóa, thẻ chưa hết hạn, không có sách quá hạn (BR04).
2. Số đang mượn + số cuốn mới không vượt hạn mức 5 (BR02).
3. Ghi `PhieuMuon`.
4. Mỗi cuốn: trừ kho (`UPDATE ... WHERE SoLuongCon > 0 AND TrangThai = 1`, 0 dòng = hết hoặc khóa, BR05) rồi ghi `ChiTietMuon`, hạn trả = hôm nay + 14 ngày.

**Gia hạn sách**: từng cuốn, chưa quá hạn, chưa hết 1 lần, độc giả không có cuốn khác quá hạn; hạn mới = hạn cũ + 7 ngày.

**Trả** (`TraBLL.Tra`): một transaction, 4 bước:
1. Đọc và tính tiền; có tiền mà chưa thu thì từ chối (BR13).
2. Đóng cuốn mượn (ghi ngày trả, tình trạng).
3. Kho: Bình thường hoặc Hỏng thì `SoLuongCon + 1`; Mất thì `SoLuongTong - 1`.
4. Phiếu thu: Phạt trễ và/hoặc Đền bù (khoản 0đ bỏ qua).

**Tính tiền** (3 hàm thuần, có test):
- `SoNgayTre`: trả đúng hạn = 0 ngày.
- `TienPhatTre`: ngày trễ x 2.000đ, tối đa bằng giá bìa.
- `TienDen`: giá bìa x 50% (hỏng) hoặc 100% (mất), làm tròn nửa lên (`MidpointRounding.AwayFromZero`) để khớp `ROUND` của SQL.
- Mất: chỉ đền, không phạt trễ. Hỏng: phạt trễ cộng đền (2 phiếu).

## Câu hỏi hay gặp
| Hỏi | Trả lời |
|---|---|
| Sao Mượn/Trả cần transaction? | Ghi nhiều bảng (phiếu, chi tiết, kho, phiếu thu) phải cùng thành công hoặc cùng hủy. |
| Lỗi giữa chừng thì sao? | `using (var db = new DataBaseProcess())` gọi `Dispose`, mà chưa `XacNhan` thì tự `Rollback`. |
| Sao không nối chuỗi SQL như slide? | Tên có dấu nháy (O'Brien) làm lỗi câu SQL, `' OR '1'='1` vượt được đăng nhập, ngày nối chuỗi phụ thuộc định dạng máy. Dùng `@0` chỉ thêm một đối số. |
| Sao không kiểm tra loại thu, số tiền trong C#? | CSDL đã có CHECK và khóa ngoại, kiểm tra hai nơi dễ lệch nhau. |
| Sao phiếu thu là bảng riêng? | Một cuốn có thể phát sinh 2 khoản khác loại; phí thẻ không thuộc phiếu mượn nào. Tách bảng thì báo cáo theo loại chính xác. |
| Sao `SoLuongCon` lưu riêng? | Dư thừa có kiểm soát: chỉ Sách, Mượn, Trả được sửa; đối soát bằng `02_doi_soat.sql`. |
| Điều gì chưa chặn? | Hai người thao tác cùng một thẻ cùng lúc (đồ án chạy một máy). |
| Sao gọi là 3 lớp mà chỉ có một project? | Ba lớp tách bằng thư mục và namespace (`DTO`, `DAL`, `BLL`), GUI chỉ gọi BLL. Muốn tách thành project riêng chỉ cần chuyển thư mục, vì BLL chỉ phụ thuộc DAL và DTO. |
