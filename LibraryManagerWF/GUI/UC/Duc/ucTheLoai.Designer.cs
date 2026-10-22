namespace LibraryManagerWF.GUI.UC.Duc
{
    partial class ucTheLoai
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
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.flpTimKiem = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenTL = new System.Windows.Forms.Label();
            this.txtTenTL = new System.Windows.Forms.TextBox();
            this.lblMaTL = new System.Windows.Forms.Label();
            this.txtMaTL = new System.Windows.Forms.TextBox();
            this.lblSoSach = new System.Windows.Forms.Label();
            this.txtSoSach = new System.Windows.Forms.TextBox();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlChuThich = new System.Windows.Forms.Panel();
            this.pnlMauTrong = new System.Windows.Forms.Panel();
            this.lblChuThichTrong = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gbTimKiem.SuspendLayout();
            this.flpTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            this.gbThaoTac.SuspendLayout();
            this.flpThaoTac.SuspendLayout();
            this.pnlChuThich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.flpTimKiem);
            this.gbTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTimKiem.Location = new System.Drawing.Point(0, 0);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbTimKiem.Size = new System.Drawing.Size(1200, 78);
            this.gbTimKiem.TabIndex = 0;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm (tên thể loại)";
            // 
            // flpTimKiem
            // 
            this.flpTimKiem.Controls.Add(this.lblTuKhoa);
            this.flpTimKiem.Controls.Add(this.txtTimKiem);
            this.flpTimKiem.Controls.Add(this.btnTimKiem);
            this.flpTimKiem.Controls.Add(this.btnLamMoi);
            this.flpTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTimKiem.Location = new System.Drawing.Point(10, 28);
            this.flpTimKiem.Name = "flpTimKiem";
            this.flpTimKiem.Size = new System.Drawing.Size(1180, 42);
            this.flpTimKiem.TabIndex = 0;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuKhoa.Location = new System.Drawing.Point(10, 12);
            this.lblTuKhoa.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(90, 25);
            this.lblTuKhoa.TabIndex = 0;
            this.lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(108, 8);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 30);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(416, 4);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 42);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(544, 4);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 42);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.tlpThongTin);
            this.gbThongTin.Controls.Add(this.lblTieuDe);
            this.gbThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTin.Location = new System.Drawing.Point(0, 78);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbThongTin.Size = new System.Drawing.Size(1200, 170);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin thể loại";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Controls.Add(this.lblTenTL, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtTenTL, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblMaTL, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtMaTL, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblSoSach, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtSoSach, 3, 1);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Location = new System.Drawing.Point(10, 60);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 2;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.Size = new System.Drawing.Size(1180, 102);
            this.tlpThongTin.TabIndex = 1;
            // 
            // lblTenTL
            // 
            this.lblTenTL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenTL.AutoSize = true;
            this.lblTenTL.Location = new System.Drawing.Point(3, 9);
            this.lblTenTL.Name = "lblTenTL";
            this.lblTenTL.Size = new System.Drawing.Size(137, 25);
            this.lblTenTL.TabIndex = 0;
            this.lblTenTL.Text = "Tên thể loại:";
            this.lblTenTL.UseMnemonic = false;
            // 
            // txtTenTL
            // 
            this.txtTenTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenTL.Location = new System.Drawing.Point(164, 7);
            this.txtTenTL.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenTL.MaxLength = 100;
            this.txtTenTL.Name = "txtTenTL";
            this.txtTenTL.Size = new System.Drawing.Size(422, 30);
            this.txtTenTL.TabIndex = 1;
            // 
            // lblMaTL
            // 
            this.lblMaTL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaTL.AutoSize = true;
            this.lblMaTL.Location = new System.Drawing.Point(3, 53);
            this.lblMaTL.Name = "lblMaTL";
            this.lblMaTL.Size = new System.Drawing.Size(133, 25);
            this.lblMaTL.TabIndex = 2;
            this.lblMaTL.Text = "Mã thể loại:";
            this.lblMaTL.UseMnemonic = false;
            // 
            // txtMaTL
            // 
            this.txtMaTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaTL.Location = new System.Drawing.Point(164, 51);
            this.txtMaTL.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTL.Name = "txtMaTL";
            this.txtMaTL.ReadOnly = true;
            this.txtMaTL.Size = new System.Drawing.Size(422, 30);
            this.txtMaTL.TabIndex = 3;
            // 
            // lblSoSach
            // 
            this.lblSoSach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSoSach.AutoSize = true;
            this.lblSoSach.Location = new System.Drawing.Point(593, 53);
            this.lblSoSach.Name = "lblSoSach";
            this.lblSoSach.Size = new System.Drawing.Size(88, 25);
            this.lblSoSach.TabIndex = 4;
            this.lblSoSach.Text = "Số sách:";
            this.lblSoSach.UseMnemonic = false;
            // 
            // txtSoSach
            // 
            this.txtSoSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoSach.Location = new System.Drawing.Point(754, 51);
            this.txtSoSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoSach.Name = "txtSoSach";
            this.txtSoSach.ReadOnly = true;
            this.txtSoSach.Size = new System.Drawing.Size(422, 30);
            this.txtSoSach.TabIndex = 5;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Location = new System.Drawing.Point(10, 28);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1180, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÔNG TIN THỂ LOẠI";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.UseMnemonic = false;
            // 
            // gbThaoTac
            // 
            this.gbThaoTac.Controls.Add(this.flpThaoTac);
            this.gbThaoTac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbThaoTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThaoTac.Location = new System.Drawing.Point(0, 573);
            this.gbThaoTac.Name = "gbThaoTac";
            this.gbThaoTac.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbThaoTac.Size = new System.Drawing.Size(1200, 87);
            this.gbThaoTac.TabIndex = 3;
            this.gbThaoTac.TabStop = false;
            this.gbThaoTac.Text = "Thao tác";
            // 
            // flpThaoTac
            // 
            this.flpThaoTac.Controls.Add(this.btnThem);
            this.flpThaoTac.Controls.Add(this.btnSua);
            this.flpThaoTac.Controls.Add(this.btnXoa);
            this.flpThaoTac.Controls.Add(this.btnXacNhan);
            this.flpThaoTac.Controls.Add(this.btnHuy);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThaoTac.Location = new System.Drawing.Point(10, 28);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.Size = new System.Drawing.Size(1180, 51);
            this.flpThaoTac.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(4, 4);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(122, 4);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 42);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(240, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(358, 4);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 42);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(486, 4);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 42);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // pnlChuThich
            // 
            this.pnlChuThich.Controls.Add(this.pnlMauTrong);
            this.pnlChuThich.Controls.Add(this.lblChuThichTrong);
            this.pnlChuThich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChuThich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlChuThich.Location = new System.Drawing.Point(0, 533);
            this.pnlChuThich.Name = "pnlChuThich";
            this.pnlChuThich.Size = new System.Drawing.Size(1200, 40);
            this.pnlChuThich.TabIndex = 4;
            // 
            // pnlMauTrong
            // 
            this.pnlMauTrong.BackColor = System.Drawing.Color.Khaki;
            this.pnlMauTrong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauTrong.Location = new System.Drawing.Point(12, 10);
            this.pnlMauTrong.Name = "pnlMauTrong";
            this.pnlMauTrong.Size = new System.Drawing.Size(20, 20);
            this.pnlMauTrong.TabIndex = 0;
            // 
            // lblChuThichTrong
            // 
            this.lblChuThichTrong.AutoSize = true;
            this.lblChuThichTrong.Location = new System.Drawing.Point(38, 8);
            this.lblChuThichTrong.Name = "lblChuThichTrong";
            this.lblChuThichTrong.Size = new System.Drawing.Size(293, 25);
            this.lblChuThichTrong.TabIndex = 1;
            this.lblChuThichTrong.Text = "Chưa có sách nào (xóa được)";
            this.lblChuThichTrong.UseMnemonic = false;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 248);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(1200, 285);
            this.dgv.TabIndex = 2;
            // 
            // ucTheLoai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlChuThich);
            this.Controls.Add(this.gbThaoTac);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "ucTheLoai";
            this.Size = new System.Drawing.Size(1200, 660);
            this.gbTimKiem.ResumeLayout(false);
            this.flpTimKiem.ResumeLayout(false);
            this.flpTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.tlpThongTin.ResumeLayout(false);
            this.tlpThongTin.PerformLayout();
            this.gbThaoTac.ResumeLayout(false);
            this.flpThaoTac.ResumeLayout(false);
            this.pnlChuThich.ResumeLayout(false);
            this.pnlChuThich.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.FlowLayoutPanel flpTimKiem;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenTL;
        private System.Windows.Forms.TextBox txtTenTL;
        private System.Windows.Forms.Label lblMaTL;
        private System.Windows.Forms.TextBox txtMaTL;
        private System.Windows.Forms.Label lblSoSach;
        private System.Windows.Forms.TextBox txtSoSach;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel pnlChuThich;
        private System.Windows.Forms.Panel pnlMauTrong;
        private System.Windows.Forms.Label lblChuThichTrong;
        private System.Windows.Forms.DataGridView dgv;
    }
}
