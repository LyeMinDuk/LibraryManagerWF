namespace LibraryManagerWF.GUI
{
    partial class ucTrangChu
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
            this.lblChao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChao
            // 
            this.lblChao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChao.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblChao.Location = new System.Drawing.Point(0, 0);
            this.lblChao.Name = "lblChao";
            this.lblChao.Size = new System.Drawing.Size(900, 600);
            this.lblChao.TabIndex = 0;
            this.lblChao.Text = "Chào mừng đến với phần mềm quản lý thư viện";
            this.lblChao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucTrangChu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.lblChao);
            this.Name = "ucTrangChu";
            this.Size = new System.Drawing.Size(900, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChao;
    }
}
