namespace LibraryManagerWF.GUI
{
    partial class ucChoPhatTrien
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
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblNoiDung.Location = new System.Drawing.Point(0, 0);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(900, 600);
            this.lblNoiDung.TabIndex = 0;
            this.lblNoiDung.Text = "Chức năng chưa được cài đặt.";
            this.lblNoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucChoPhatTrien
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.lblNoiDung);
            this.Name = "ucChoPhatTrien";
            this.Size = new System.Drawing.Size(900, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNoiDung;
    }
}
