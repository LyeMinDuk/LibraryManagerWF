# Các hàm BLL (GUI chỉ gọi những hàm này)

Quy ước: hàm ghi trả `string`, **null = thành công**; `out` là kết quả thêm; hàm đọc trả `DataTable` (gán thẳng vào lưới) hoặc DTO.
Thiếu quyền thì **ném `UnauthorizedAccessException`** (GUI đã ẩn nút nên chỉ xảy ra khi code sai; `Program.cs` bắt chung).
Mọi hàm BLL đều yêu cầu đăng nhập, trừ `AuthBLL.DangNhap/DangXuat`, hàm kiểm tra thuần và hàm nhận `db`. "QT" = chỉ QuanTri (QuanTri bao trùm ThuThu).

## AuthBLL
`string DangNhap(tenDN, matKhau)` (thành công thì `AppSession.MaTK/HoTen/VaiTro` có giá trị) · `void DangXuat()` · `string DoiMatKhau(matCu, matMoi)` · `string KiemTraMatKhauMoi(mk)` · `string TaoMatKhauHash(mk)` · `bool KiemTraMatKhau(mk, daLuu)`

## TaiKhoanBLL (QT)
`DataTable LayTatCa()` · `string Them(tenDN, matKhau, hoTen, vaiTro)` · `string Sua(maTK, hoTen, vaiTro)` · `string DatLaiMatKhau(maTK, matKhauMoi)` · `string DoiTrangThai(maTK, hoatDong)` · `string Xoa(maTK)`. Không tự khóa, hạ quyền, xóa mình; đã lập phiếu thì chỉ khóa.

## CauHinhBLL
`DataTable LayTatCa()` · `string CapNhat(khoa, giaTri)` (QT)

## TheLoaiBLL
`DataTable LayTatCa()` · `string Them(ten)` · `string Sua(maTL, ten)` · `string Xoa(maTL)`

## SachBLL
`DataTable TimKiem(tuKhoa, maTL, trangThai)` (maTL 0 = tất cả; trangThai -1 tất cả, 1 hoạt động, 0 khóa) · `string Them(SachDTO)` · `string Sua(SachDTO)` · `void DoiTrangThai(maSach, hoatDong)` · `string Xoa(maSach)` · `string KiemTra(SachDTO)`

## DocGiaBLL
`DataTable TimKiem(tuKhoa)` · `string Them(DocGiaDTO)` · `string Sua(DocGiaDTO)` · `void DoiTrangThai(maDG, hoatDong)` · `string Xoa(maDG)` · `string KiemTra(DocGiaDTO)`

## TheBLL
`string TinhTrangThe(bool trangThai, DateTime ngayHetHan)` · `TheThuVienDTO LayTheoDocGia(maDG)` (null = chưa có thẻ) · `string CapThe(maDG, out ngayHetHan)` · `string GiaHanThe(maThe, out ngayHetHanMoi)` · `void DoiTrangThai(maThe, hoatDong)` · `string Xoa(maThe)` · `string KiemTraDuocMuon(DataBaseProcess db, maThe)` (dùng trong transaction)

## MuonBLL
`string Muon(maThe, List<int> dsMaSach, out hanTra)` · `string GiaHan(maCTM, out hanMoi)` · `DataTable DanhSachMuon(tuKhoa, maThe, loc)` (loc 0 tất cả, 1 đang mượn, 2 quá hạn, 3 đã trả)

## TraBLL
`string XemTruoc(maCTM, tinhTrang, out tienPhat, out tienDen)` · `string Tra(maCTM, tinhTrang, daThuTien, out tienPhat, out tienDen)`. tinhTrang là một trong `TinhTrangMuon.BinhThuong/Hong/Mat`.

## TinhPhatBLL (hàm thuần, có test)
`int SoNgayTre(hanTra, ngayTra)` · `decimal TienPhatTre(giaBia, soNgayTre, phatMoiNgay)` · `decimal TienDen(giaBia, phanTram)`

## PhieuThuBLL
`DataTable TimKiem(tuNgay, denNgay, loaiThu)` · `DataTable DoanhThuTheoLoai(tu, den)` (QT) · `DataTable DoanhThuTheoNgay(tu, den)` (QT) · `int TaoPhieuThu(DataBaseProcess db, loaiThu, soTien, maThe, maCTM, ghiChu)` (dùng trong transaction)
