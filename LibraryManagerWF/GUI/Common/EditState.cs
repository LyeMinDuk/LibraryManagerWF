using System;
using System.Drawing;

namespace LibraryManagerWF.GUI
{
    public enum EditState
    {
        Read, Create, Update
    }

    public class StatusRequestEventArgs : EventArgs
    {
        public string TitleText { get; private set; }
        public Color BackColor { get; private set; }
        public Color ForeColor { get; private set; }

        public StatusRequestEventArgs(string text, Color back, Color fore)
        {
            TitleText = text;
            BackColor = back;
            ForeColor = fore;
        }
    }

    public interface IPhatTrangThai
    {
        event EventHandler<StatusRequestEventArgs> OnStatusRequest;
    }

    public static class MauTrangThai
    {
        public static readonly Color Xem = Color.FromArgb(32, 36, 104);
        public static readonly Color Them = Color.SeaGreen;
        public static readonly Color Sua = Color.DarkOrange;

        public static StatusRequestEventArgs Tao(EditState st, string tenDoiTuong, string tieuDeXem = null)
        {
            string ten = tenDoiTuong.ToUpperInvariant();
            switch (st)
            {
                case EditState.Create: return new StatusRequestEventArgs("THÊM " + ten + " MỚI", Them, Color.White);
                case EditState.Update: return new StatusRequestEventArgs("CẬP NHẬT " + ten, Sua, Color.White);
                default: return new StatusRequestEventArgs(tieuDeXem ?? ("DANH SÁCH " + ten), Xem, Color.White);
            }
        }
    }
}
