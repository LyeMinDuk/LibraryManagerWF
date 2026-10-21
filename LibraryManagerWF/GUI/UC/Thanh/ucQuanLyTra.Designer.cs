namespace LibraryManagerWF.GUI
{
    partial class ucQuanLyTra
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.flpTimKiem = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLocTuKhoa = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.flbThongTin = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTTThe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gbTimKiem.SuspendLayout();
            this.flpTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.flbThongTin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbThaoTac.SuspendLayout();
            this.flpThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 171);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(1295, 417);
            this.dgv.TabIndex = 0;
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.flpTimKiem);
            this.gbTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTimKiem.Location = new System.Drawing.Point(0, 0);
            this.gbTimKiem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Padding = new System.Windows.Forms.Padding(9, 4, 9, 9);
            this.gbTimKiem.Size = new System.Drawing.Size(1295, 82);
            this.gbTimKiem.TabIndex = 4;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm / lọc";
            // 
            // flpTimKiem
            // 
            this.flpTimKiem.Controls.Add(this.lblLocTuKhoa);
            this.flpTimKiem.Controls.Add(this.txtTimKiem);
            this.flpTimKiem.Controls.Add(this.btnTimKiem);
            this.flpTimKiem.Controls.Add(this.btnLamMoi);
            this.flpTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpTimKiem.Location = new System.Drawing.Point(9, 27);
            this.flpTimKiem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flpTimKiem.Name = "flpTimKiem";
            this.flpTimKiem.Size = new System.Drawing.Size(1277, 46);
            this.flpTimKiem.TabIndex = 0;
            // 
            // lblLocTuKhoa
            // 
            this.lblLocTuKhoa.AutoSize = true;
            this.lblLocTuKhoa.Location = new System.Drawing.Point(9, 10);
            this.lblLocTuKhoa.Margin = new System.Windows.Forms.Padding(9, 10, 4, 0);
            this.lblLocTuKhoa.Name = "lblLocTuKhoa";
            this.lblLocTuKhoa.Size = new System.Drawing.Size(90, 25);
            this.lblLocTuKhoa.TabIndex = 0;
            this.lblLocTuKhoa.Text = "Từ khóa:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(107, 6);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 3);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(273, 30);
            this.txtTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(388, 3);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(115, 32);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(511, 3);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(115, 32);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // gbThongTin
            // 
            this.gbThongTin.AutoSize = true;
            this.gbThongTin.Controls.Add(this.flbThongTin);
            this.gbThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTin.Location = new System.Drawing.Point(0, 82);
            this.gbThongTin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Padding = new System.Windows.Forms.Padding(9, 4, 9, 9);
            this.gbThongTin.Size = new System.Drawing.Size(1295, 89);
            this.gbThongTin.TabIndex = 5;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin bạn đọc";
            // 
            // flbThongTin
            // 
            this.flbThongTin.AutoSize = true;
            this.flbThongTin.Controls.Add(this.tableLayoutPanel1);
            this.flbThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.flbThongTin.Location = new System.Drawing.Point(9, 27);
            this.flbThongTin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flbThongTin.Name = "flbThongTin";
            this.flbThongTin.Size = new System.Drawing.Size(1277, 53);
            this.flbThongTin.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 389F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 424F));
            this.tableLayoutPanel1.Controls.Add(this.txtTTThe, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHoTen, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1272, 49);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // txtTTThe
            // 
            this.txtTTThe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTTThe.Location = new System.Drawing.Point(851, 9);
            this.txtTTThe.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTTThe.Name = "txtTTThe";
            this.txtTTThe.ReadOnly = true;
            this.txtTTThe.Size = new System.Drawing.Size(417, 30);
            this.txtTTThe.TabIndex = 4;
            this.txtTTThe.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Trạng thái thẻ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoTen.Location = new System.Drawing.Point(233, 9);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(381, 30);
            this.txtHoTen.TabIndex = 2;
            this.txtHoTen.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên:";
            // 
            // gbThaoTac
            // 
            this.gbThaoTac.Controls.Add(this.flpThaoTac);
            this.gbThaoTac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbThaoTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThaoTac.Location = new System.Drawing.Point(0, 588);
            this.gbThaoTac.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbThaoTac.Name = "gbThaoTac";
            this.gbThaoTac.Padding = new System.Windows.Forms.Padding(9, 4, 9, 9);
            this.gbThaoTac.Size = new System.Drawing.Size(1295, 89);
            this.gbThaoTac.TabIndex = 6;
            this.gbThaoTac.TabStop = false;
            this.gbThaoTac.Text = "Thao tác";
            // 
            // flpThaoTac
            // 
            this.flpThaoTac.Controls.Add(this.btnXacNhan);
            this.flpThaoTac.Controls.Add(this.btnSua);
            this.flpThaoTac.Controls.Add(this.btnXoa);
            this.flpThaoTac.Controls.Add(this.btnHuy);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThaoTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpThaoTac.Location = new System.Drawing.Point(9, 27);
            this.flpThaoTac.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.Size = new System.Drawing.Size(1277, 53);
            this.flpThaoTac.TabIndex = 0;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(4, 3);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(109, 36);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(121, 3);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(109, 36);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(238, 3);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(109, 36);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(355, 3);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(109, 36);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // ucQuanLyTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.gbThaoTac);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbTimKiem);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucQuanLyTra";
            this.Size = new System.Drawing.Size(1295, 677);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gbTimKiem.ResumeLayout(false);
            this.flpTimKiem.ResumeLayout(false);
            this.flpTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.flbThongTin.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbThaoTac.ResumeLayout(false);
            this.flpThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.FlowLayoutPanel flpTimKiem;
        private System.Windows.Forms.Label lblLocTuKhoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.FlowLayoutPanel flbThongTin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTTThe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
    }
}
