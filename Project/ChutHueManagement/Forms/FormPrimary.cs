using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChutHueManagement.Utilities;
using ChutHueManagement.BusinessEntities;
using DevComponents.DotNetBar;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormPrimary : DevComponents.DotNetBar.RibbonForm
    {
        public AccountEntity account { get; set; }

        public FormPrimary()
        {
            InitializeComponent();
        }

        public FormPrimary(AccountEntity account)
        {
            InitializeComponent();
            this.account = account;
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
                FormChangePass frm = new FormChangePass(account);
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

        private void FormPrimary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var c = MessageBox.Show(@"Bạn có muốn thoát hay không !", @"Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (c == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    notifyIcon1.Dispose();
                    Environment.Exit(0);
                    //this.Close();
                }
            }
        }

        private void FormPrimary_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(3000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void hiểnThịChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(null, null);
        }

        private void thoátChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrimary_FormClosing(this, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất hay không", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Restart();
        }

    }
}