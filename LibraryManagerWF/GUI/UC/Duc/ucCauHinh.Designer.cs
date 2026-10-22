namespace LibraryManagerWF.GUI.UC.Duc
{
    partial class ucCauHinh
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
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.lblGiaTri = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlChuThich = new System.Windows.Forms.Panel();
            this.pnlMauThe = new System.Windows.Forms.Panel();
            this.lblChuThichThe = new System.Windows.Forms.Label();
            this.pnlMauMuon = new System.Windows.Forms.Panel();
            this.lblChuThichMuon = new System.Windows.Forms.Label();
            this.pnlMauPhat = new System.Windows.Forms.Panel();
            this.lblChuThichPhat = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gbThongTin.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            this.gbThaoTac.SuspendLayout();
            this.flpThaoTac.SuspendLayout();
            this.pnlChuThich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.tlpThongTin);
            this.gbThongTin.Controls.Add(this.lblTieuDe);
            this.gbThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTin.Location = new System.Drawing.Point(0, 0);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbThongTin.Size = new System.Drawing.Size(1200, 170);
            this.gbThongTin.TabIndex = 0;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin tham số";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Controls.Add(this.lblKhoa, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtKhoa, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblGiaTri, 2, 0);
            this.tlpThongTin.Controls.Add(this.txtGiaTri, 3, 0);
            this.tlpThongTin.Controls.Add(this.lblMoTa, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtMoTa, 1, 1);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Location = new System.Drawing.Point(10, 60);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 2;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.Size = new System.Drawing.Size(1180, 102);
            this.tlpThongTin.TabIndex = 1;
            // 
            // lblKhoa
            // 
            this.lblKhoa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(3, 9);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(129, 25);
            this.lblKhoa.TabIndex = 0;
            this.lblKhoa.Text = "Mã tham số:";
            this.lblKhoa.UseMnemonic = false;
            // 
            // txtKhoa
            // 
            this.txtKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhoa.Location = new System.Drawing.Point(164, 7);
            this.txtKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.ReadOnly = true;
            this.txtKhoa.Size = new System.Drawing.Size(422, 30);
            this.txtKhoa.TabIndex = 1;
            // 
            // lblGiaTri
            // 
            this.lblGiaTri.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGiaTri.AutoSize = true;
            this.lblGiaTri.Location = new System.Drawing.Point(593, 9);
            this.lblGiaTri.Name = "lblGiaTri";
            this.lblGiaTri.Size = new System.Drawing.Size(80, 25);
            this.lblGiaTri.TabIndex = 2;
            this.lblGiaTri.Text = "Giá trị:";
            this.lblGiaTri.UseMnemonic = false;
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiaTri.Location = new System.Drawing.Point(754, 7);
            this.txtGiaTri.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaTri.MaxLength = 9;
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(422, 30);
            this.txtGiaTri.TabIndex = 3;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(3, 53);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(66, 25);
            this.lblMoTa.TabIndex = 4;
            this.lblMoTa.Text = "Mô tả:";
            this.lblMoTa.UseMnemonic = false;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpThongTin.SetColumnSpan(this.txtMoTa, 3);
            this.txtMoTa.Location = new System.Drawing.Point(164, 51);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(1012, 30);
            this.txtMoTa.TabIndex = 5;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Location = new System.Drawing.Point(10, 28);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1180, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÔNG TIN CẤU HÌNH";
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
            this.flpThaoTac.Controls.Add(this.btnSua);
            this.flpThaoTac.Controls.Add(this.btnLamMoi);
            this.flpThaoTac.Controls.Add(this.btnXacNhan);
            this.flpThaoTac.Controls.Add(this.btnHuy);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThaoTac.Location = new System.Drawing.Point(10, 28);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.Size = new System.Drawing.Size(1180, 51);
            this.flpThaoTac.TabIndex = 0;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(4, 4);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 42);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa giá trị";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(162, 4);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 42);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(290, 4);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 42);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(418, 4);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 42);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // pnlChuThich
            // 
            this.pnlChuThich.Controls.Add(this.pnlMauThe);
            this.pnlChuThich.Controls.Add(this.lblChuThichThe);
            this.pnlChuThich.Controls.Add(this.pnlMauMuon);
            this.pnlChuThich.Controls.Add(this.lblChuThichMuon);
            this.pnlChuThich.Controls.Add(this.pnlMauPhat);
            this.pnlChuThich.Controls.Add(this.lblChuThichPhat);
            this.pnlChuThich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChuThich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlChuThich.Location = new System.Drawing.Point(0, 533);
            this.pnlChuThich.Name = "pnlChuThich";
            this.pnlChuThich.Size = new System.Drawing.Size(1200, 40);
            this.pnlChuThich.TabIndex = 4;
            // 
            // pnlMauThe
            // 
            this.pnlMauThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.pnlMauThe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauThe.Location = new System.Drawing.Point(12, 10);
            this.pnlMauThe.Name = "pnlMauThe";
            this.pnlMauThe.Size = new System.Drawing.Size(20, 20);
            this.pnlMauThe.TabIndex = 0;
            // 
            // lblChuThichThe
            // 
            this.lblChuThichThe.AutoSize = true;
            this.lblChuThichThe.Location = new System.Drawing.Point(38, 8);
            this.lblChuThichThe.Name = "lblChuThichThe";
            this.lblChuThichThe.Size = new System.Drawing.Size(129, 25);
            this.lblChuThichThe.TabIndex = 1;
            this.lblChuThichThe.Text = "Thẻ thư viện";
            this.lblChuThichThe.UseMnemonic = false;
            // 
            // pnlMauMuon
            // 
            this.pnlMauMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.pnlMauMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauMuon.Location = new System.Drawing.Point(200, 10);
            this.pnlMauMuon.Name = "pnlMauMuon";
            this.pnlMauMuon.Size = new System.Drawing.Size(20, 20);
            this.pnlMauMuon.TabIndex = 2;
            // 
            // lblChuThichMuon
            // 
            this.lblChuThichMuon.AutoSize = true;
            this.lblChuThichMuon.Location = new System.Drawing.Point(226, 8);
            this.lblChuThichMuon.Name = "lblChuThichMuon";
            this.lblChuThichMuon.Size = new System.Drawing.Size(154, 25);
            this.lblChuThichMuon.TabIndex = 3;
            this.lblChuThichMuon.Text = "Mượn && gia hạn";
            this.lblChuThichMuon.UseMnemonic = false;
            // 
            // pnlMauPhat
            // 
            this.pnlMauPhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(178)))));
            this.pnlMauPhat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauPhat.Location = new System.Drawing.Point(420, 10);
            this.pnlMauPhat.Name = "pnlMauPhat";
            this.pnlMauPhat.Size = new System.Drawing.Size(20, 20);
            this.pnlMauPhat.TabIndex = 4;
            // 
            // lblChuThichPhat
            // 
            this.lblChuThichPhat.AutoSize = true;
            this.lblChuThichPhat.Location = new System.Drawing.Point(446, 8);
            this.lblChuThichPhat.Name = "lblChuThichPhat";
            this.lblChuThichPhat.Size = new System.Drawing.Size(138, 25);
            this.lblChuThichPhat.TabIndex = 5;
            this.lblChuThichPhat.Text = "Phạt && đền bù";
            this.lblChuThichPhat.UseMnemonic = false;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 170);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(1200, 363);
            this.dgv.TabIndex = 2;
            // 
            // ucCauHinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlChuThich);
            this.Controls.Add(this.gbThaoTac);
            this.Controls.Add(this.gbThongTin);
            this.Name = "ucCauHinh";
            this.Size = new System.Drawing.Size(1200, 660);
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

        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label lblGiaTri;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel pnlChuThich;
        private System.Windows.Forms.Panel pnlMauThe;
        private System.Windows.Forms.Label lblChuThichThe;
        private System.Windows.Forms.Panel pnlMauMuon;
        private System.Windows.Forms.Label lblChuThichMuon;
        private System.Windows.Forms.Panel pnlMauPhat;
        private System.Windows.Forms.Label lblChuThichPhat;
        private System.Windows.Forms.DataGridView dgv;
    }
}
