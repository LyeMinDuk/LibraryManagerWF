using System;
using System.Collections.Generic;
using System.Data;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.DAL
{
    public static class SachDAL
    {
        static SachDTO TuDong(DataRow r)
        {
            return new SachDTO
            {
                MaSach = (int)r["MaSach"],
                TenSach = r["TenSach"].ToString(),
                TacGia = r["TacGia"].ToString(),
                MaTL = (int)r["MaTL"],
                NXB = r["NXB"] == DBNull.Value ? null : r["NXB"].ToString(),
                NamXB = r["NamXB"] == DBNull.Value ? (int?)null : (int)r["NamXB"],
                GiaBia = (decimal)r["GiaBia"],
                SoLuongTong = (int)r["SoLuongTong"],
                SoLuongCon = (int)r["SoLuongCon"],
                TrangThai = (bool)r["TrangThai"]
            };
        }

        public static SachDTO LayTheoMa(DbHelpers db, int maSach)
        {
            DataTable dt = db.DocBang(
                "SELECT MaSach, TenSach, TacGia, MaTL, NXB, NamXB, GiaBia, SoLuongTong, SoLuongCon, TrangThai FROM Sach WHERE MaSach = @0", maSach);
            return dt.Rows.Count == 0 ? null : TuDong(dt.Rows[0]);
        }

        /// <summary>Tìm sách, ghép dần điều kiện AND theo ô nào được nhập. maTL = 0: mọi thể loại; trangThai = -1: mọi trạng thái.</summary>
        public static DataTable TimKiem(DbHelpers db, string tuKhoa, int maTL, int trangThai)
        {
            string sql =
                "SELECT s.MaSach, s.TenSach, s.TacGia, s.MaTL, tl.TenTL, s.NXB, s.NamXB, s.GiaBia, " +
                "s.SoLuongTong, s.SoLuongCon, s.TrangThai " +
                "FROM Sach s JOIN TheLoai tl ON tl.MaTL = s.MaTL WHERE 1 = 1";
            List<object> gt = new List<object>();    // giá trị lần lượt là @0, @1, ...

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                string p = "@" + gt.Count;
                gt.Add("%" + tuKhoa.Trim() + "%");
                sql += " AND (s.TenSach LIKE " + p + " OR s.TacGia LIKE " + p + " OR s.NXB LIKE " + p + ")";
            }
            if (maTL > 0)
            {
                sql += " AND s.MaTL = @" + gt.Count;
                gt.Add(maTL);
            }
            if (trangThai >= 0)
            {
                sql += " AND s.TrangThai = @" + gt.Count;
                gt.Add(trangThai == 1);
            }
            return db.DocBang(sql + " ORDER BY s.MaSach", gt.ToArray());
        }

        /// <summary>Sách mới: số lượng còn = số lượng tổng, đang hoạt động.</summary>
        public static int Them(DbHelpers db, SachDTO s)
        {
            return db.CapNhat(
                "INSERT INTO Sach(TenSach, TacGia, MaTL, NXB, NamXB, GiaBia, SoLuongTong, SoLuongCon, TrangThai) " +
                "VALUES(@0, @1, @2, @3, @4, @5, @6, @6, 1)",
                s.TenSach, s.TacGia, s.MaTL, s.NXB, s.NamXB, s.GiaBia, s.SoLuongTong);
        }

        /// <summary>Đổi tổng thì "còn" đổi cùng mức, giữ đúng: còn = tổng - đang mượn.</summary>
        public static int Sua(DbHelpers db, SachDTO s)
        {
            return db.CapNhat(
                "UPDATE Sach SET TenSach = @0, TacGia = @1, MaTL = @2, NXB = @3, NamXB = @4, GiaBia = @5, " +
                "SoLuongCon = SoLuongCon + (@6 - SoLuongTong), SoLuongTong = @6 WHERE MaSach = @7",
                s.TenSach, s.TacGia, s.MaTL, s.NXB, s.NamXB, s.GiaBia, s.SoLuongTong, s.MaSach);
        }

        public static int DoiTrangThai(DbHelpers db, int maSach, bool hoatDong)
        {
            return db.CapNhat("UPDATE Sach SET TrangThai = @0 WHERE MaSach = @1", hoatDong, maSach);
        }

        public static int DemLuotMuon(DbHelpers db, int maSach)
        {
            return (int)db.LayMotGiaTri("SELECT COUNT(*) FROM ChiTietMuon WHERE MaSach = @0", maSach);
        }

        public static int Xoa(DbHelpers db, int maSach)
        {
            return db.CapNhat("DELETE FROM Sach WHERE MaSach = @0", maSach);
        }

        // ===== Tồn kho: chỉ Mượn và Trả được gọi =====

        /// <summary>Trừ kho một cuốn. Trả 0 dòng nghĩa là sách đã hết hoặc đang bị khóa (BR05).</summary>
        public static int TruKho(DbHelpers db, int maSach)
        {
            return db.CapNhat("UPDATE Sach SET SoLuongCon = SoLuongCon - 1 WHERE MaSach = @0 AND SoLuongCon > 0 AND TrangThai = 1", maSach);
        }

        public static int CongKho(DbHelpers db, int maSach)
        {
            return db.CapNhat("UPDATE Sach SET SoLuongCon = SoLuongCon + 1 WHERE MaSach = @0", maSach);
        }

        /// <summary>Sách mất: giảm tổng (cuốn đó đã bị trừ "còn" từ lúc mượn).</summary>
        public static int GiamTong(DbHelpers db, int maSach)
        {
            return db.CapNhat("UPDATE Sach SET SoLuongTong = SoLuongTong - 1 WHERE MaSach = @0", maSach);
        }
    }
}
