using System.Drawing;

namespace LibraryManagerWF.GUI
{
    internal static class Theme
    {
        public static readonly Color Sidebar = Color.FromArgb(31, 42, 68);
        public static readonly Color SidebarHover = Color.FromArgb(48, 64, 100);
        public static readonly Color SidebarChon = Color.FromArgb(45, 108, 223);
        public static readonly Color Accent = Color.FromArgb(45, 108, 223);
        public static readonly Color Nen = Color.FromArgb(244, 246, 250);
        public static readonly Color Chu = Color.FromArgb(33, 37, 41);
        public static readonly Color ChuPhu = Color.FromArgb(108, 117, 125);
        public static readonly Color ChuSangTrenToi = Color.FromArgb(226, 232, 245);

        public static readonly Color HangKhoa = Color.FromArgb(222, 226, 230);
        public static readonly Color HangCanhBao = Color.Khaki;
        public static readonly Color HangLoi = Color.LightCoral;
        public static readonly Color HangTot = Color.LightGreen;
        public static readonly Color HangNhan = Color.FromArgb(214, 230, 242);
        public static readonly Color HangCam = Color.FromArgb(255, 224, 178);

        public static Font MakeFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("Segoe UI", size, style);
        }
    }
}
