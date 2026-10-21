using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    /// <summary>Kiểu lưới dùng chung (map từ ConfigureDGVStyle của bản cũ). Cột khai báo bằng AddText/AddFill.</summary>
    internal static class GridStyle
    {
        public static void Apply(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 52, 129);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 52, 129);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font.FontFamily, 10f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 32;

            dgv.DefaultCellStyle.Font = new Font(dgv.Font.FontFamily, 10f, FontStyle.Regular);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 230, 242);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(48, 52, 129);
            dgv.RowTemplate.Height = 28;
            dgv.Columns.Clear();
        }

        public static DataGridViewTextBoxColumn AddText(DataGridView dgv, string header, string property,
            string format = null, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
        {
            var c = new DataGridViewTextBoxColumn { HeaderText = header, DataPropertyName = property, Name = property };
            if (format != null) c.DefaultCellStyle.Format = format;
            c.DefaultCellStyle.Alignment = align;
            dgv.Columns.Add(c);
            return c;
        }

        /// <summary>Cột dài: chiếm phần còn lại của lưới.</summary>
        public static DataGridViewTextBoxColumn AddFill(DataGridView dgv, string header, string property, int minWidth)
        {
            DataGridViewTextBoxColumn c = AddText(dgv, header, property);
            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c.MinimumWidth = minWidth;
            return c;
        }
    }
}
