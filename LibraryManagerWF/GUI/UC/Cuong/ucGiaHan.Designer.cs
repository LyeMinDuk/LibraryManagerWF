namespace LibraryManagerWF.GUI.UC.Cuong
{
    partial class ucGiaHan
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
            this.gbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.flpTim = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.gbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.flpThaoTac.SuspendLayout();
            this.flpTim.SuspendLayout();
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
            this.lblTieuDe.Text = "GIA HẠN SÁCH";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.UseMnemonic = false;
            // 
            // gbDanhSach
            // 
            this.gbDanhSach.Controls.Add(this.dgv);
            this.gbDanhSach.Controls.Add(this.lblChiTiet);
            this.gbDanhSach.Controls.Add(this.flpThaoTac);
            this.gbDanhSach.Controls.Add(this.flpTim);
            this.gbDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDanhSach.Location = new System.Drawing.Point(0, 36);
            this.gbDanhSach.Name = "gbDanhSach";
            this.gbDanhSach.Padding = new System.Windows.Forms.Padding(10, 5, 10, 8);
            this.gbDanhSach.Size = new System.Drawing.Size(1200, 624);
            this.gbDanhSach.TabIndex = 1;
            this.gbDanhSach.TabStop = false;
            this.gbDanhSach.Text = "Sách đang mượn (chưa trả) — chọn một dòng để gia hạn";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(10, 74);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(1180, 468);
            this.dgv.TabIndex = 0;
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiTiet.Location = new System.Drawing.Point(10, 542);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(1180, 32);
            this.lblChiTiet.TabIndex = 1;
            this.lblChiTiet.Text = "Chọn một dòng trong danh sách để xem chi tiết.";
            this.lblChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChiTiet.UseMnemonic = false;
            // 
            // flpThaoTac
            // 
            this.flpThaoTac.Controls.Add(this.btnGiaHan);
            this.flpThaoTac.Controls.Add(this.btnLamMoi);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpThaoTac.Location = new System.Drawing.Point(10, 574);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.Size = new System.Drawing.Size(1180, 50);
            this.flpThaoTac.TabIndex = 2;
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(4, 4);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(4);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(180, 42);
            this.btnGiaHan.TabIndex = 0;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(192, 4);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 42);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // flpTim
            // 
            this.flpTim.Controls.Add(this.lblTuKhoa);
            this.flpTim.Controls.Add(this.txtTimKiem);
            this.flpTim.Controls.Add(this.btnTimKiem);
            this.flpTim.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTim.Location = new System.Drawing.Point(10, 28);
            this.flpTim.Name = "flpTim";
            this.flpTim.Size = new System.Drawing.Size(1180, 46);
            this.flpTim.TabIndex = 3;
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
            this.txtTimKiem.Size = new System.Drawing.Size(320, 30);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(436, 4);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 38);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // ucGiaHan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gbDanhSach);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucGiaHan";
            this.Size = new System.Drawing.Size(1200, 660);
            this.gbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.flpThaoTac.ResumeLayout(false);
            this.flpTim.ResumeLayout(false);
            this.flpTim.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox gbDanhSach;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.FlowLayoutPanel flpThaoTac;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.FlowLayoutPanel flpTim;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
    }
}
