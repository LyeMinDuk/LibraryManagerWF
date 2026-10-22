namespace LibraryManagerWF.GUI
{
    partial class frmDoiMatKhau
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bang = new System.Windows.Forms.TableLayoutPanel();
            this.lblCu = new System.Windows.Forms.Label();
            this.txtCu = new System.Windows.Forms.TextBox();
            this.lblMoi = new System.Windows.Forms.Label();
            this.txtMoi = new System.Windows.Forms.TextBox();
            this.lblNhapLai = new System.Windows.Forms.Label();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.flpNut = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.bang.SuspendLayout();
            this.flpNut.SuspendLayout();
            this.SuspendLayout();
            // 
            // bang
            // 
            this.bang.ColumnCount = 2;
            this.bang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.bang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bang.Controls.Add(this.lblCu, 0, 0);
            this.bang.Controls.Add(this.txtCu, 1, 0);
            this.bang.Controls.Add(this.lblMoi, 0, 1);
            this.bang.Controls.Add(this.txtMoi, 1, 1);
            this.bang.Controls.Add(this.lblNhapLai, 0, 2);
            this.bang.Controls.Add(this.txtNhapLai, 1, 2);
            this.bang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bang.Location = new System.Drawing.Point(0, 0);
            this.bang.Name = "bang";
            this.bang.Padding = new System.Windows.Forms.Padding(16, 16, 16, 0);
            this.bang.RowCount = 3;
            this.bang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.bang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.bang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.bang.Size = new System.Drawing.Size(540, 200);
            this.bang.TabIndex = 0;
            // 
            // lblCu
            // 
            this.lblCu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCu.AutoSize = true;
            this.lblCu.Location = new System.Drawing.Point(19, 27);
            this.lblCu.Name = "lblCu";
            this.lblCu.Size = new System.Drawing.Size(166, 25);
            this.lblCu.TabIndex = 0;
            this.lblCu.Text = "Mật khẩu hiện tại:";
            this.lblCu.UseMnemonic = false;
            // 
            // txtCu
            // 
            this.txtCu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCu.Location = new System.Drawing.Point(250, 25);
            this.txtCu.Margin = new System.Windows.Forms.Padding(4);
            this.txtCu.MaxLength = 50;
            this.txtCu.Name = "txtCu";
            this.txtCu.Size = new System.Drawing.Size(270, 30);
            this.txtCu.TabIndex = 1;
            this.txtCu.UseSystemPasswordChar = true;
            // 
            // lblMoi
            // 
            this.lblMoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMoi.AutoSize = true;
            this.lblMoi.Location = new System.Drawing.Point(19, 75);
            this.lblMoi.Name = "lblMoi";
            this.lblMoi.Size = new System.Drawing.Size(135, 25);
            this.lblMoi.TabIndex = 2;
            this.lblMoi.Text = "Mật khẩu mới:";
            this.lblMoi.UseMnemonic = false;
            // 
            // txtMoi
            // 
            this.txtMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoi.Location = new System.Drawing.Point(250, 73);
            this.txtMoi.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoi.MaxLength = 50;
            this.txtMoi.Name = "txtMoi";
            this.txtMoi.Size = new System.Drawing.Size(270, 30);
            this.txtMoi.TabIndex = 3;
            this.txtMoi.UseSystemPasswordChar = true;
            // 
            // lblNhapLai
            // 
            this.lblNhapLai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNhapLai.AutoSize = true;
            this.lblNhapLai.Location = new System.Drawing.Point(19, 143);
            this.lblNhapLai.Name = "lblNhapLai";
            this.lblNhapLai.Size = new System.Drawing.Size(210, 25);
            this.lblNhapLai.TabIndex = 4;
            this.lblNhapLai.Text = "Nhập lại mật khẩu mới:";
            this.lblNhapLai.UseMnemonic = false;
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNhapLai.Location = new System.Drawing.Point(250, 141);
            this.txtNhapLai.Margin = new System.Windows.Forms.Padding(4);
            this.txtNhapLai.MaxLength = 50;
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.Size = new System.Drawing.Size(270, 30);
            this.txtNhapLai.TabIndex = 5;
            this.txtNhapLai.UseSystemPasswordChar = true;
            // 
            // flpNut
            // 
            this.flpNut.Controls.Add(this.btnHuy);
            this.flpNut.Controls.Add(this.btnLuu);
            this.flpNut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpNut.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpNut.Location = new System.Drawing.Point(0, 200);
            this.flpNut.Name = "flpNut";
            this.flpNut.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.flpNut.Size = new System.Drawing.Size(540, 60);
            this.flpNut.TabIndex = 1;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(403, 11);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 40);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(287, 11);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 40);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmDoiMatKhau
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(540, 260);
            this.Controls.Add(this.bang);
            this.Controls.Add(this.flpNut);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiMatKhau";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDoiMatKhau";
            this.bang.ResumeLayout(false);
            this.bang.PerformLayout();
            this.flpNut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel bang;
        private System.Windows.Forms.Label lblCu;
        private System.Windows.Forms.TextBox txtCu;
        private System.Windows.Forms.Label lblMoi;
        private System.Windows.Forms.TextBox txtMoi;
        private System.Windows.Forms.Label lblNhapLai;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.FlowLayoutPanel flpNut;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}
