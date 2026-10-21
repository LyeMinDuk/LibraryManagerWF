/* Truy vấn đối soát - CHẠY SAU MỖI LẦN TEST MƯỢN/TRẢ. TẤT CẢ kết quả phải RỖNG. */
USE LibraryDB;
GO

-- 1. SoLuongCon phải = SoLuongTong - số cuốn đang mượn ('Chưa trả').
--    Sách Mất: SoLuongTong đã giảm 1 nên công thức vẫn đúng. Sách Hỏng: về kho, SoLuongCon + 1.
SELECT s.MaSach, s.TenSach, s.SoLuongTong, s.SoLuongCon,
       s.SoLuongTong - COUNT(CASE WHEN c.TinhTrang = N'Chưa trả' THEN 1 END) AS SoLuongConDung
FROM Sach s
LEFT JOIN ChiTietMuon c ON c.MaSach = s.MaSach
GROUP BY s.MaSach, s.TenSach, s.SoLuongTong, s.SoLuongCon
HAVING s.SoLuongCon <> s.SoLuongTong - COUNT(CASE WHEN c.TinhTrang = N'Chưa trả' THEN 1 END);

-- 2. Phiếu mượn không có chi tiết (SQL không ép được; BLL tạo phiếu + chi tiết trong 1 transaction)
SELECT pm.MaPM
FROM PhieuMuon pm
WHERE NOT EXISTS (SELECT 1 FROM ChiTietMuon c WHERE c.MaPM = pm.MaPM);

-- 3. Thẻ đang giữ hơn 5 cuốn (BR02 mặc định; sửa số 5 nếu đổi CauHinh)
SELECT pm.MaThe, COUNT(*) AS DangMuon
FROM PhieuMuon pm
JOIN ChiTietMuon c ON c.MaPM = pm.MaPM AND c.TinhTrang = N'Chưa trả'
GROUP BY pm.MaThe
HAVING COUNT(*) > 5;

-- 4. BR13: có phiếu Phạt trễ/Đền bù nhưng cuốn đó chưa được đóng giao dịch (NgayTra IS NULL)
SELECT pt.MaPT, pt.LoaiThu, pt.MaCTM
FROM PhieuThu pt
JOIN ChiTietMuon c ON c.MaCTM = pt.MaCTM
WHERE c.NgayTra IS NULL;

-- 5. BR07/BR13: cuốn Hỏng hoặc Mất mà KHÔNG có phiếu Đền bù
SELECT c.MaCTM, c.TinhTrang
FROM ChiTietMuon c
WHERE c.TinhTrang IN (N'Hỏng', N'Mất')
  AND NOT EXISTS (SELECT 1 FROM PhieuThu pt WHERE pt.MaCTM = c.MaCTM AND pt.LoaiThu = N'Đền bù');

-- 6. BR06/BR13: cuốn Bình thường/Hỏng trả trễ mà KHÔNG có phiếu Phạt trễ
SELECT c.MaCTM, c.HanTra, c.NgayTra
FROM ChiTietMuon c
WHERE c.TinhTrang IN (N'Bình thường', N'Hỏng') AND c.NgayTra > c.HanTra
  AND NOT EXISTS (SELECT 1 FROM PhieuThu pt WHERE pt.MaCTM = c.MaCTM AND pt.LoaiThu = N'Phạt trễ');

-- 7. Cuốn Mất mà lại có phiếu Phạt trễ (quy định: mất không phạt trễ)
SELECT c.MaCTM
FROM ChiTietMuon c
JOIN PhieuThu pt ON pt.MaCTM = c.MaCTM AND pt.LoaiThu = N'Phạt trễ'
WHERE c.TinhTrang = N'Mất';

-- 8. Sai SỐ TIỀN phiếu Phạt trễ / Đền bù. CHỈ đúng khi CauHinh chưa bị đổi sau giao dịch
--    (SoTien là dữ liệu chụp tại thời điểm thu; đổi đơn giá rồi thì truy vấn này sẽ báo các phiếu cũ).
WITH cfg AS (
    SELECT CAST(MAX(CASE WHEN Khoa = 'PHAT_TRE_MOI_NGAY'  THEN GiaTri END) AS INT) AS Phat,
           CAST(MAX(CASE WHEN Khoa = 'DEN_HONG_PHAN_TRAM' THEN GiaTri END) AS INT) AS Hong,
           CAST(MAX(CASE WHEN Khoa = 'DEN_MAT_PHAN_TRAM'  THEN GiaTri END) AS INT) AS Mat
    FROM CauHinh)
SELECT pt.MaPT, pt.LoaiThu, pt.SoTien
FROM PhieuThu pt
JOIN ChiTietMuon c ON c.MaCTM = pt.MaCTM
JOIN Sach s ON s.MaSach = c.MaSach
CROSS JOIN cfg
WHERE (pt.LoaiThu = N'Phạt trễ' AND pt.SoTien <>
          CASE WHEN DATEDIFF(DAY, c.HanTra, c.NgayTra) * cfg.Phat > s.GiaBia
               THEN s.GiaBia ELSE DATEDIFF(DAY, c.HanTra, c.NgayTra) * cfg.Phat END)
   OR (pt.LoaiThu = N'Đền bù' AND pt.SoTien <>
          ROUND(s.GiaBia * CASE c.TinhTrang WHEN N'Hỏng' THEN cfg.Hong ELSE cfg.Mat END / 100.0, 0));
GO
