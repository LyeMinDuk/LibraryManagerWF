using System;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
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
