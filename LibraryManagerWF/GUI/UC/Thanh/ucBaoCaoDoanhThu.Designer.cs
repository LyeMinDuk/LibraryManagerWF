namespace LibraryManagerWF.GUI
{
    partial class ucBaoCaoDoanhThu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.flpBoLoc = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTu = new System.Windows.Forms.Label();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.lblTongKet = new System.Windows.Forms.Label();
            this.tlpChinh = new System.Windows.Forms.TableLayoutPanel();
            this.gbTheoLoai = new System.Windows.Forms.GroupBox();
            this.chartLoai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvLoai = new System.Windows.Forms.DataGridView();
            this.gbTheoNgay = new System.Windows.Forms.GroupBox();
            this.chartNgay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.flpBoLoc.SuspendLayout();
            this.tlpChinh.SuspendLayout();
            this.gbTheoLoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoai)).BeginInit();
            this.gbTheoNgay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1200, 36);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÁO CÁO DOANH THU";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.UseMnemonic = false;
            // 
            // flpBoLoc
            // 
            this.flpBoLoc.Controls.Add(this.lblTu);
            this.flpBoLoc.Controls.Add(this.dtpTu);
            this.flpBoLoc.Controls.Add(this.lblDen);
            this.flpBoLoc.Controls.Add(this.dtpDen);
            this.flpBoLoc.Controls.Add(this.btnXemBaoCao);
            this.flpBoLoc.Controls.Add(this.btnXuatExcel);
            this.flpBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpBoLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpBoLoc.Location = new System.Drawing.Point(0, 36);
            this.flpBoLoc.Name = "flpBoLoc";
            this.flpBoLoc.Padding = new System.Windows.Forms.Padding(10, 10, 10, 6);
            this.flpBoLoc.Size = new System.Drawing.Size(1200, 54);
            this.flpBoLoc.TabIndex = 1;
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(13, 18);
            this.lblTu.Margin = new System.Windows.Forms.Padding(3, 8, 4, 0);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(105, 29);
            this.lblTu.TabIndex = 0;
            this.lblTu.Text = "Từ ngày:";
            // 
            // dtpTu
            // 
            this.dtpTu.CustomFormat = "dd/MM/yyyy";
            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTu.Location = new System.Drawing.Point(126, 14);
            this.dtpTu.Margin = new System.Windows.Forms.Padding(4, 4, 12, 4);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(160, 35);
            this.dtpTu.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(301, 18);
            this.lblDen.Margin = new System.Windows.Forms.Padding(3, 8, 4, 0);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(120, 29);
            this.lblDen.TabIndex = 2;
            this.lblDen.Text = "Đến ngày:";
            // 
            // dtpDen
            // 
            this.dtpDen.CustomFormat = "dd/MM/yyyy";
            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDen.Location = new System.Drawing.Point(429, 14);
            this.dtpDen.Margin = new System.Windows.Forms.Padding(4, 4, 16, 4);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(160, 35);
            this.dtpDen.TabIndex = 3;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Location = new System.Drawing.Point(609, 14);
            this.btnXemBaoCao.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(160, 38);
            this.btnXemBaoCao.TabIndex = 4;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // lblTongKet
            // 
            this.lblTongKet.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTongKet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongKet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(104)))));
            this.lblTongKet.Location = new System.Drawing.Point(0, 90);
            this.lblTongKet.Name = "lblTongKet";
            this.lblTongKet.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.lblTongKet.Size = new System.Drawing.Size(1200, 42);
            this.lblTongKet.TabIndex = 2;
            this.lblTongKet.Text = "Chọn khoảng ngày rồi bấm \"Xem báo cáo\".";
            this.lblTongKet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTongKet.UseMnemonic = false;
            // 
            // tlpChinh
            // 
            this.tlpChinh.ColumnCount = 2;
            this.tlpChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpChinh.Controls.Add(this.gbTheoLoai, 0, 0);
            this.tlpChinh.Controls.Add(this.gbTheoNgay, 1, 0);
            this.tlpChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChinh.Location = new System.Drawing.Point(0, 132);
            this.tlpChinh.Name = "tlpChinh";
            this.tlpChinh.RowCount = 1;
            this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChinh.Size = new System.Drawing.Size(1200, 528);
            this.tlpChinh.TabIndex = 3;
            // 
            // gbTheoLoai
            // 
            this.gbTheoLoai.Controls.Add(this.chartLoai);
            this.gbTheoLoai.Controls.Add(this.dgvLoai);
            this.gbTheoLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTheoLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTheoLoai.Location = new System.Drawing.Point(3, 3);
            this.gbTheoLoai.Name = "gbTheoLoai";
            this.gbTheoLoai.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbTheoLoai.Size = new System.Drawing.Size(498, 522);
            this.gbTheoLoai.TabIndex = 0;
            this.gbTheoLoai.TabStop = false;
            this.gbTheoLoai.Text = "Doanh thu theo loại thu (biểu đồ tròn)";
            // 
            // chartLoai
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLoai.ChartAreas.Add(chartArea1);
            this.chartLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartLoai.Legends.Add(legend1);
            this.chartLoai.Location = new System.Drawing.Point(10, 33);
            this.chartLoai.Name = "chartLoai";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "N0đ";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLoai.Series.Add(series1);
            this.chartLoai.Size = new System.Drawing.Size(478, 321);
            this.chartLoai.TabIndex = 0;
            this.chartLoai.Text = "chartLoai";
            // 
            // dgvLoai
            // 
            this.dgvLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoai.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLoai.Location = new System.Drawing.Point(10, 354);
            this.dgvLoai.Name = "dgvLoai";
            this.dgvLoai.RowHeadersWidth = 51;
            this.dgvLoai.Size = new System.Drawing.Size(478, 160);
            this.dgvLoai.TabIndex = 1;
            // 
            // gbTheoNgay
            // 
            this.gbTheoNgay.Controls.Add(this.chartNgay);
            this.gbTheoNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTheoNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTheoNgay.Location = new System.Drawing.Point(507, 3);
            this.gbTheoNgay.Name = "gbTheoNgay";
            this.gbTheoNgay.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbTheoNgay.Size = new System.Drawing.Size(690, 522);
            this.gbTheoNgay.TabIndex = 1;
            this.gbTheoNgay.TabStop = false;
            this.gbTheoNgay.Text = "Doanh thu theo ngày (biểu đồ cột)";
            // 
            // chartNgay
            // 
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.LabelStyle.Angle = -45;
            chartArea2.AxisY.LabelStyle.Format = "N0";
            chartArea2.Name = "ChartArea1";
            this.chartNgay.ChartAreas.Add(chartArea2);
            this.chartNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartNgay.Legends.Add(legend2);
            this.chartNgay.Location = new System.Drawing.Point(10, 33);
            this.chartNgay.Name = "chartNgay";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            series2.IsValueShownAsLabel = true;
            series2.LabelFormat = "N0";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartNgay.Series.Add(series2);
            this.chartNgay.Size = new System.Drawing.Size(670, 481);
            this.chartNgay.TabIndex = 0;
            this.chartNgay.Text = "chartNgay";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(777, 14);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(160, 38);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // ucBaoCaoDoanhThu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpChinh);
            this.Controls.Add(this.lblTongKet);
            this.Controls.Add(this.flpBoLoc);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucBaoCaoDoanhThu";
            this.Size = new System.Drawing.Size(1200, 660);
            this.flpBoLoc.ResumeLayout(false);
            this.flpBoLoc.PerformLayout();
            this.tlpChinh.ResumeLayout(false);
            this.gbTheoLoai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoai)).EndInit();
            this.gbTheoNgay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartNgay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.FlowLayoutPanel flpBoLoc;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Label lblTongKet;
        private System.Windows.Forms.TableLayoutPanel tlpChinh;
        private System.Windows.Forms.GroupBox gbTheoLoai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoai;
        private System.Windows.Forms.DataGridView dgvLoai;
        private System.Windows.Forms.GroupBox gbTheoNgay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNgay;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}
