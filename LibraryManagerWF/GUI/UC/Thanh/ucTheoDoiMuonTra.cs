using LibraryManagerWF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    public partial class ucTheoDoiMuonTra : ucTabContainer
    {
        public ucTheoDoiMuonTra()
        {
            InitializeComponent();
        }
        //public ucTheoDoiMuonTra() : base("THEO DÕI MƯỢN TRẢ",
        //    new TabInfo("Tất cả", () => new ucDSMuonTra(LocMuon.TatCa)),
        //    new TabInfo("Đang mượn", () => new ucDSMuonTra(LocMuon.DangMuon)),
        //    new TabInfo("Quá hạn", () => new ucDSMuonTra(LocMuon.QuaHan)),
        //    new TabInfo("Đã trả", () => new ucDSMuonTra(LocMuon.DaTra))
        //    )
        //{
        //}
    }
}
