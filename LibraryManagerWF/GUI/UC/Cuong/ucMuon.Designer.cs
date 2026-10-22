namespace LibraryManagerWF.GUI.UC.Cuong
{
    partial class ucMuon
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.gbDocGia = new System.Windows.Forms.GroupBox();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.lblThongTinThe = new System.Windows.Forms.Label();
            this.flpTimDG = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTuKhoaDG = new System.Windows.Forms.Label();
            this.txtTimDG = new System.Windows.Forms.TextBox();
            this.btnTimDG = new System.Windows.Forms.Button();
            this.tlpChinh = new System.Windows.Forms.TableLayoutPanel();
            this.gbSach = new System.Windows.Forms.GroupBox();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.flpThemSach = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.flpTimSach = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTuKhoaSach = new System.Windows.Forms.Label();
            this.txtTimSach = new System.Windows.Forms.TextBox();
            this.btnTimSach = new System.Windows.Forms.Button();
            this.gbPhieu = new System.Windows.Forms.GroupBox();
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.lblTongKet = new System.Windows.Forms.Label();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBoSach = new System.Windows.Forms.Button();
            this.btnBoHet = new System.Windows.Forms.Button();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.gbDocGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.flpTimDG.SuspendLayout();
            this.tlpChinh.SuspendLayout();
            this.gbSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.flpThemSach.SuspendLayout();
            this.flpTimSach.SuspendLayout();
            this.gbPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.flpThaoTac.SuspendLayout();
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
            this.lblTieuDe.Text = "LẬP PHIẾU MƯỢN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.UseMnemonic = false;
            // 
            // gbDocGia
            // 
            this.gbDocGia.Controls.Add(this.dgvDocGia);
            this.gbDocGia.Controls.Add(this.lblThongTinThe);
            this.gbDocGia.Controls.Add(this.flpTimDG);
            this.gbDocGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDocGia.Location = new System.Drawing.Point(0, 36);
            this.gbDocGia.Name = "gbDocGia";
            this.gbDocGia.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbDocGia.Size = new System.Drawing.Size(1200, 235);
            this.gbDocGia.TabIndex = 1;
            this.gbDocGia.TabStop = false;
            this.gbDocGia.Text = "1. Chọn độc giả (cần có thẻ còn hiệu lực)";
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocGia.Location = new System.Drawing.Point(10, 74);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.RowHeadersWidth = 51;
            this.dgvDocGia.Size = new System.Drawing.Size(1180, 121);
            this.dgvDocGia.TabIndex = 2;
            this.dgvDocGia.SelectionChanged += new System.EventHandler(this.dgvDocGia_SelectionChanged);
            // 
            // lblThongTinThe
            // 
            this.lblThongTinThe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThongTinThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinThe.Location = new System.Drawing.Point(10, 195);
            this.lblThongTinThe.Name = "lblThongTinThe";
            this.lblThongTinThe.Size = new System.Drawing.Size(1180, 32);
            this.lblThongTinThe.TabIndex = 1;
            this.lblThongTinThe.Text = "Chọn một độc giả để lập phiếu mượn.";
            this.lblThongTinThe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblThongTinThe.UseMnemonic = false;
            // 
            // flpTimDG
            // 
            this.flpTimDG.Controls.Add(this.lblTuKhoaDG);
            this.flpTimDG.Controls.Add(this.txtTimDG);
            this.flpTimDG.Controls.Add(this.btnTimDG);
            this.flpTimDG.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTimDG.Location = new System.Drawing.Point(10, 28);
            this.flpTimDG.Name = "flpTimDG";
            this.flpTimDG.Size = new System.Drawing.Size(1180, 46);
            this.flpTimDG.TabIndex = 0;
            // 
            // lblTuKhoaDG
            // 
            this.lblTuKhoaDG.AutoSize = true;
            this.lblTuKhoaDG.Location = new System.Drawing.Point(10, 12);
            this.lblTuKhoaDG.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblTuKhoaDG.Name = "lblTuKhoaDG";
            this.lblTuKhoaDG.Size = new System.Drawing.Size(90, 25);
            this.lblTuKhoaDG.TabIndex = 0;
            this.lblTuKhoaDG.Text = "Từ khóa:";
            // 
            // txtTimDG
            // 
            this.txtTimDG.Location = new System.Drawing.Point(108, 8);
            this.txtTimDG.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.txtTimDG.Name = "txtTimDG";
            this.txtTimDG.Size = new System.Drawing.Size(300, 30);
            this.txtTimDG.TabIndex = 1;
            this.txtTimDG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimDG_KeyDown);
            // 
            // btnTimDG
            // 
            this.btnTimDG.Location = new System.Drawing.Point(416, 4);
            this.btnTimDG.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimDG.Name = "btnTimDG";
            this.btnTimDG.Size = new System.Drawing.Size(120, 38);
            this.btnTimDG.TabIndex = 2;
            this.btnTimDG.Text = "Tìm kiếm";
            this.btnTimDG.UseVisualStyleBackColor = true;
            this.btnTimDG.Click += new System.EventHandler(this.btnTimDG_Click);
            // 
            // tlpChinh
            // 
            this.tlpChinh.ColumnCount = 2;
            this.tlpChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChinh.Controls.Add(this.gbSach, 0, 0);
            this.tlpChinh.Controls.Add(this.gbPhieu, 1, 0);
            this.tlpChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChinh.Location = new System.Drawing.Point(0, 271);
            this.tlpChinh.Name = "tlpChinh";
            this.tlpChinh.RowCount = 1;
            this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChinh.Size = new System.Drawing.Size(1200, 389);
            this.tlpChinh.TabIndex = 2;
            // 
            // gbSach
            // 
            this.gbSach.Controls.Add(this.dgvSach);
            this.gbSach.Controls.Add(this.flpThemSach);
            this.gbSach.Controls.Add(this.flpTimSach);
            this.gbSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSach.Location = new System.Drawing.Point(3, 3);
            this.gbSach.Name = "gbSach";
            this.gbSach.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbSach.Size = new System.Drawing.Size(594, 383);
            this.gbSach.TabIndex = 0;
            this.gbSach.TabStop = false;
            this.gbSach.Text = "2. Chọn sách (chỉ hiện sách còn trong kho)";
            // 
            // dgvSach
            // 
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(10, 74);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.Size = new System.Drawing.Size(574, 243);
            this.dgvSach.TabIndex = 2;
            this.dgvSach.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellDoubleClick);
            // 
            // flpThemSach
            // 
            this.flpThemSach.Controls.Add(this.btnThemSach);
            this.flpThemSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpThemSach.Location = new System.Drawing.Point(10, 317);
            this.flpThemSach.Name = "flpThemSach";
            this.flpThemSach.Size = new System.Drawing.Size(574, 58);
            this.flpThemSach.TabIndex = 1;
            // 
            // btnThemSach
            // 
            this.btnThemSach.Location = new System.Drawing.Point(4, 4);
            this.btnThemSach.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(220, 42);
            this.btnThemSach.TabIndex = 0;
            this.btnThemSach.Text = "Thêm vào phiếu >>";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // flpTimSach
            // 
            this.flpTimSach.Controls.Add(this.lblTuKhoaSach);
            this.flpTimSach.Controls.Add(this.txtTimSach);
            this.flpTimSach.Controls.Add(this.btnTimSach);
            this.flpTimSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTimSach.Location = new System.Drawing.Point(10, 28);
            this.flpTimSach.Name = "flpTimSach";
            this.flpTimSach.Size = new System.Drawing.Size(574, 46);
            this.flpTimSach.TabIndex = 0;
            // 
            // lblTuKhoaSach
            // 
            this.lblTuKhoaSach.AutoSize = true;
            this.lblTuKhoaSach.Location = new System.Drawing.Point(10, 12);
            this.lblTuKhoaSach.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblTuKhoaSach.Name = "lblTuKhoaSach";
            this.lblTuKhoaSach.Size = new System.Drawing.Size(90, 25);
            this.lblTuKhoaSach.TabIndex = 0;
            this.lblTuKhoaSach.Text = "Từ khóa:";
            // 
            // txtTimSach
            // 
            this.txtTimSach.Location = new System.Drawing.Point(108, 8);
            this.txtTimSach.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.txtTimSach.Name = "txtTimSach";
            this.txtTimSach.Size = new System.Drawing.Size(230, 30);
            this.txtTimSach.TabIndex = 1;
            this.txtTimSach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimSach_KeyDown);
            // 
            // btnTimSach
            // 
            this.btnTimSach.Location = new System.Drawing.Point(346, 4);
            this.btnTimSach.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimSach.Name = "btnTimSach";
            this.btnTimSach.Size = new System.Drawing.Size(120, 38);
            this.btnTimSach.TabIndex = 2;
            this.btnTimSach.Text = "Tìm kiếm";
            this.btnTimSach.UseVisualStyleBackColor = true;
            this.btnTimSach.Click += new System.EventHandler(this.btnTimSach_Click);
            // 
            // gbPhieu
            // 
            this.gbPhieu.Controls.Add(this.dgvPhieu);
            this.gbPhieu.Controls.Add(this.lblTongKet);
            this.gbPhieu.Controls.Add(this.flpThaoTac);
            this.gbPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPhieu.Location = new System.Drawing.Point(603, 3);
            this.gbPhieu.Name = "gbPhieu";
            this.gbPhieu.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbPhieu.Size = new System.Drawing.Size(594, 383);
            this.gbPhieu.TabIndex = 1;
            this.gbPhieu.TabStop = false;
            this.gbPhieu.Text = "3. Phiếu mượn";
            // 
            // dgvPhieu
            // 
            this.dgvPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieu.Location = new System.Drawing.Point(10, 28);
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.RowHeadersWidth = 51;
            this.dgvPhieu.Size = new System.Drawing.Size(574, 237);
            this.dgvPhieu.TabIndex = 2;
            this.dgvPhieu.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieu_CellDoubleClick);
            // 
            // lblTongKet
            // 
            this.lblTongKet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTongKet.Location = new System.Drawing.Point(10, 265);
            this.lblTongKet.Name = "lblTongKet";
            this.lblTongKet.Size = new System.Drawing.Size(574, 60);
            this.lblTongKet.TabIndex = 1;
            this.lblTongKet.Text = "Phiếu chưa có cuốn nào.";
            this.lblTongKet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTongKet.UseMnemonic = false;
            // 
            // flpThaoTac
            // 
            this.flpThaoTac.Controls.Add(this.btnBoSach);
            this.flpThaoTac.Controls.Add(this.btnBoHet);
            this.flpThaoTac.Controls.Add(this.btnLapPhieu);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpThaoTac.Location = new System.Drawing.Point(10, 325);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.Size = new System.Drawing.Size(574, 50);
            this.flpThaoTac.TabIndex = 0;
            // 
            // btnBoSach
            // 
            this.btnBoSach.Location = new System.Drawing.Point(4, 4);
            this.btnBoSach.Margin = new System.Windows.Forms.Padding(4);
            this.btnBoSach.Name = "btnBoSach";
            this.btnBoSach.Size = new System.Drawing.Size(110, 42);
            this.btnBoSach.TabIndex = 0;
            this.btnBoSach.Text = "Bỏ cuốn";
            this.btnBoSach.UseVisualStyleBackColor = true;
            this.btnBoSach.Click += new System.EventHandler(this.btnBoSach_Click);
            // 
            // btnBoHet
            // 
            this.btnBoHet.Location = new System.Drawing.Point(122, 4);
            this.btnBoHet.Margin = new System.Windows.Forms.Padding(4);
            this.btnBoHet.Name = "btnBoHet";
            this.btnBoHet.Size = new System.Drawing.Size(110, 42);
            this.btnBoHet.TabIndex = 1;
            this.btnBoHet.Text = "Bỏ hết";
            this.btnBoHet.UseVisualStyleBackColor = true;
            this.btnBoHet.Click += new System.EventHandler(this.btnBoHet_Click);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(240, 4);
            this.btnLapPhieu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(200, 42);
            this.btnLapPhieu.TabIndex = 2;
            this.btnLapPhieu.Text = "Lập phiếu mượn";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // ucMuon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpChinh);
            this.Controls.Add(this.gbDocGia);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucMuon";
            this.Size = new System.Drawing.Size(1200, 660);
            this.gbDocGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.flpTimDG.ResumeLayout(false);
            this.flpTimDG.PerformLayout();
            this.tlpChinh.ResumeLayout(false);
            this.gbSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.flpThemSach.ResumeLayout(false);
            this.flpTimSach.ResumeLayout(false);
            this.flpTimSach.PerformLayout();
            this.gbPhieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            this.flpThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox gbDocGia;
        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.Label lblThongTinThe;
        private System.Windows.Forms.FlowLayoutPanel flpTimDG;
        private System.Windows.Forms.Label lblTuKhoaDG;
        private System.Windows.Forms.TextBox txtTimDG;
        private System.Windows.Forms.Button btnTimDG;
        private System.Windows.Forms.TableLayoutPanel tlpChinh;
        private System.Windows.Forms.GroupBox gbSach;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.FlowLayoutPanel flpThemSach;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.FlowLayoutPanel flpTimSach;
        private System.Windows.Forms.Label lblTuKhoaSach;
        private System.Windows.Forms.TextBox txtTimSach;
        private System.Windows.Forms.Button btnTimSach;
        private System.Windows.Forms.GroupBox gbPhieu;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.Label lblTongKet;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnBoSach;
        private System.Windows.Forms.Button btnBoHet;
        private System.Windows.Forms.Button btnLapPhieu;
    }
}
