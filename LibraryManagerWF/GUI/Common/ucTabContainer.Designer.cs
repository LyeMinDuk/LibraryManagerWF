namespace LibraryManagerWF.GUI
{
    partial class ucTabContainer
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.flpTab = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.pnlTieuDe.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTieuDe
            //
            this.pnlTieuDe.BackColor = System.Drawing.Color.FromArgb(32, 36, 104);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(900, 44);
            this.pnlTieuDe.TabIndex = 0;
            //
            // lblTieuDe
            //
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(900, 44);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "TIÊU ĐỀ";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // flpTab
            //
            this.flpTab.BackColor = System.Drawing.Color.White;
            this.flpTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTab.Location = new System.Drawing.Point(0, 44);
            this.flpTab.Name = "flpTab";
            this.flpTab.Padding = new System.Windows.Forms.Padding(12, 6, 0, 6);
            this.flpTab.Size = new System.Drawing.Size(900, 48);
            this.flpTab.TabIndex = 1;
            //
            // pnlNoiDung
            //
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(0, 92);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Size = new System.Drawing.Size(900, 508);
            this.pnlNoiDung.TabIndex = 2;
            //
            // ucTabContainer
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.flpTab);
            this.Controls.Add(this.pnlTieuDe);
            this.Name = "ucTabContainer";
            this.Size = new System.Drawing.Size(900, 600);
            this.pnlTieuDe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.FlowLayoutPanel flpTab;
        private System.Windows.Forms.Panel pnlNoiDung;
    }
}
