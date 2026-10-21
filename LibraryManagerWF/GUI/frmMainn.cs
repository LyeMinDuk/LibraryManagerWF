using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagerWF.GUI
{
    public partial class frmMainn : Form
    {
        bool sideBarExpand;

        public frmMainn()
        {
            InitializeComponent();
        }

        private void SideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                pnlSidebar.Width -= 50;
                if (pnlSidebar.Width <= pnlSidebar.MinimumSize.Width)
                {
                    sideBarExpand = false;
                    SideBarTimer.Stop();
                }
            }
            else
            {
                pnlSidebar.Width += 50;
                if (pnlSidebar.Width >= pnlSidebar.MaximumSize.Width)
                {
                    sideBarExpand = true;
                    SideBarTimer.Stop();
                }
            }
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            SideBarTimer.Start();
        }
    }
}
