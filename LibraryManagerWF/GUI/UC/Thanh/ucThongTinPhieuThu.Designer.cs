namespace LibraryManagerWF.GUI
{
    partial class ucThongTinPhieuThu
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
            this.lblLocTu = new System.Windows.Forms.Label();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.cboLoaiThu = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.flpChiTiet = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaPhieuThu = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.lblLoaiThu = new System.Windows.Forms.Label();
            this.txtLoaiThu = new System.Windows.Forms.TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNgayThu = new System.Windows.Forms.DateTimePicker();
            this.lblGanVoi = new System.Windows.Forms.Label();
            this.txtGanVoi = new System.Windows.Forms.TextBox();
            this.lblNguoiThu = new System.Windows.Forms.Label();
            this.txtNguoiThu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.gbTimKiem.SuspendLayout();
            this.flpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tlpThongTin.SuspendLayout();
            this.flpChiTiet.SuspendLayout();
            this.gbThaoTac.SuspendLayout();
            this.flpThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.flpTimKiem);
            this.gbTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTimKiem.Location = new System.Drawing.Point(0, 0);
            this.gbTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Padding = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.gbTimKiem.Size = new System.Drawing.Size(1466, 83);
            this.gbTimKiem.TabIndex = 5;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm / lọc";
            // 
            // flpTimKiem
            // 
            this.flpTimKiem.Controls.Add(this.lblLocTu);
            this.flpTimKiem.Controls.Add(this.dtpTu);
            this.flpTimKiem.Controls.Add(this.lblDen);
            this.flpTimKiem.Controls.Add(this.dtpDen);
            this.flpTimKiem.Controls.Add(this.cboLoaiThu);
            this.flpTimKiem.Controls.Add(this.btnTimKiem);
            this.flpTimKiem.Controls.Add(this.btnLamMoi);
            this.flpTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTimKiem.Location = new System.Drawing.Point(10, 33);
            this.flpTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.flpTimKiem.Name = "flpTimKiem";
            this.flpTimKiem.Size = new System.Drawing.Size(1446, 39);
            this.flpTimKiem.TabIndex = 0;
            // 
            // lblLocTu
            // 
            this.lblLocTu.AutoSize = true;
            this.lblLocTu.Location = new System.Drawing.Point(10, 12);
            this.lblLocTu.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblLocTu.Name = "lblLocTu";
            this.lblLocTu.Size = new System.Drawing.Size(48, 29);
            this.lblLocTu.TabIndex = 0;
            this.lblLocTu.Text = "Từ:";
            // 
            // dtpTu
            // 
            this.dtpTu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTu.CustomFormat = "dd/MM/yyyy";
            this.dtpTu.Location = new System.Drawing.Point(65, 6);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(200, 35);
            this.dtpTu.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(278, 12);
            this.lblDen.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(63, 29);
            this.lblDen.TabIndex = 3;
            this.lblDen.Text = "Đến:";
            // 
            // dtpDen
            // 
            this.dtpDen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDen.CustomFormat = "dd/MM/yyyy";
            this.dtpDen.Location = new System.Drawing.Point(348, 6);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(200, 35);
            this.dtpDen.TabIndex = 2;
            // 
            // cboLoaiThu
            // 
            this.cboLoaiThu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboLoaiThu.FormattingEnabled = true;
            this.cboLoaiThu.Location = new System.Drawing.Point(554, 5);
            this.cboLoaiThu.Name = "cboLoaiThu";
            this.cboLoaiThu.Size = new System.Drawing.Size(121, 37);
            this.cboLoaiThu.TabIndex = 4;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(682, 4);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(129, 40);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(819, 4);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(129, 40);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 83);
            this.dgv.Margin = new System.Windows.Forms.Padding(8);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(1115, 940);
            this.dgv.TabIndex = 6;
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 2;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Controls.Add(this.lblTongTien, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblSoPhieu, 0, 0);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpThongTin.Location = new System.Drawing.Point(0, 943);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 1;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Size = new System.Drawing.Size(1115, 80);
            this.tlpThongTin.TabIndex = 9;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(1112, 25);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(0, 29);
            this.lblTongTien.TabIndex = 1;
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Location = new System.Drawing.Point(3, 25);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(0, 29);
            this.lblSoPhieu.TabIndex = 0;
            // 
            // flpChiTiet
            // 
            this.flpChiTiet.Controls.Add(this.lblTieuDe);
            this.flpChiTiet.Controls.Add(this.lblMaPhieuThu);
            this.flpChiTiet.Controls.Add(this.txt);
            this.flpChiTiet.Controls.Add(this.lblLoaiThu);
            this.flpChiTiet.Controls.Add(this.txtLoaiThu);
            this.flpChiTiet.Controls.Add(this.lblSoTien);
            this.flpChiTiet.Controls.Add(this.txtSoTien);
            this.flpChiTiet.Controls.Add(this.label5);
            this.flpChiTiet.Controls.Add(this.dtpNgayThu);
            this.flpChiTiet.Controls.Add(this.lblGanVoi);
            this.flpChiTiet.Controls.Add(this.txtGanVoi);
            this.flpChiTiet.Controls.Add(this.lblNguoiThu);
            this.flpChiTiet.Controls.Add(this.txtNguoiThu);
            this.flpChiTiet.Controls.Add(this.lblGhiChu);
            this.flpChiTiet.Controls.Add(this.txtGhiChu);
            this.flpChiTiet.Controls.Add(this.gbThaoTac);
            this.flpChiTiet.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpChiTiet.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpChiTiet.Location = new System.Drawing.Point(1115, 83);
            this.flpChiTiet.Name = "flpChiTiet";
            this.flpChiTiet.Size = new System.Drawing.Size(351, 940);
            this.flpChiTiet.TabIndex = 10;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTieuDe.Location = new System.Drawing.Point(48, 10);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(3, 10, 3, 30);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(249, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Chi Tiết Phiếu Thu";
            // 
            // lblMaPhieuThu
            // 
            this.lblMaPhieuThu.AutoSize = true;
            this.lblMaPhieuThu.Location = new System.Drawing.Point(3, 72);
            this.lblMaPhieuThu.Name = "lblMaPhieuThu";
            this.lblMaPhieuThu.Size = new System.Drawing.Size(168, 29);
            this.lblMaPhieuThu.TabIndex = 1;
            this.lblMaPhieuThu.Text = "Mã Phiếu Thu:";
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt.Location = new System.Drawing.Point(30, 104);
            this.txt.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(313, 35);
            this.txt.TabIndex = 15;
            // 
            // lblLoaiThu
            // 
            this.lblLoaiThu.AutoSize = true;
            this.lblLoaiThu.Location = new System.Drawing.Point(3, 154);
            this.lblLoaiThu.Name = "lblLoaiThu";
            this.lblLoaiThu.Size = new System.Drawing.Size(113, 29);
            this.lblLoaiThu.TabIndex = 3;
            this.lblLoaiThu.Text = "Loại Thu:";
            // 
            // txtLoaiThu
            // 
            this.txtLoaiThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtLoaiThu.Location = new System.Drawing.Point(30, 186);
            this.txtLoaiThu.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtLoaiThu.Name = "txtLoaiThu";
            this.txtLoaiThu.Size = new System.Drawing.Size(313, 35);
            this.txtLoaiThu.TabIndex = 16;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(3, 236);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(98, 29);
            this.lblSoTien.TabIndex = 5;
            this.lblSoTien.Text = "Số Tiền";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSoTien.Location = new System.Drawing.Point(30, 268);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(313, 35);
            this.txtSoTien.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ngày Thu:";
            // 
            // dtpNgayThu
            // 
            this.dtpNgayThu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpNgayThu.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayThu.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpNgayThu.Location = new System.Drawing.Point(30, 350);
            this.dtpNgayThu.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.dtpNgayThu.Name = "dtpNgayThu";
            this.dtpNgayThu.Size = new System.Drawing.Size(313, 35);
            this.dtpNgayThu.TabIndex = 22;
            // 
            // lblGanVoi
            // 
            this.lblGanVoi.AutoSize = true;
            this.lblGanVoi.Location = new System.Drawing.Point(3, 400);
            this.lblGanVoi.Name = "lblGanVoi";
            this.lblGanVoi.Size = new System.Drawing.Size(104, 29);
            this.lblGanVoi.TabIndex = 9;
            this.lblGanVoi.Text = "Gắn Với:";
            // 
            // txtGanVoi
            // 
            this.txtGanVoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGanVoi.Location = new System.Drawing.Point(30, 432);
            this.txtGanVoi.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtGanVoi.Name = "txtGanVoi";
            this.txtGanVoi.Size = new System.Drawing.Size(313, 35);
            this.txtGanVoi.TabIndex = 19;
            // 
            // lblNguoiThu
            // 
            this.lblNguoiThu.AutoSize = true;
            this.lblNguoiThu.Location = new System.Drawing.Point(3, 482);
            this.lblNguoiThu.Name = "lblNguoiThu";
            this.lblNguoiThu.Size = new System.Drawing.Size(132, 29);
            this.lblNguoiThu.TabIndex = 11;
            this.lblNguoiThu.Text = "Người Thu:";
            // 
            // txtNguoiThu
            // 
            this.txtNguoiThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNguoiThu.Location = new System.Drawing.Point(30, 514);
            this.txtNguoiThu.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtNguoiThu.Name = "txtNguoiThu";
            this.txtNguoiThu.Size = new System.Drawing.Size(313, 35);
            this.txtNguoiThu.TabIndex = 20;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(3, 564);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(105, 29);
            this.lblGhiChu.TabIndex = 13;
            this.lblGhiChu.Text = "Ghi Chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGhiChu.Location = new System.Drawing.Point(30, 596);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(313, 35);
            this.txtGhiChu.TabIndex = 21;
            // 
            // gbThaoTac
            // 
            this.gbThaoTac.Controls.Add(this.flpThaoTac);
            this.gbThaoTac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbThaoTac.Location = new System.Drawing.Point(4, 650);
            this.gbThaoTac.Margin = new System.Windows.Forms.Padding(4);
            this.gbThaoTac.Name = "gbThaoTac";
            this.gbThaoTac.Padding = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.gbThaoTac.Size = new System.Drawing.Size(338, 173);
            this.gbThaoTac.TabIndex = 23;
            this.gbThaoTac.TabStop = false;
            this.gbThaoTac.Text = "Thao tác";
            // 
            // flpThaoTac
            // 
            this.flpThaoTac.Controls.Add(this.btnSua);
            this.flpThaoTac.Controls.Add(this.btnXoa);
            this.flpThaoTac.Controls.Add(this.btnHuy);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThaoTac.Location = new System.Drawing.Point(10, 33);
            this.flpThaoTac.Margin = new System.Windows.Forms.Padding(4);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flpThaoTac.Size = new System.Drawing.Size(318, 129);
            this.flpThaoTac.TabIndex = 0;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(55, 4);
            this.btnSua.Margin = new System.Windows.Forms.Padding(55, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(123, 45);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(186, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(123, 45);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(55, 57);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(55, 4, 4, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(123, 45);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // ucThongTinPhieuThu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpThongTin);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.flpChiTiet);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "ucThongTinPhieuThu";
            this.Size = new System.Drawing.Size(1466, 1023);
            this.gbTimKiem.ResumeLayout(false);
            this.flpTimKiem.ResumeLayout(false);
            this.flpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tlpThongTin.ResumeLayout(false);
            this.tlpThongTin.PerformLayout();
            this.flpChiTiet.ResumeLayout(false);
            this.flpChiTiet.PerformLayout();
            this.gbThaoTac.ResumeLayout(false);
            this.flpThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.FlowLayoutPanel flpTimKiem;
        private System.Windows.Forms.Label lblLocTu;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.ComboBox cboLoaiThu;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.FlowLayoutPanel flpChiTiet;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaPhieuThu;
        private System.Windows.Forms.Label lblLoaiThu;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGanVoi;
        private System.Windows.Forms.Label lblNguoiThu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.TextBox txtLoaiThu;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.DateTimePicker dtpNgayThu;
        private System.Windows.Forms.TextBox txtGanVoi;
        private System.Windows.Forms.TextBox txtNguoiThu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
    }
}
