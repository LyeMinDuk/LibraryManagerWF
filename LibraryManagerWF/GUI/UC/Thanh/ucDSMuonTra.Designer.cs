namespace LibraryManagerWF.GUI
{
    partial class ucDSMuonTra
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.flpTimKiem = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLocTuKhoa = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gbTimKiem.SuspendLayout();
            this.flpTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeight = 34;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 83);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(1371, 674);
            this.dgv.TabIndex = 0;
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.flpTimKiem);
            this.gbTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTimKiem.Location = new System.Drawing.Point(0, 0);
            this.gbTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Padding = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.gbTimKiem.Size = new System.Drawing.Size(1371, 83);
            this.gbTimKiem.TabIndex = 3;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm / lọc";
            // 
            // flpTimKiem
            // 
            this.flpTimKiem.Controls.Add(this.lblLocTuKhoa);
            this.flpTimKiem.Controls.Add(this.txtTimKiem);
            this.flpTimKiem.Controls.Add(this.btnTimKiem);
            this.flpTimKiem.Controls.Add(this.btnLamMoi);
            this.flpTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTimKiem.Location = new System.Drawing.Point(10, 24);
            this.flpTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.flpTimKiem.Name = "flpTimKiem";
            this.flpTimKiem.Size = new System.Drawing.Size(1351, 48);
            this.flpTimKiem.TabIndex = 0;
            // 
            // lblLocTuKhoa
            // 
            this.lblLocTuKhoa.AutoSize = true;
            this.lblLocTuKhoa.Location = new System.Drawing.Point(10, 12);
            this.lblLocTuKhoa.Margin = new System.Windows.Forms.Padding(10, 12, 4, 0);
            this.lblLocTuKhoa.Name = "lblLocTuKhoa";
            this.lblLocTuKhoa.Size = new System.Drawing.Size(70, 20);
            this.lblLocTuKhoa.TabIndex = 0;
            this.lblLocTuKhoa.Text = "Từ khóa:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(88, 8);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(307, 26);
            this.txtTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(403, 4);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(129, 40);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(540, 4);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(129, 40);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // ucDSMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "ucDSMuonTra";
            this.Size = new System.Drawing.Size(1371, 757);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gbTimKiem.ResumeLayout(false);
            this.flpTimKiem.ResumeLayout(false);
            this.flpTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.FlowLayoutPanel flpTimKiem;
        private System.Windows.Forms.Label lblLocTuKhoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
