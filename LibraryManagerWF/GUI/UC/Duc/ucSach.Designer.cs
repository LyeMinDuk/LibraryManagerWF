namespace LibraryManagerWF.GUI.UC.Duc
{
    partial class ucSach
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
            this.lblLocTheLoai = new System.Windows.Forms.Label();
            this.cboLocTheLoai = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.lblNXB = new System.Windows.Forms.Label();
            this.txtNXB = new System.Windows.Forms.TextBox();
            this.lblNamXB = new System.Windows.Forms.Label();
            this.txtNamXB = new System.Windows.Forms.TextBox();
            this.lblGiaBia = new System.Windows.Forms.Label();
            this.nudGiaBia = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongTong = new System.Windows.Forms.Label();
            this.nudSoLuongTong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongCon = new System.Windows.Forms.Label();
            this.txtSoLuongCon = new System.Windows.Forms.TextBox();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gbTimKiem.SuspendLayout();
            this.flpTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaBia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongTong)).BeginInit();
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
            this.gbTimKiem.Size = new System.Drawing.Size(1200, 78);
            this.gbTimKiem.TabIndex = 0;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm / lọc (tên sách, tác giả hoặc nhà xuất bản)";
            // 
            // flpTimKiem
            // 
            this.flpTimKiem.Controls.Add(this.lblTuKhoa);
            this.flpTimKiem.Controls.Add(this.txtTimKiem);
            this.flpTimKiem.Controls.Add(this.lblLocTheLoai);
            this.flpTimKiem.Controls.Add(this.cboLocTheLoai);
            this.flpTimKiem.Controls.Add(this.lblLocTrangThai);
            this.flpTimKiem.Controls.Add(this.cboLocTrangThai);
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
            this.txtTimKiem.Size = new System.Drawing.Size(220, 30);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // lblLocTheLoai
            // 
            this.lblLocTheLoai.AutoSize = true;
            this.lblLocTheLoai.Location = new System.Drawing.Point(342, 12);
            this.lblLocTheLoai.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblLocTheLoai.Name = "lblLocTheLoai";
            this.lblLocTheLoai.Size = new System.Drawing.Size(88, 25);
            this.lblLocTheLoai.TabIndex = 2;
            this.lblLocTheLoai.Text = "Thể loại:";
            // 
            // cboLocTheLoai
            // 
            this.cboLocTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTheLoai.FormattingEnabled = true;
            this.cboLocTheLoai.Location = new System.Drawing.Point(438, 8);
            this.cboLocTheLoai.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.cboLocTheLoai.Name = "cboLocTheLoai";
            this.cboLocTheLoai.Size = new System.Drawing.Size(200, 33);
            this.cboLocTheLoai.TabIndex = 3;
            this.cboLocTheLoai.SelectedIndexChanged += new System.EventHandler(this.cboLocTheLoai_SelectedIndexChanged);
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Location = new System.Drawing.Point(652, 12);
            this.lblLocTrangThai.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(106, 25);
            this.lblLocTrangThai.TabIndex = 4;
            this.lblLocTrangThai.Text = "Trạng thái:";
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Hoạt động",
            "Đã khóa"});
            this.cboLocTrangThai.Location = new System.Drawing.Point(766, 8);
            this.cboLocTrangThai.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(150, 33);
            this.cboLocTrangThai.TabIndex = 5;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(924, 4);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 42);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(1052, 4);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 42);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
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
            this.gbThongTin.Size = new System.Drawing.Size(1200, 252);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin sách";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Controls.Add(this.lblTenSach, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtTenSach, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblTacGia, 2, 0);
            this.tlpThongTin.Controls.Add(this.txtTacGia, 3, 0);
            this.tlpThongTin.Controls.Add(this.lblTheLoai, 0, 1);
            this.tlpThongTin.Controls.Add(this.cboTheLoai, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblNXB, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtNXB, 3, 1);
            this.tlpThongTin.Controls.Add(this.lblNamXB, 0, 2);
            this.tlpThongTin.Controls.Add(this.txtNamXB, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblGiaBia, 2, 2);
            this.tlpThongTin.Controls.Add(this.nudGiaBia, 3, 2);
            this.tlpThongTin.Controls.Add(this.lblSoLuongTong, 0, 3);
            this.tlpThongTin.Controls.Add(this.nudSoLuongTong, 1, 3);
            this.tlpThongTin.Controls.Add(this.lblSoLuongCon, 2, 3);
            this.tlpThongTin.Controls.Add(this.txtSoLuongCon, 3, 3);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Location = new System.Drawing.Point(10, 60);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 4;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpThongTin.Size = new System.Drawing.Size(1180, 184);
            this.tlpThongTin.TabIndex = 1;
            // 
            // lblTenSach
            // 
            this.lblTenSach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(3, 9);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(100, 25);
            this.lblTenSach.TabIndex = 0;
            this.lblTenSach.Text = "Tên sách:";
            this.lblTenSach.UseMnemonic = false;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenSach.Location = new System.Drawing.Point(164, 7);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSach.MaxLength = 200;
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(422, 30);
            this.txtTenSach.TabIndex = 1;
            // 
            // lblTacGia
            // 
            this.lblTacGia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(593, 9);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(83, 25);
            this.lblTacGia.TabIndex = 2;
            this.lblTacGia.Text = "Tác giả:";
            this.lblTacGia.UseMnemonic = false;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTacGia.Location = new System.Drawing.Point(754, 7);
            this.txtTacGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtTacGia.MaxLength = 150;
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(422, 30);
            this.txtTacGia.TabIndex = 3;
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Location = new System.Drawing.Point(3, 53);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(88, 25);
            this.lblTheLoai.TabIndex = 4;
            this.lblTheLoai.Text = "Thể loại:";
            this.lblTheLoai.UseMnemonic = false;
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(164, 54);
            this.cboTheLoai.Margin = new System.Windows.Forms.Padding(4);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(422, 33);
            this.cboTheLoai.TabIndex = 5;
            // 
            // lblNXB
            // 
            this.lblNXB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNXB.AutoSize = true;
            this.lblNXB.Location = new System.Drawing.Point(593, 53);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Size = new System.Drawing.Size(59, 25);
            this.lblNXB.TabIndex = 6;
            this.lblNXB.Text = "NXB:";
            this.lblNXB.UseMnemonic = false;
            // 
            // txtNXB
            // 
            this.txtNXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNXB.Location = new System.Drawing.Point(754, 51);
            this.txtNXB.Margin = new System.Windows.Forms.Padding(4);
            this.txtNXB.MaxLength = 150;
            this.txtNXB.Name = "txtNXB";
            this.txtNXB.Size = new System.Drawing.Size(422, 30);
            this.txtNXB.TabIndex = 7;
            // 
            // lblNamXB
            // 
            this.lblNamXB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNamXB.AutoSize = true;
            this.lblNamXB.Location = new System.Drawing.Point(3, 97);
            this.lblNamXB.Name = "lblNamXB";
            this.lblNamXB.Size = new System.Drawing.Size(91, 25);
            this.lblNamXB.TabIndex = 8;
            this.lblNamXB.Text = "Năm XB:";
            this.lblNamXB.UseMnemonic = false;
            // 
            // txtNamXB
            // 
            this.txtNamXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamXB.Location = new System.Drawing.Point(164, 95);
            this.txtNamXB.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamXB.MaxLength = 4;
            this.txtNamXB.Name = "txtNamXB";
            this.txtNamXB.Size = new System.Drawing.Size(422, 30);
            this.txtNamXB.TabIndex = 9;
            // 
            // lblGiaBia
            // 
            this.lblGiaBia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGiaBia.AutoSize = true;
            this.lblGiaBia.Location = new System.Drawing.Point(593, 97);
            this.lblGiaBia.Name = "lblGiaBia";
            this.lblGiaBia.Size = new System.Drawing.Size(79, 25);
            this.lblGiaBia.TabIndex = 10;
            this.lblGiaBia.Text = "Giá bìa:";
            this.lblGiaBia.UseMnemonic = false;
            // 
            // nudGiaBia
            // 
            this.nudGiaBia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudGiaBia.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaBia.Location = new System.Drawing.Point(754, 95);
            this.nudGiaBia.Margin = new System.Windows.Forms.Padding(4);
            this.nudGiaBia.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudGiaBia.Name = "nudGiaBia";
            this.nudGiaBia.Size = new System.Drawing.Size(422, 30);
            this.nudGiaBia.TabIndex = 11;
            this.nudGiaBia.ThousandsSeparator = true;
            // 
            // lblSoLuongTong
            // 
            this.lblSoLuongTong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSoLuongTong.AutoSize = true;
            this.lblSoLuongTong.Location = new System.Drawing.Point(3, 145);
            this.lblSoLuongTong.Name = "lblSoLuongTong";
            this.lblSoLuongTong.Size = new System.Drawing.Size(139, 25);
            this.lblSoLuongTong.TabIndex = 12;
            this.lblSoLuongTong.Text = "Số lượng tổng:";
            this.lblSoLuongTong.UseMnemonic = false;
            // 
            // nudSoLuongTong
            // 
            this.nudSoLuongTong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSoLuongTong.Location = new System.Drawing.Point(164, 143);
            this.nudSoLuongTong.Margin = new System.Windows.Forms.Padding(4);
            this.nudSoLuongTong.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSoLuongTong.Name = "nudSoLuongTong";
            this.nudSoLuongTong.Size = new System.Drawing.Size(422, 30);
            this.nudSoLuongTong.TabIndex = 13;
            // 
            // lblSoLuongCon
            // 
            this.lblSoLuongCon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSoLuongCon.AutoSize = true;
            this.lblSoLuongCon.Location = new System.Drawing.Point(593, 145);
            this.lblSoLuongCon.Name = "lblSoLuongCon";
            this.lblSoLuongCon.Size = new System.Drawing.Size(79, 25);
            this.lblSoLuongCon.TabIndex = 14;
            this.lblSoLuongCon.Text = "Còn lại:";
            this.lblSoLuongCon.UseMnemonic = false;
            // 
            // txtSoLuongCon
            // 
            this.txtSoLuongCon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuongCon.Location = new System.Drawing.Point(754, 143);
            this.txtSoLuongCon.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuongCon.Name = "txtSoLuongCon";
            this.txtSoLuongCon.ReadOnly = true;
            this.txtSoLuongCon.Size = new System.Drawing.Size(422, 30);
            this.txtSoLuongCon.TabIndex = 15;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Location = new System.Drawing.Point(10, 28);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1180, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÔNG TIN SÁCH";
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
            this.flpThaoTac.Controls.Add(this.btnKhoa);
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
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
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
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnKhoa
            // 
            this.btnKhoa.Location = new System.Drawing.Point(240, 4);
            this.btnKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(140, 42);
            this.btnKhoa.TabIndex = 2;
            this.btnKhoa.Text = "Khóa sách";
            this.btnKhoa.UseVisualStyleBackColor = true;
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(388, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 42);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(506, 4);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 42);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(634, 4);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 42);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 330);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(1200, 203);
            this.dgv.TabIndex = 2;
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // ucSach
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.gbThaoTac);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "ucSach";
            this.Size = new System.Drawing.Size(1200, 660);
            this.gbTimKiem.ResumeLayout(false);
            this.flpTimKiem.ResumeLayout(false);
            this.flpTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.tlpThongTin.ResumeLayout(false);
            this.tlpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaBia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongTong)).EndInit();
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
        private System.Windows.Forms.Label lblLocTheLoai;
        private System.Windows.Forms.ComboBox cboLocTheLoai;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.TextBox txtNXB;
        private System.Windows.Forms.Label lblNamXB;
        private System.Windows.Forms.TextBox txtNamXB;
        private System.Windows.Forms.Label lblGiaBia;
        private System.Windows.Forms.NumericUpDown nudGiaBia;
        private System.Windows.Forms.Label lblSoLuongTong;
        private System.Windows.Forms.NumericUpDown nudSoLuongTong;
        private System.Windows.Forms.Label lblSoLuongCon;
        private System.Windows.Forms.TextBox txtSoLuongCon;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgv;
    }
}
