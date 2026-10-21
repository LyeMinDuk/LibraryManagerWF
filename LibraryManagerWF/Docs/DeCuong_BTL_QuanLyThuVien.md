# Đề cương BTL — Phần mềm Quản lý thư viện (bản chỉnh, chỉ thủ thư/quản trị)

## 1. Mô tả
Phần mềm cho thủ thư quản lý sách, độc giả, thẻ thư viện và mượn–trả tại quầy. Thu nhập của thư viện gồm phí làm/gia hạn thẻ, tiền phạt trả trễ, tiền đền sách hỏng/mất; mỗi khoản thu sinh **một phiếu thu** để làm báo cáo doanh thu. Độc giả **không** đăng nhập: `DocGia` chỉ là hồ sơ người mượn do thủ thư quản lý.

## 2. Vai trò và phân quyền
`TaiKhoan.VaiTro ∈ {QuanTri, ThuThu}`. QuanTri có đủ quyền của ThuThu.

| Chức năng | ThuThu | QuanTri |
|---|---|---|
| Sách, thể loại, độc giả, thẻ | ✓ | ✓ |
| Cho mượn, trả, gia hạn sách, xem phiếu thu | ✓ | ✓ |
| Báo cáo doanh thu | ✗ | ✓ |
| Quản lý tài khoản, chỉnh đơn giá `CauHinh` | ✗ | ✓ |

## 3. CSDL (9 bảng, 3NF) — đậm = khóa chính, # = khóa ngoại
- TheLoai (**MaTL**, TenTL)
- Sach (**MaSach**, TenSach, TacGia, #MaTL, NXB, NamXB, GiaBia, SoLuongTong, SoLuongCon, TrangThai)
- DocGia (**MaDG**, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, Email, TrangThai)
- TheThuVien (**MaThe**, #MaDG *UNIQUE*, NgayCap, NgayHetHan, TrangThai)
- TaiKhoan (**MaTK**, TenDN *UNIQUE*, MatKhauHash, HoTen, VaiTro, TrangThai)
- PhieuMuon (**MaPM**, #MaThe, NgayMuon, #MaTK)
- ChiTietMuon (**MaCTM**, #MaPM, #MaSach, HanTra, SoLanGiaHan, NgayTra NULL, TinhTrang; *UNIQUE (MaPM, MaSach)*)
- PhieuThu (**MaPT**, LoaiThu, SoTien, NgayThu, #MaThe NULL, #MaCTM NULL, #MaTK, GhiChu; *CHECK XOR; UNIQUE (MaCTM, LoaiThu) WHERE MaCTM IS NOT NULL*)
- CauHinh (**Khoa**, GiaTri, MoTa)

Giá trị: `LoaiThu ∈ {Phí thẻ, Phạt trễ, Đền bù}`; `TinhTrang ∈ {Chưa trả, Bình thường, Hỏng, Mất}`; `TrangThai`: 1 = hoạt động, 0 = khóa.

**Định nghĩa trạng thái**
- `DocGia.TrangThai`, `TheThuVien.TrangThai`: chỉ đổi bằng thao tác tay của thủ thư. **"Hết hạn" không lưu**, luôn tính từ `NgayHetHan < hôm nay` qua một hàm duy nhất `TheBLL.TinhTrangThe()` → {HoatDong, HetHan, Khoa}.
- Khóa độc giả **không** tự khóa thẻ; `KiemTraHopLe` kiểm tra cả hai cờ.
- `NgayTra` = ngày **đóng** giao dịch của cuốn (ngày trả hoặc ngày ghi nhận mất), lấy từ `Clock.Today` ở BLL, không cho nhập tay.

**Chuẩn hóa:** 9 bảng đạt 3NF. Hai chỗ dư thừa dẫn xuất liên bảng: `PhieuThu.MaThe` vẫn còn (phí thẻ cần) nhưng được **kiểm soát bằng ràng buộc XOR**, không lưu trùng với thẻ suy ra từ `MaCTM`; `Sach.SoLuongCon` giữ có kiểm soát (chỉ `SachBLL` và các transaction mượn/trả được sửa, đối soát bằng `02_doi_soat.sql`). `SoTien`, `HanTra` là dữ liệu chụp tại thời điểm giao dịch (đơn giá/giá bìa có thể đổi sau), không phải dư thừa.

## 4. Quy tắc nghiệp vụ (lưu trong CauHinh)
| Mã | Quy tắc | Mặc định |
|---|---|---|
| BR01 | Thẻ có hiệu lực; phí cấp/gia hạn | 12 tháng, 50.000đ |
| BR02 | Hạn mức mượn cùng lúc trên một thẻ | 5 cuốn |
| BR03 | Thời hạn mượn; gia hạn | 14 ngày; 1 lần, +7 ngày |
| BR04 | Không cho **mượn và gia hạn** nếu: chưa có thẻ, độc giả bị khóa, thẻ bị khóa/hết hạn, hoặc đang có sách quá hạn | |
| BR05 | Không cho mượn khi sách hết (`SoLuongCon = 0`) hoặc sách bị khóa | |
| BR06 | Phạt trả trễ, tối đa bằng giá bìa | 2.000đ/cuốn/ngày |
| BR07 | Đền sách hỏng; sách mất (theo giá bìa) | 50%; 100% |
| BR08 | Mỗi khoản thu sinh một phiếu thu; doanh thu = tổng phiếu thu theo loại | |
| ~~BR09~~ | *(đã bỏ — không còn luồng độc giả/yêu cầu chờ duyệt)* | |
| BR10 | Dữ liệu đã phát sinh giao dịch thì **chỉ khóa, không xóa** (`TaiKhoan`, `Sach`, `DocGia`, `TheThuVien`); `TheLoai` còn sách thì không xóa | |
| BR11 | Mật khẩu lưu hash; phân quyền QuanTri/ThuThu; tài khoản khóa không đăng nhập được | |
| BR12 | Nhập liệu: SĐT 10 số, email hợp lệ, ngày sinh nhỏ hơn hôm nay, giá và số lượng lớn hơn 0 | |
| BR13 | **Thu ngay, không công nợ:** trả sách chỉ hoàn tất khi phiếu thu (nếu có) được tạo trong cùng transaction; chưa nộp thì hủy thao tác, cuốn vẫn "Chưa trả" | |

## 5. Quy định chung
- **Quá hạn:** `HanTra < hôm nay`. Trả đúng ngày `HanTra` không bị phạt. Số ngày trễ = `NgayTra − HanTra`, tính theo ngày lịch.
- **Phạt trễ:** mỗi cuốn không vượt `GiaBia`, tính riêng, không gộp với tiền đền.
- **Hỏng:** đền 50% `GiaBia`; sách về kho (`SoLuongCon + 1`); vẫn tính phạt trễ đến `NgayTra`.
- **Mất:** đền 100% `GiaBia`, **không** phạt trễ; `SoLuongTong − 1`, `SoLuongCon` giữ nguyên.
- **Làm tròn:** tiền đền = `Money.LamTron(GiaBia * phanTram / 100m)` = `Math.Round(..., 0, MidpointRounding.AwayFromZero)` để khớp `ROUND` của SQL (làm tròn nửa lên; mặc định của C# là làm tròn về số chẵn, sẽ lệch). Phạt trễ là số nguyên nên không cần làm tròn.
- **Vừa trễ vừa hỏng:** 2 phiếu thu cùng `MaCTM` (Phạt trễ + Đền bù). **Khoản 0đ:** không sinh phiếu.
- **Bất biến sách:** `SoLuongCon = SoLuongTong − số ChiTietMuon 'Chưa trả'`.
- **Gia hạn thẻ:** thẻ còn hạn cộng `THE_SO_THANG` tháng (mặc định 12) từ `NgayHetHan` cũ; thẻ **đã hết hạn** vẫn được gia hạn, tính từ hôm nay; luôn thu phí. Thẻ **bị khóa** hoặc độc giả **bị khóa** thì không cấp/gia hạn thẻ, cho đến khi thủ thư mở khóa bằng tay.
- **Gia hạn sách:** từng cuốn, cuốn **chưa quá hạn**, tối đa `GIA_HAN_TOI_DA` lần, `HanTra` mới = `HanTra` cũ + `GIA_HAN_SO_NGAY`; **chặn nếu độc giả còn cuốn khác quá hạn** (dùng chung `KiemTraHopLe`); `HanTra` được phép vượt `NgayHetHan` của thẻ.
- Thẻ hết hạn/khóa hoặc độc giả bị khóa: không mượn, **không gia hạn sách**, nhưng vẫn trả sách và nộp phạt.
- **Phiếu mượn:** không có hai dòng cùng `MaSach`; sách đã khóa không cho mượn; mỗi phiếu có ≥ 1 chi tiết (BLL bảo đảm).

## 6. Quy tắc ghi dữ liệu an toàn (BLL, trong transaction)
Mọi thay đổi trạng thái dùng `UPDATE ... WHERE <điều kiện cũ>` và **kiểm tra số dòng bị ảnh hưởng**; bằng 0 thì rollback và báo lỗi (chặn bấm hai lần, hai người cùng thao tác).
- **Mượn:** `UPDATE Sach SET SoLuongCon = SoLuongCon - 1 WHERE MaSach=@id AND SoLuongCon > 0 AND TrangThai = 1`. Trước khi đếm hạn mức BR02, khóa dòng thẻ: `SELECT ... FROM TheThuVien WITH (UPDLOCK, HOLDLOCK) WHERE MaThe=@id`.
- **Trả:** `UPDATE ChiTietMuon SET NgayTra=@homNay, TinhTrang=@tt WHERE MaCTM=@id AND NgayTra IS NULL`; rồi cập nhật `Sach` theo bảng: Bình thường/Hỏng `Con+1`; Mất `Tong−1`.
- **Gia hạn sách:** `UPDATE ChiTietMuon SET HanTra = DATEADD(DAY,@n,HanTra), SoLanGiaHan = SoLanGiaHan+1 WHERE MaCTM=@id AND NgayTra IS NULL AND HanTra=@hanCu AND HanTra >= @homNay AND SoLanGiaHan < @max`.
- **Gia hạn thẻ:** `UPDATE TheThuVien SET NgayHetHan=@moi WHERE MaThe=@id AND NgayHetHan=@cu`.
- Unique index `UX_PT_CTM_Loai` chỉ là lớp chặn cuối cùng cho phiếu phạt/đền trùng; phí thẻ được phép lặp khi gia hạn nhiều lần.

## 6b. Nguồn thời gian và hợp đồng dùng chung
- **Một nguồn thời gian:** lớp `Clock` (BLL) có `Clock.Today`, `Clock.Now` và hàm `Clock.Set(ngayGiaDinh)` để test theo ngày giả định. BLL lấy thời gian **một lần** rồi truyền xuống DAL cho `NgayMuon`, `NgayTra`, `NgayThu`, `HanTra`. DAL và SQL **không** dùng `GETDATE()`; cột `PhieuThu.NgayThu` không có DEFAULT để quên truyền thì lỗi ngay.
- **Lọc báo cáo theo ngày:** `NgayThu` là `DATETIME`, nên lọc `NgayThu >= @tu AND NgayThu < DATEADD(DAY, 1, @den)`, **không** dùng `<= @den` (mất phiếu trong ngày cuối).
- **Hợp đồng hash mật khẩu (`AuthBLL.BamMatKhau`):** chuỗi đầu vào = `salt + matkhau` (không dấu phân cách), mã hóa UTF-8, SHA-256, hex **HOA**, lưu dạng `salt$hash`. Seed trong `01_schema_seed.sql` đã theo đúng hợp đồng này.
- **Class dùng chung nhiều người:** mỗi class BLL chỉ một người sở hữu (`MuonBLL` của Cường, `TraBLL` của Thành) để nhánh `feature/<module>` không sửa chung một file. Chỗ cần dùng chéo thì gọi qua hàm công khai, không sửa file của người khác.

## 6c. Chủ sở hữu DTO/DAL và chữ ký DAL dùng chung (đóng băng trước ngày 1)
- **DTO:** chỉ Đức tạo/sửa (9 lớp + `Constants`). Ai cần thêm trường thì báo Đức, không tự sửa.
- **DAL dùng chung (Đức sở hữu, đã cài sẵn):** mọi hàm ghi trả về **số dòng bị ảnh hưởng** (`int`); BLL kiểm tra `== 1` rồi mới đi tiếp, ngược lại rollback (mục 6).

| Hàm | Dùng bởi | Điều kiện trong `WHERE` |
|---|---|---|
| `SachDAL.LayTheoId(maSach)` → `Sach` hoặc `null` | Muon, Tra | — |
| `SachDAL.GiamCon(maSach)` → `int` | `MuonBLL.Muon` | `SoLuongCon > 0 AND TrangThai = 1` |
| `SachDAL.TangCon(maSach)` → `int` | `TraBLL.Tra` (Bình thường, Hỏng) | `SoLuongCon < SoLuongTong` |
| `SachDAL.GiamTong(maSach)` → `int` | `TraBLL.Tra` (Mất; `Con` giữ nguyên) | `SoLuongTong > SoLuongCon` |
| `ChiTietMuonDAL.LayTheoId(maCTM)` → `ChiTietMuon` hoặc `null` | Muon, Tra | — |
| `ChiTietMuonDAL.Them(ChiTietMuon)` → `MaCTM` mới | `MuonBLL.Muon` | — |
| `ChiTietMuonDAL.DongGiaoDich(maCTM, ngayTra, tinhTrang)` → `int` | `TraBLL.Tra` | `NgayTra IS NULL` |
| `ChiTietMuonDAL.GiaHan(maCTM, hanCu, soNgay, homNay, toiDa)` → `int` | `MuonBLL.GiaHan` | `NgayTra IS NULL AND HanTra = @hanCu AND HanTra >= @homNay AND SoLanGiaHan < @toiDa` |
| `PhieuThuDAL.Them(PhieuThu)` → `MaPT` mới | `PhieuThuBLL.TaoPhieuThu` | — |

Hàm DAL riêng của từng module (ví dụ `PhieuMuonDAL`, `DocGiaDAL`, `TheThuVienDAL`) do chủ module viết; muốn thêm hàm vào DAL dùng chung thì tạo hàm mới ở file đó và báo Đức trước.

## 7. Kiến trúc 3 lớp
```
LibraryApp.sln
├── LibraryApp.DTO  → Entity thuần dữ liệu, không logic
├── LibraryApp.DAL  → chỉ SQL (DbHelper có transaction, XxxDAL), không kiểm tra nghiệp vụ
├── LibraryApp.BLL  → toàn bộ BR01–BR13; trả Result<T> { Ok, Message, Data }
└── LibraryApp.GUI  → Form, UserControl; chỉ gọi BLL, không gọi DAL, không viết SQL
```
GUI → BLL → DAL → DB. Ghi nhiều bảng chạy trong **một transaction** do BLL điều phối qua `DbHelper`.

## 8. Phân công
**Lê Minh Đức — nền tảng và dữ liệu:** script DB + seed, **toàn bộ 9 lớp DTO**, `DbHelper` (transaction), `Result`, **DAL dùng chung (`SachDAL` thao tác tồn kho, `ChiTietMuonDAL`)**, `Money`, `CauHinhBLL`, `Clock` (nguồn thời gian), `PhieuThuBLL.TaoPhieuThu(maThe | maCTM, ..., ngayThu)` (đúng một trong hai), `AuthBLL` (đăng nhập, hash, kiểm tra quyền), `frmMain` + điều hướng; sách + thể loại; tài khoản + cấu hình đơn giá.

**Nguyễn Hữu Thành — trả sách, phạt, theo dõi, phiếu thu:** `TraBLL` (trả sách) + `TinhPhatBLL`; danh sách đang mượn/quá hạn, tra cứu theo độc giả; quản lý phiếu thu; *(đề xuất giao thêm)* `BaoCaoBLL` doanh thu theo khoảng ngày/loại thu (QuanTri).

**Trần Xuân Tuấn Cường — độc giả, thẻ, cho mượn:** CRUD độc giả; cấp/gia hạn thẻ + thu phí; `TheBLL.KiemTraHopLe`/`TinhTrangThe`; `MuonBLL` (cho mượn + gia hạn sách).

| BR | BLL chịu trách nhiệm |
|---|---|
| BR01 | `TheBLL.CapThe`, `GiaHanThe` |
| BR02, BR03, BR05 | `MuonBLL.Muon`, `MuonBLL.GiaHan` (+ `SachBLL`) |
| BR04 | `TheBLL.KiemTraHopLe` |
| BR06, BR07, BR13 | `TinhPhatBLL.Tinh`, `TraBLL.Tra` |
| BR08 | `PhieuThuBLL.TaoPhieuThu`, `BaoCaoBLL` |
| BR10 | `SachBLL`, `DocGiaBLL`, `TheBLL`, `AuthBLL`/`TaiKhoanBLL`, `TheLoaiBLL` |
| BR11 | `AuthBLL` |
| BR12 | Hàm `Validate` trong BLL của từng module |

**Git:** mỗi người một nhánh `feature/<module>`. Ai đổi schema thì sửa `01_schema_seed.sql` và báo cả nhóm.

## 9. Tiến độ (đề xuất, cả nhóm thống nhất lại)
| Ngày | Việc |
|---|---|
| 1–2 | **Đức giao đầu tiên và gộp vào nhánh chính:** `01_schema_seed.sql`, **cả 9 lớp DTO**, `DbHelper`, `Result`, `Clock`, `Money`, DAL dùng chung (`SachDAL`, `ChiTietMuonDAL`, `CauHinhDAL`, `PhieuThuDAL`, `TaiKhoanDAL`), `PhieuThuBLL.TaoPhieuThu`, `AuthBLL`, khung `frmMain` + đăng nhập. **Thành và Cường không viết DTO**; trong lúc chờ chỉ viết DAL/BLL/GUI của module mình (DAL riêng: `PhieuMuonDAL`, `DocGiaDAL`, `TheThuVienDAL`, `PhieuThuDAL` mở rộng truy vấn…) dựa trên chữ ký ở mục 6c. |
| 3–6 | Mỗi người làm module của mình trên nhánh `feature/<module>`; seed có sẵn giao dịch mẫu để Thành thử trả/phạt ngay. |
| 7–8 | Gộp nhánh, tích hợp, chạy `02_doi_soat.sql` sau mỗi kịch bản test, sửa lỗi nhập liệu, làm đẹp giao diện. |
| 9 | Dự phòng, báo cáo/slide, tập trả lời câu hỏi của giảng viên. |

**Kịch bản test từ dữ liệu mẫu:** An (CTM1, CTM2) quá hạn 16 ngày → thử trả Hỏng + trễ (2 phiếu), trả Mất (không phạt trễ), và thử mượn/gia hạn bị BR04 chặn. Dung (CTM4 hạn = hôm nay) → trả đúng ngày không phạt; (CTM4, CTM5) → gia hạn thành công. Bình có thẻ hết hạn → không mượn được nhưng vẫn trả. Cường chưa có thẻ → thử cấp thẻ.
