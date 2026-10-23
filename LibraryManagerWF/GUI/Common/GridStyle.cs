using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    internal static class GridStyle
    {
        public static void BatDoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(c, true, null);
        }

        public static void Apply(DataGridView dgv)
        {
            BatDoubleBuffer(dgv);
            dgv.AutoGenerateColumns = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 52, 129);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 52, 129);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font.FontFamily, 12f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 38;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font(dgv.Font.FontFamily, 12f, FontStyle.Regular);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(205, 220, 240);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowTemplate.Height = 34;
            dgv.GridColor = Color.FromArgb(210, 210, 210);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.Columns.Clear();
        }

        public static DataGridViewTextBoxColumn AddText(DataGridView dgv, string header, string property,
            string format = null, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
        {
            var c = new DataGridViewTextBoxColumn { HeaderText = header, DataPropertyName = property, Name = property };
            if (format != null)
                c.DefaultCellStyle.Format = format;
            c.DefaultCellStyle.Alignment = align;
            dgv.Columns.Add(c);
            return c;
        }

        public static DataGridViewTextBoxColumn AddFill(DataGridView dgv, string header, string property, int minWidth)
        {
            DataGridViewTextBoxColumn c = AddText(dgv, header, property);
            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c.MinimumWidth = minWidth;
            return c;
        }

        public static void Apply(DataGridView dgv, float coChu)
        {
            Apply(dgv);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font.FontFamily, coChu, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font(dgv.Font.FontFamily, coChu, FontStyle.Regular);
            dgv.ColumnHeadersHeight = 38;
            dgv.RowTemplate.Height = 34;
        }
    }
}
