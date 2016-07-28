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
            toolStripStatusLabel_Time.Text = string.Format("Thời gian hệ thống: {0: h:mm:ss tt}", DateTime.Now);
        }

        

        private void btn_InfoRestaurant_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["FormInfo"] as FormInfo) == null)
            {
                FormInfo frm = new FormInfo();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                //this.Text = Title;
            }
            FormCollection a = Application.OpenForms;
            Library_Controls.ShowMDI(a, "FormInfo");
        }

        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["FormMainMenu"] as FormMainMenu) == null)
            {
                FormMainMenu frm = new FormMainMenu();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                //this.Text = Title;
            }
            FormCollection a = Application.OpenForms;
            Library_Controls.ShowMDI(a, "FormMainMenu");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_Time.Text = string.Format("Thời gian hệ thống: {0: h:mm:ss tt}", DateTime.Now);
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["FormChangePass"] as FormChangePass) == null)
            {
                FormChangePass frm = new FormChangePass();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Normal;
                //frm.WindowState /
                //frm.WindowState = FormWindowState.Maximized;
                //this.Text = Title;
            }
            FormCollection a = Application.OpenForms;
            Library_Controls.ShowMDI(a, "FormChangePass");
        }
    }
}