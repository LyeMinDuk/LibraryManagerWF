namespace LibraryManagerWF.GUI
{
    partial class frmDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlNen = new System.Windows.Forms.Panel();
            this.pnlFormDangNhap = new System.Windows.Forms.Panel();
            this.tlpKhung = new System.Windows.Forms.TableLayoutPanel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlThan = new System.Windows.Forms.Panel();
            this.tlpNoiDung = new System.Windows.Forms.TableLayoutPanel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.tlpO = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.pnlNen.SuspendLayout();
            this.pnlFormDangNhap.SuspendLayout();
            this.tlpKhung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlThan.SuspendLayout();
            this.tlpNoiDung.SuspendLayout();
            this.tlpO.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNen
            // 
            this.pnlNen.BackgroundImage = global::LibraryManagerWF.Properties.Resources.bg_login;
            this.pnlNen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlNen.Controls.Add(this.pnlFormDangNhap);
            this.pnlNen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNen.Location = new System.Drawing.Point(0, 0);
            this.pnlNen.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNen.Name = "pnlNen";
            this.pnlNen.Size = new System.Drawing.Size(1685, 838);
            this.pnlNen.TabIndex = 0;
            // 
            // pnlFormDangNhap
            // 
            this.pnlFormDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlFormDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormDangNhap.Controls.Add(this.tlpKhung);
            this.pnlFormDangNhap.Location = new System.Drawing.Point(576, 204);
            this.pnlFormDangNhap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFormDangNhap.Name = "pnlFormDangNhap";
            this.pnlFormDangNhap.Size = new System.Drawing.Size(533, 431);
            this.pnlFormDangNhap.TabIndex = 0;
            // 
            // tlpKhung
            // 
            this.tlpKhung.ColumnCount = 1;
            this.tlpKhung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKhung.Controls.Add(this.pbLogo, 0, 0);
            this.tlpKhung.Controls.Add(this.pnlThan, 0, 1);
            this.tlpKhung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKhung.Location = new System.Drawing.Point(0, 0);
            this.tlpKhung.Margin = new System.Windows.Forms.Padding(0);
            this.tlpKhung.Name = "tlpKhung";
            this.tlpKhung.RowCount = 2;
            this.tlpKhung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKhung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpKhung.Size = new System.Drawing.Size(533, 431);
            this.tlpKhung.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImage = global::LibraryManagerWF.Properties.Resources.logo_utc;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Location = new System.Drawing.Point(11, 10);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(511, 87);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlThan
            // 
            this.pnlThan.BackgroundImage = global::LibraryManagerWF.Properties.Resources.login_frm_bg;
            this.pnlThan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlThan.Controls.Add(this.tlpNoiDung);
            this.pnlThan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThan.Location = new System.Drawing.Point(0, 107);
            this.pnlThan.Margin = new System.Windows.Forms.Padding(0);
            this.pnlThan.Name = "pnlThan";
            this.pnlThan.Size = new System.Drawing.Size(533, 324);
            this.pnlThan.TabIndex = 1;
            // 
            // tlpNoiDung
            // 
            this.tlpNoiDung.BackColor = System.Drawing.Color.Transparent;
            this.tlpNoiDung.ColumnCount = 1;
            this.tlpNoiDung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoiDung.Controls.Add(this.lblTieuDe, 0, 0);
            this.tlpNoiDung.Controls.Add(this.tlpO, 0, 1);
            this.tlpNoiDung.Controls.Add(this.btnXacNhan, 0, 2);
            this.tlpNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNoiDung.Location = new System.Drawing.Point(0, 0);
            this.tlpNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.tlpNoiDung.Name = "tlpNoiDung";
            this.tlpNoiDung.RowCount = 3;
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.49289F));
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.50711F));
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpNoiDung.Size = new System.Drawing.Size(533, 324);
            this.tlpNoiDung.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Consolas", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(4, 0);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(525, 87);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "ĐĂNG NHẬP";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpO
            // 
            this.tlpO.BackColor = System.Drawing.Color.Transparent;
            this.tlpO.ColumnCount = 2;
            this.tlpO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpO.Controls.Add(this.lblTenDangNhap, 0, 0);
            this.tlpO.Controls.Add(this.txtTenDangNhap, 1, 0);
            this.tlpO.Controls.Add(this.lblMatKhau, 0, 1);
            this.tlpO.Controls.Add(this.txtMatKhau, 1, 1);
            this.tlpO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpO.Location = new System.Drawing.Point(4, 91);
            this.tlpO.Margin = new System.Windows.Forms.Padding(4);
            this.tlpO.Name = "tlpO";
            this.tlpO.RowCount = 2;
            this.tlpO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpO.Size = new System.Drawing.Size(525, 143);
            this.tlpO.TabIndex = 1;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDangNhap.Location = new System.Drawing.Point(4, 23);
            this.lblTenDangNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(151, 25);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.Location = new System.Drawing.Point(239, 20);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenDangNhap.MaxLength = 50;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(283, 30);
            this.txtTenDangNhap.TabIndex = 1;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.Location = new System.Drawing.Point(4, 94);
            this.lblMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(99, 25);
            this.lblMatKhau.TabIndex = 2;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(239, 92);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhau.MaxLength = 50;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(283, 30);
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(5, 243);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(5);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(523, 76);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // frmDangNhap
            // 
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.pnlNen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý thư viện";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.pnlNen.ResumeLayout(false);
            this.pnlFormDangNhap.ResumeLayout(false);
            this.tlpKhung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlThan.ResumeLayout(false);
            this.tlpNoiDung.ResumeLayout(false);
            this.tlpO.ResumeLayout(false);
            this.tlpO.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNen;
        private System.Windows.Forms.Panel pnlFormDangNhap;
        private System.Windows.Forms.TableLayoutPanel tlpKhung;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlThan;
        private System.Windows.Forms.TableLayoutPanel tlpNoiDung;
        private System.Windows.Forms.TableLayoutPanel tlpO;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnXacNhan;
    }
}
