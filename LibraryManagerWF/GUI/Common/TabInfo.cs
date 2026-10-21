using System;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    /// <summary>Một tab: tên nút + hàm tạo UserControl con (tạo mới mỗi lần bấm để dữ liệu luôn tươi).</summary>
    public class TabInfo
    {
        public string Ten { get; private set; }
        public Func<UserControl> Tao { get; private set; }

        public TabInfo(string ten, Func<UserControl> tao)
        {
            Ten = ten;
            Tao = tao;
        }
    }
}
