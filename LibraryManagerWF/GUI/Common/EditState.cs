using System;
using System.Drawing;

namespace LibraryManagerWF.GUI
{
    /// <summary>Trạng thái màn hình thông tin (CRUD): xem / đang thêm / đang sửa. (Map từ enum State của bản cũ.)</summary>
    public enum EditState { Read, Create, Update }

    /// <summary>UC con báo cho UC cha đổi thanh tiêu đề (chữ + màu) theo trạng thái. (Map từ StatusRequestEventArgs bản cũ.)</summary>
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

    /// <summary>UC con nào muốn đổi thanh tiêu đề của UC cha thì cài interface này.</summary>
    public interface IPhatTrangThai
    {
        event EventHandler<StatusRequestEventArgs> OnStatusRequest;
    }

    /// <summary>Màu thanh tiêu đề theo trạng thái (giữ nguyên bảng màu bản cũ).</summary>
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
