using System.Drawing;

namespace LibraryManagerWF.GUI
{
    /// <summary>Màu sắc/font dùng chung để giao diện đồng nhất giữa các module.</summary>
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

        public static Font MakeFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("Segoe UI", size, style);
        }
    }
}
