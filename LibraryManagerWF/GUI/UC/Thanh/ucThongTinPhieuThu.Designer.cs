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
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.flpChiTiet = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaPhieuThu = new System.Windows.Forms.Label();
            this.lblLoaiThu = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGanVoi = new System.Windows.Forms.Label();
            this.lblNguoiThu = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.txtLoaiThu = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtGanVoi = new System.Windows.Forms.TextBox();
            this.txtNguoiThu = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.dtpNgayThu = new System.Windows.Forms.DateTimePicker();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXacNhan = new System.Windows.Forms.Button();
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
            this.gbTimKiem.Location = new System.Drawing.Point(0, 0);
            this.gbTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Padding = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.gbTimKiem.Size = new System.Drawing.Size(1328, 83);
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
            this.flpTimKiem.Location = new System.Drawing.Point(10, 24);
            this.flpTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.flpTimKiem.Name = "flpTimKiem";
            this.flpTimKiem.Size = new System.Drawing.Size(1308, 48);
            this.flpTimKiem.TabIndex = 0;
            // 
            // lblLocTu
            // 
            this.lblLocTu.AutoSize = true;
            this.lblLocTu.Location = new System.Drawing.Point(10, 12);
            this.lblLocTu.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblLocTu.Name = "lblLocTu";
            this.lblLocTu.Size = new System.Drawing.Size(31, 20);
            this.lblLocTu.TabIndex = 0;
            this.lblLocTu.Text = "Từ:";
            // 
            // dtpTu
            // 
            this.dtpTu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTu.CustomFormat = "dd/MM/yyyy";
            this.dtpTu.Location = new System.Drawing.Point(48, 11);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(200, 26);
            this.dtpTu.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(261, 12);
            this.lblDen.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(43, 20);
            this.lblDen.TabIndex = 3;
            this.lblDen.Text = "Đến:";
            // 
            // dtpDen
            // 
            this.dtpDen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDen.CustomFormat = "dd/MM/yyyy";
            this.dtpDen.Location = new System.Drawing.Point(311, 11);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(200, 26);
            this.dtpDen.TabIndex = 2;
            // 
            // cboLoaiThu
            // 
            this.cboLoaiThu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboLoaiThu.FormattingEnabled = true;
            this.cboLoaiThu.Location = new System.Drawing.Point(517, 10);
            this.cboLoaiThu.Name = "cboLoaiThu";
            this.cboLoaiThu.Size = new System.Drawing.Size(121, 28);
            this.cboLoaiThu.TabIndex = 4;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(645, 4);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(129, 40);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(782, 4);
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
            this.dgv.Size = new System.Drawing.Size(977, 774);
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
            this.tlpThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.tlpThongTin.Location = new System.Drawing.Point(0, 777);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 1;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Size = new System.Drawing.Size(977, 80);
            this.tlpThongTin.TabIndex = 9;
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Location = new System.Drawing.Point(3, 21);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(0, 37);
            this.lblSoPhieu.TabIndex = 0;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(974, 21);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(0, 37);
            this.lblTongTien.TabIndex = 1;
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
            this.flpChiTiet.Location = new System.Drawing.Point(977, 83);
            this.flpChiTiet.Name = "flpChiTiet";
            this.flpChiTiet.Size = new System.Drawing.Size(351, 774);
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
            this.lblMaPhieuThu.Size = new System.Drawing.Size(110, 20);
            this.lblMaPhieuThu.TabIndex = 1;
            this.lblMaPhieuThu.Text = "Mã Phiếu Thu:";
            // 
            // lblLoaiThu
            // 
            this.lblLoaiThu.AutoSize = true;
            this.lblLoaiThu.Location = new System.Drawing.Point(3, 145);
            this.lblLoaiThu.Name = "lblLoaiThu";
            this.lblLoaiThu.Size = new System.Drawing.Size(74, 20);
            this.lblLoaiThu.TabIndex = 3;
            this.lblLoaiThu.Text = "Loại Thu:";
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(3, 218);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(63, 20);
            this.lblSoTien.TabIndex = 5;
            this.lblSoTien.Text = "Số Tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ngày Thu:";
            // 
            // lblGanVoi
            // 
            this.lblGanVoi.AutoSize = true;
            this.lblGanVoi.Location = new System.Drawing.Point(3, 364);
            this.lblGanVoi.Name = "lblGanVoi";
            this.lblGanVoi.Size = new System.Drawing.Size(71, 20);
            this.lblGanVoi.TabIndex = 9;
            this.lblGanVoi.Text = "Gắn Với:";
            // 
            // lblNguoiThu
            // 
            this.lblNguoiThu.AutoSize = true;
            this.lblNguoiThu.Location = new System.Drawing.Point(3, 437);
            this.lblNguoiThu.Name = "lblNguoiThu";
            this.lblNguoiThu.Size = new System.Drawing.Size(85, 20);
            this.lblNguoiThu.TabIndex = 11;
            this.lblNguoiThu.Text = "Người Thu:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(3, 510);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(71, 20);
            this.lblGhiChu.TabIndex = 13;
            this.lblGhiChu.Text = "Ghi Chú:";
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt.Location = new System.Drawing.Point(30, 95);
            this.txt.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(313, 35);
            this.txt.TabIndex = 15;
            // 
            // txtLoaiThu
            // 
            this.txtLoaiThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtLoaiThu.Location = new System.Drawing.Point(30, 168);
            this.txtLoaiThu.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtLoaiThu.Name = "txtLoaiThu";
            this.txtLoaiThu.Size = new System.Drawing.Size(313, 35);
            this.txtLoaiThu.TabIndex = 16;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSoTien.Location = new System.Drawing.Point(30, 241);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(313, 35);
            this.txtSoTien.TabIndex = 17;
            // 
            // txtGanVoi
            // 
            this.txtGanVoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGanVoi.Location = new System.Drawing.Point(30, 387);
            this.txtGanVoi.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtGanVoi.Name = "txtGanVoi";
            this.txtGanVoi.Size = new System.Drawing.Size(313, 35);
            this.txtGanVoi.TabIndex = 19;
            // 
            // txtNguoiThu
            // 
            this.txtNguoiThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNguoiThu.Location = new System.Drawing.Point(30, 460);
            this.txtNguoiThu.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtNguoiThu.Name = "txtNguoiThu";
            this.txtNguoiThu.Size = new System.Drawing.Size(313, 35);
            this.txtNguoiThu.TabIndex = 20;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGhiChu.Location = new System.Drawing.Point(30, 533);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(313, 35);
            this.txtGhiChu.TabIndex = 21;
            // 
            // dtpNgayThu
            // 
            this.dtpNgayThu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpNgayThu.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtpNgayThu.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpNgayThu.Location = new System.Drawing.Point(30, 314);
            this.dtpNgayThu.Margin = new System.Windows.Forms.Padding(30, 3, 3, 15);
            this.dtpNgayThu.Name = "dtpNgayThu";
            this.dtpNgayThu.Size = new System.Drawing.Size(313, 35);
            this.dtpNgayThu.TabIndex = 22;
            // 
            // gbThaoTac
            // 
            this.gbThaoTac.Controls.Add(this.flpThaoTac);
            this.gbThaoTac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbThaoTac.Location = new System.Drawing.Point(4, 587);
            this.gbThaoTac.Margin = new System.Windows.Forms.Padding(4);
            this.gbThaoTac.Name = "gbThaoTac";
            this.gbThaoTac.Padding = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.gbThaoTac.Size = new System.Drawing.Size(338, 143);
            this.gbThaoTac.TabIndex = 23;
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
            this.flpThaoTac.Location = new System.Drawing.Point(10, 24);
            this.flpThaoTac.Margin = new System.Windows.Forms.Padding(4);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flpThaoTac.Size = new System.Drawing.Size(318, 108);
            this.flpThaoTac.TabIndex = 0;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(4, 4);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(123, 45);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(186, 4);
            this.btnSua.Margin = new System.Windows.Forms.Padding(55, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(123, 45);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(4, 57);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(123, 45);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(186, 57);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(55, 4, 4, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(123, 45);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // ucQuanLyPhieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpThongTin);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.flpChiTiet);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "ucQuanLyPhieuThu";
            this.Size = new System.Drawing.Size(1328, 857);
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
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
    }
}
