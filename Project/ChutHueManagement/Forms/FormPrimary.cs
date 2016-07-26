using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChutHueManagement.Utilities;
using DevComponents.DotNetBar;

namespace ChutHueManagement.Forms
{
    public partial class FormPrimary : DevComponents.DotNetBar.RibbonForm
    {
        public FormPrimary()
        {
            InitializeComponent();
        }

        private void FormPrimary_Load(object sender, EventArgs e)
        {

        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            
                FormInfo frm = new FormInfo();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            
        }
    }
}