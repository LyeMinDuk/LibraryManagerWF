namespace LibraryManagerWF.GUI.UC.Cuong
{
    partial class ucThe
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
            this.lblLoc = new System.Windows.Forms.Label();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblMaDG = new System.Windows.Forms.Label();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.lblNgayCap = new System.Windows.Forms.Label();
            this.txtNgayCap = new System.Windows.Forms.TextBox();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            this.txtNgayHetHan = new System.Windows.Forms.TextBox();
            this.lblPhiThe = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCapThe = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnKhoaThe = new System.Windows.Forms.Button();
            this.btnXoaThe = new System.Windows.Forms.Button();
            this.pnlChuThich = new System.Windows.Forms.Panel();
            this.pnlMauChuaThe = new System.Windows.Forms.Panel();
            this.lblChuThichChuaThe = new System.Windows.Forms.Label();
            this.pnlMauHetHan = new System.Windows.Forms.Panel();
            this.lblChuThichHetHan = new System.Windows.Forms.Label();
            this.pnlMauKhoa = new System.Windows.Forms.Panel();
            this.lblChuThichKhoa = new System.Windows.Forms.Label();
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
            this.gbTimKiem.Text = "Tìm kiếm (họ tên hoặc số điện thoại)";
            // 
            // flpTimKiem
            // 
            this.flpTimKiem.Controls.Add(this.lblTuKhoa);
            this.flpTimKiem.Controls.Add(this.txtTimKiem);
            this.flpTimKiem.Controls.Add(this.btnTimKiem);
            this.flpTimKiem.Controls.Add(this.btnLamMoi);
            this.flpTimKiem.Controls.Add(this.lblLoc);
            this.flpTimKiem.Controls.Add(this.cboLoc);
            this.flpTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTimKiem.Location = new System.Drawing.Point(10, 28);
            this.flpTimKiem.Name = "flpTimKiem";
            this.flpTimKiem.Size = new System.Drawing.Size(1180, 42);
            this.flpTimKiem.TabIndex = 0;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
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
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
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
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
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
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(692, 12);
            this.lblLoc.Margin = new System.Windows.Forms.Padding(24, 12, 4, 0);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(83, 25);
            this.lblLoc.TabIndex = 4;
            this.lblLoc.Text = "Hiển thị:";
            // 
            // cboLoc
            // 
            this.cboLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoc.FormattingEnabled = true;
            this.cboLoc.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa có thẻ",
            "Hoạt động",
            "Hết hạn",
            "Khóa"});
            this.cboLoc.Location = new System.Drawing.Point(783, 8);
            this.cboLoc.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(200, 33);
            this.cboLoc.TabIndex = 5;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
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
            this.gbThongTin.Size = new System.Drawing.Size(1200, 234);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin thẻ thư viện";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Controls.Add(this.lblHoTen, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtHoTen, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblMaDG, 2, 0);
            this.tlpThongTin.Controls.Add(this.txtMaDG, 3, 0);
            this.tlpThongTin.Controls.Add(this.lblMaThe, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtMaThe, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblTinhTrang, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtTinhTrang, 3, 1);
            this.tlpThongTin.Controls.Add(this.lblNgayCap, 0, 2);
            this.tlpThongTin.Controls.Add(this.txtNgayCap, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblNgayHetHan, 2, 2);
            this.tlpThongTin.Controls.Add(this.txtNgayHetHan, 3, 2);
            this.tlpThongTin.Controls.Add(this.lblPhiThe, 0, 3);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Location = new System.Drawing.Point(10, 60);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 4;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpThongTin.Size = new System.Drawing.Size(1180, 166);
            this.tlpThongTin.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(3, 8);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(84, 25);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Độc giả:";
            this.lblHoTen.UseMnemonic = false;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoTen.Location = new System.Drawing.Point(164, 6);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(422, 30);
            this.txtHoTen.TabIndex = 1;
            // 
            // lblMaDG
            // 
            this.lblMaDG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaDG.AutoSize = true;
            this.lblMaDG.Location = new System.Drawing.Point(593, 8);
            this.lblMaDG.Name = "lblMaDG";
            this.lblMaDG.Size = new System.Drawing.Size(114, 25);
            this.lblMaDG.TabIndex = 2;
            this.lblMaDG.Text = "Mã độc giả:";
            this.lblMaDG.UseMnemonic = false;
            // 
            // txtMaDG
            // 
            this.txtMaDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaDG.Location = new System.Drawing.Point(754, 6);
            this.txtMaDG.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.ReadOnly = true;
            this.txtMaDG.Size = new System.Drawing.Size(422, 30);
            this.txtMaDG.TabIndex = 3;
            // 
            // lblMaThe
            // 
            this.lblMaThe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(3, 50);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(78, 25);
            this.lblMaThe.TabIndex = 4;
            this.lblMaThe.Text = "Mã thẻ:";
            this.lblMaThe.UseMnemonic = false;
            // 
            // txtMaThe
            // 
            this.txtMaThe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaThe.Location = new System.Drawing.Point(164, 48);
            this.txtMaThe.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.ReadOnly = true;
            this.txtMaThe.Size = new System.Drawing.Size(422, 30);
            this.txtMaThe.TabIndex = 5;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(593, 50);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(138, 25);
            this.lblTinhTrang.TabIndex = 6;
            this.lblTinhTrang.Text = "Tình trạng thẻ:";
            this.lblTinhTrang.UseMnemonic = false;
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTinhTrang.Location = new System.Drawing.Point(754, 48);
            this.txtTinhTrang.Margin = new System.Windows.Forms.Padding(4);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.ReadOnly = true;
            this.txtTinhTrang.Size = new System.Drawing.Size(422, 30);
            this.txtTinhTrang.TabIndex = 7;
            // 
            // lblNgayCap
            // 
            this.lblNgayCap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgayCap.AutoSize = true;
            this.lblNgayCap.Location = new System.Drawing.Point(3, 92);
            this.lblNgayCap.Name = "lblNgayCap";
            this.lblNgayCap.Size = new System.Drawing.Size(101, 25);
            this.lblNgayCap.TabIndex = 8;
            this.lblNgayCap.Text = "Ngày cấp:";
            this.lblNgayCap.UseMnemonic = false;
            // 
            // txtNgayCap
            // 
            this.txtNgayCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgayCap.Location = new System.Drawing.Point(164, 90);
            this.txtNgayCap.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgayCap.Name = "txtNgayCap";
            this.txtNgayCap.ReadOnly = true;
            this.txtNgayCap.Size = new System.Drawing.Size(422, 30);
            this.txtNgayCap.TabIndex = 9;
            // 
            // lblNgayHetHan
            // 
            this.lblNgayHetHan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.Location = new System.Drawing.Point(593, 92);
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Size = new System.Drawing.Size(134, 25);
            this.lblNgayHetHan.TabIndex = 10;
            this.lblNgayHetHan.Text = "Ngày hết hạn:";
            this.lblNgayHetHan.UseMnemonic = false;
            // 
            // txtNgayHetHan
            // 
            this.txtNgayHetHan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgayHetHan.Location = new System.Drawing.Point(754, 90);
            this.txtNgayHetHan.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgayHetHan.Name = "txtNgayHetHan";
            this.txtNgayHetHan.ReadOnly = true;
            this.txtNgayHetHan.Size = new System.Drawing.Size(422, 30);
            this.txtNgayHetHan.TabIndex = 11;
            // 
            // lblPhiThe
            // 
            this.lblPhiThe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhiThe.AutoSize = true;
            this.tlpThongTin.SetColumnSpan(this.lblPhiThe, 4);
            this.lblPhiThe.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPhiThe.Location = new System.Drawing.Point(3, 133);
            this.lblPhiThe.Name = "lblPhiThe";
            this.lblPhiThe.Size = new System.Drawing.Size(0, 25);
            this.lblPhiThe.TabIndex = 12;
            this.lblPhiThe.UseMnemonic = false;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(10, 28);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1180, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÔNG TIN THẺ THƯ VIỆN";
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
            this.flpThaoTac.Controls.Add(this.btnCapThe);
            this.flpThaoTac.Controls.Add(this.btnGiaHan);
            this.flpThaoTac.Controls.Add(this.btnKhoaThe);
            this.flpThaoTac.Controls.Add(this.btnXoaThe);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThaoTac.Location = new System.Drawing.Point(10, 28);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.Size = new System.Drawing.Size(1180, 51);
            this.flpThaoTac.TabIndex = 0;
            // 
            // btnCapThe
            // 
            this.btnCapThe.Location = new System.Drawing.Point(4, 4);
            this.btnCapThe.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapThe.Name = "btnCapThe";
            this.btnCapThe.Size = new System.Drawing.Size(130, 42);
            this.btnCapThe.TabIndex = 0;
            this.btnCapThe.Text = "Cấp thẻ";
            this.btnCapThe.UseVisualStyleBackColor = true;
            this.btnCapThe.Click += new System.EventHandler(this.btnCapThe_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(142, 4);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(4);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(150, 42);
            this.btnGiaHan.TabIndex = 1;
            this.btnGiaHan.Text = "Gia hạn thẻ";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnKhoaThe
            // 
            this.btnKhoaThe.Location = new System.Drawing.Point(300, 4);
            this.btnKhoaThe.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhoaThe.Name = "btnKhoaThe";
            this.btnKhoaThe.Size = new System.Drawing.Size(150, 42);
            this.btnKhoaThe.TabIndex = 2;
            this.btnKhoaThe.Text = "Khóa thẻ";
            this.btnKhoaThe.UseVisualStyleBackColor = true;
            this.btnKhoaThe.Click += new System.EventHandler(this.btnKhoaThe_Click);
            // 
            // btnXoaThe
            // 
            this.btnXoaThe.Location = new System.Drawing.Point(458, 4);
            this.btnXoaThe.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaThe.Name = "btnXoaThe";
            this.btnXoaThe.Size = new System.Drawing.Size(130, 42);
            this.btnXoaThe.TabIndex = 3;
            this.btnXoaThe.Text = "Xóa thẻ";
            this.btnXoaThe.UseVisualStyleBackColor = true;
            this.btnXoaThe.Click += new System.EventHandler(this.btnXoaThe_Click);
            // 
            // pnlChuThich
            // 
            this.pnlChuThich.Controls.Add(this.pnlMauChuaThe);
            this.pnlChuThich.Controls.Add(this.lblChuThichChuaThe);
            this.pnlChuThich.Controls.Add(this.pnlMauHetHan);
            this.pnlChuThich.Controls.Add(this.lblChuThichHetHan);
            this.pnlChuThich.Controls.Add(this.pnlMauKhoa);
            this.pnlChuThich.Controls.Add(this.lblChuThichKhoa);
            this.pnlChuThich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChuThich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlChuThich.Location = new System.Drawing.Point(0, 533);
            this.pnlChuThich.Name = "pnlChuThich";
            this.pnlChuThich.Size = new System.Drawing.Size(1200, 40);
            this.pnlChuThich.TabIndex = 4;
            // 
            // pnlMauChuaThe
            // 
            this.pnlMauChuaThe.BackColor = System.Drawing.Color.Khaki;
            this.pnlMauChuaThe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauChuaThe.Location = new System.Drawing.Point(12, 10);
            this.pnlMauChuaThe.Name = "pnlMauChuaThe";
            this.pnlMauChuaThe.Size = new System.Drawing.Size(20, 20);
            this.pnlMauChuaThe.TabIndex = 0;
            // 
            // lblChuThichChuaThe
            // 
            this.lblChuThichChuaThe.AutoSize = true;
            this.lblChuThichChuaThe.Location = new System.Drawing.Point(38, 8);
            this.lblChuThichChuaThe.Name = "lblChuThichChuaThe";
            this.lblChuThichChuaThe.Size = new System.Drawing.Size(118, 25);
            this.lblChuThichChuaThe.TabIndex = 1;
            this.lblChuThichChuaThe.Text = "Chưa có thẻ";
            this.lblChuThichChuaThe.UseMnemonic = false;
            // 
            // pnlMauHetHan
            // 
            this.pnlMauHetHan.BackColor = System.Drawing.Color.LightCoral;
            this.pnlMauHetHan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauHetHan.Location = new System.Drawing.Point(200, 10);
            this.pnlMauHetHan.Name = "pnlMauHetHan";
            this.pnlMauHetHan.Size = new System.Drawing.Size(20, 20);
            this.pnlMauHetHan.TabIndex = 2;
            // 
            // lblChuThichHetHan
            // 
            this.lblChuThichHetHan.AutoSize = true;
            this.lblChuThichHetHan.Location = new System.Drawing.Point(226, 8);
            this.lblChuThichHetHan.Name = "lblChuThichHetHan";
            this.lblChuThichHetHan.Size = new System.Drawing.Size(117, 25);
            this.lblChuThichHetHan.TabIndex = 3;
            this.lblChuThichHetHan.Text = "Thẻ hết hạn";
            this.lblChuThichHetHan.UseMnemonic = false;
            // 
            // pnlMauKhoa
            // 
            this.pnlMauKhoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.pnlMauKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauKhoa.Location = new System.Drawing.Point(380, 10);
            this.pnlMauKhoa.Name = "pnlMauKhoa";
            this.pnlMauKhoa.Size = new System.Drawing.Size(20, 20);
            this.pnlMauKhoa.TabIndex = 4;
            // 
            // lblChuThichKhoa
            // 
            this.lblChuThichKhoa.AutoSize = true;
            this.lblChuThichKhoa.Location = new System.Drawing.Point(406, 8);
            this.lblChuThichKhoa.Name = "lblChuThichKhoa";
            this.lblChuThichKhoa.Size = new System.Drawing.Size(299, 25);
            this.lblChuThichKhoa.TabIndex = 5;
            this.lblChuThichKhoa.Text = "Thẻ bị khóa hoặc độc giả bị khóa";
            this.lblChuThichKhoa.UseMnemonic = false;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 312);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(1200, 221);
            this.dgv.TabIndex = 2;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // ucThe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlChuThich);
            this.Controls.Add(this.gbThaoTac);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbTimKiem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucThe";
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
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblMaDG;
        private System.Windows.Forms.TextBox txtMaDG;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label lblNgayCap;
        private System.Windows.Forms.TextBox txtNgayCap;
        private System.Windows.Forms.Label lblNgayHetHan;
        private System.Windows.Forms.TextBox txtNgayHetHan;
        private System.Windows.Forms.Label lblPhiThe;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnCapThe;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnKhoaThe;
        private System.Windows.Forms.Button btnXoaThe;
        private System.Windows.Forms.Panel pnlChuThich;
        private System.Windows.Forms.Panel pnlMauChuaThe;
        private System.Windows.Forms.Label lblChuThichChuaThe;
        private System.Windows.Forms.Panel pnlMauHetHan;
        private System.Windows.Forms.Label lblChuThichHetHan;
        private System.Windows.Forms.Panel pnlMauKhoa;
        private System.Windows.Forms.Label lblChuThichKhoa;
        private System.Windows.Forms.DataGridView dgv;
    }
}
