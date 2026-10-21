using System;
using System.Data;
using LibraryManagerWF.DTO;

namespace LibraryManagerWF.DAL
{
    public static class PhieuMuonDAL
    {
        public static int Them(DataBaseProcess db, PhieuMuonDTO pm)
        {
            return db.ThemLayMa("INSERT INTO PhieuMuon(MaThe, NgayMuon, MaTK) VALUES(@0, @1, @2)", pm.MaThe, pm.NgayMuon, pm.MaTK);
        }

        public static PhieuMuonDTO LayTheoMa(DataBaseProcess db, int maPM)
        {
            DataTable dt = db.DocBang("SELECT MaPM, MaThe, NgayMuon, MaTK FROM PhieuMuon WHERE MaPM = @0", maPM);
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new PhieuMuonDTO
            {
                MaPM = (int)r["MaPM"],
                MaThe = (int)r["MaThe"],
                NgayMuon = (DateTime)r["NgayMuon"],
                MaTK = (int)r["MaTK"]
            };
        }
    }
}
