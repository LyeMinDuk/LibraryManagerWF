namespace LibraryManagerWF.GUI.UC.Duc
{
    partial class ucTaiKhoan
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
            this.lblTenDN = new System.Windows.Forms.Label();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblCot2 = new System.Windows.Forms.Label();
            this.pnlCot2 = new System.Windows.Forms.Panel();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnDatLai = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDoiMkToi = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gbTimKiem.SuspendLayout();
            this.flpTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            this.pnlCot2.SuspendLayout();
            this.gbThaoTac.SuspendLayout();
            this.flpThaoTac.SuspendLayout();
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
            this.gbTimKiem.Size = new System.Drawing.Size(1000, 78);
            this.gbTimKiem.TabIndex = 0;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm (tên đăng nhập hoặc họ tên)";
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
            this.flpTimKiem.Size = new System.Drawing.Size(980, 42);
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
            this.gbThongTin.Size = new System.Drawing.Size(1000, 170);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin tài khoản";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Controls.Add(this.lblTenDN, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtTenDN, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblHoTen, 2, 0);
            this.tlpThongTin.Controls.Add(this.txtHoTen, 3, 0);
            this.tlpThongTin.Controls.Add(this.lblVaiTro, 0, 1);
            this.tlpThongTin.Controls.Add(this.cboVaiTro, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblCot2, 2, 1);
            this.tlpThongTin.Controls.Add(this.pnlCot2, 3, 1);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Location = new System.Drawing.Point(10, 60);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 2;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.Size = new System.Drawing.Size(980, 102);
            this.tlpThongTin.TabIndex = 1;
            // 
            // lblTenDN
            // 
            this.lblTenDN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.Location = new System.Drawing.Point(3, 0);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(101, 44);
            this.lblTenDN.TabIndex = 0;
            this.lblTenDN.Text = "Tên đăng nhập:";
            this.lblTenDN.UseMnemonic = false;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenDN.Location = new System.Drawing.Point(144, 7);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDN.MaxLength = 50;
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(342, 30);
            this.txtTenDN.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(493, 9);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(75, 25);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên:";
            this.lblHoTen.UseMnemonic = false;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoTen.Location = new System.Drawing.Point(634, 7);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(342, 30);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(3, 60);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(74, 25);
            this.lblVaiTro.TabIndex = 0;
            this.lblVaiTro.Text = "Vai trò:";
            this.lblVaiTro.UseMnemonic = false;
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(144, 61);
            this.cboVaiTro.Margin = new System.Windows.Forms.Padding(4);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(342, 33);
            this.cboVaiTro.TabIndex = 5;
            // 
            // lblCot2
            // 
            this.lblCot2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCot2.AutoSize = true;
            this.lblCot2.Location = new System.Drawing.Point(493, 60);
            this.lblCot2.Name = "lblCot2";
            this.lblCot2.Size = new System.Drawing.Size(106, 25);
            this.lblCot2.TabIndex = 0;
            this.lblCot2.Text = "Trạng thái:";
            this.lblCot2.UseMnemonic = false;
            // 
            // pnlCot2
            // 
            this.pnlCot2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCot2.Controls.Add(this.txtTrangThai);
            this.pnlCot2.Controls.Add(this.txtMatKhau);
            this.pnlCot2.Location = new System.Drawing.Point(634, 55);
            this.pnlCot2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCot2.Name = "pnlCot2";
            this.pnlCot2.Size = new System.Drawing.Size(342, 36);
            this.pnlCot2.TabIndex = 7;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrangThai.Location = new System.Drawing.Point(0, 0);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(342, 30);
            this.txtTrangThai.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Location = new System.Drawing.Point(0, 0);
            this.txtMatKhau.MaxLength = 50;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(342, 30);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.Visible = false;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Location = new System.Drawing.Point(10, 28);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(980, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÔNG TIN TÀI KHOẢN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.UseMnemonic = false;
            // 
            // gbThaoTac
            // 
            this.gbThaoTac.Controls.Add(this.flpThaoTac);
            this.gbThaoTac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbThaoTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThaoTac.Location = new System.Drawing.Point(0, 513);
            this.gbThaoTac.Name = "gbThaoTac";
            this.gbThaoTac.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbThaoTac.Size = new System.Drawing.Size(1000, 87);
            this.gbThaoTac.TabIndex = 3;
            this.gbThaoTac.TabStop = false;
            this.gbThaoTac.Text = "Thao tác";
            // 
            // flpThaoTac
            // 
            this.flpThaoTac.Controls.Add(this.btnThem);
            this.flpThaoTac.Controls.Add(this.btnSua);
            this.flpThaoTac.Controls.Add(this.btnDatLai);
            this.flpThaoTac.Controls.Add(this.btnKhoa);
            this.flpThaoTac.Controls.Add(this.btnXoa);
            this.flpThaoTac.Controls.Add(this.btnDoiMkToi);
            this.flpThaoTac.Controls.Add(this.btnXacNhan);
            this.flpThaoTac.Controls.Add(this.btnHuy);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThaoTac.Location = new System.Drawing.Point(10, 28);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.Size = new System.Drawing.Size(980, 51);
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
            // btnDatLai
            // 
            this.btnDatLai.Location = new System.Drawing.Point(240, 4);
            this.btnDatLai.Margin = new System.Windows.Forms.Padding(4);
            this.btnDatLai.Name = "btnDatLai";
            this.btnDatLai.Size = new System.Drawing.Size(170, 42);
            this.btnDatLai.TabIndex = 2;
            this.btnDatLai.Text = "Đặt lại mật khẩu";
            this.btnDatLai.UseVisualStyleBackColor = true;
            // 
            // btnKhoa
            // 
            this.btnKhoa.Location = new System.Drawing.Point(418, 4);
            this.btnKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(110, 42);
            this.btnKhoa.TabIndex = 3;
            this.btnKhoa.Text = "Khóa";
            this.btnKhoa.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(536, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 42);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnDoiMkToi
            // 
            this.btnDoiMkToi.Location = new System.Drawing.Point(654, 4);
            this.btnDoiMkToi.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoiMkToi.Name = "btnDoiMkToi";
            this.btnDoiMkToi.Size = new System.Drawing.Size(200, 42);
            this.btnDoiMkToi.TabIndex = 5;
            this.btnDoiMkToi.Text = "Đổi mật khẩu của tôi";
            this.btnDoiMkToi.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(4, 54);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 42);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(132, 54);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 42);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 248);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(1000, 265);
            this.dgv.TabIndex = 2;
            // 
            // ucTaiKhoan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.gbThaoTac);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "ucTaiKhoan";
            this.Size = new System.Drawing.Size(1000, 600);
            this.gbTimKiem.ResumeLayout(false);
            this.flpTimKiem.ResumeLayout(false);
            this.flpTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.tlpThongTin.ResumeLayout(false);
            this.tlpThongTin.PerformLayout();
            this.pnlCot2.ResumeLayout(false);
            this.pnlCot2.PerformLayout();
            this.gbThaoTac.ResumeLayout(false);
            this.flpThaoTac.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblTenDN;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblCot2;
        private System.Windows.Forms.Panel pnlCot2;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnDatLai;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDoiMkToi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgv;
    }
}
