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
    public partial class ucQuanLyPhieuThu : ucTabContainer
    {
        public ucQuanLyPhieuThu() : base("QUẢN LÝ PHIẾU THU",
            new TabInfo("Tạo phiếu", () => new ucTaoPhieuThu()),
            new TabInfo("Quản lý phiếu thu", () => new ucThongTinPhieuThu())
            )
        {
        }
    }
}
