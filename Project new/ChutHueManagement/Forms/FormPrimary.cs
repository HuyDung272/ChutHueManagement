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
using ChutHueManagement.BusinessLogicLayer;
using DevComponents.DotNetBar.Metro;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormPrimary : DevComponents.DotNetBar.RibbonForm
    {
        string errormessage = string.Empty;

        LogSystemEntity logsystem = new LogSystemEntity();

        string truyenchoFormTable = "";

        List<Table> ListTableForFormTable;

        public AccountEntity account { get; set; }

        public FormPrimary()
        {
            InitializeComponent();
        }

        public FormPrimary(AccountEntity account)
        {
            InitializeComponent();
            this.account = account;

            //truyenchoFormTable = "Dữ liệu frm chính";
            
            FormTable frm = new FormTable();
            //frm.truyendulieuchoformChinh = truyenchoFormTable;
            //frm.listTable = ListTableForFormTable;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListTableForFormTable = frm.listTable;
                //truyenchoFormTable = frm.truyendulieuchoformChinh;
                //MessageBox.Show(truyenchoFormTable);
            }

            //if ((Application.OpenForms["FormTable"] as FormTable) == null)
            //{
            //    FormTable frm = new FormTable();
            //    frm.MdiParent = this;
            //    frm.Show();
            //    //frm.WindowState = FormWindowState.Normal;
            //    //frm.WindowState /
            //    frm.WindowState = FormWindowState.Maximized;
            //    //this.Text = Title;
            //}
            //FormCollection a = Application.OpenForms;
            //Library_Controls.ShowMDI(a, "FormTable");

            logsystem = new LogSystemEntity()
            {
                IDAccount = account.ID,
                Event = account.UserName + " đã đăng nhập hệ thống",
                Date = DateTime.Now,
            };

            LogSystemManager.Insert(logsystem);
        }

        private void FormPrimary_Load(object sender, EventArgs e)
        {
            List<Table> ListTableForFormTable = new List<Table>();
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

            //bool ok = false;
            //foreach (MetroForm item in this.MdiChildren)
            //{
            //    if (item.Name == "FormMainMenu")
            //    {
            //        item.Activate();
            //        ok = true;
            //    }
            //    item.Hide();
            //    ok = false;
            //}

            //if (ok == false)
            //{
            //    FormMainMenu frm = new FormMainMenu();
            //    frm.MdiParent = this;
            //    frm.Show();
            //}
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
                    logsystem = new LogSystemEntity()
                    {
                        IDAccount = account.ID,
                        Event = account.UserName + " đã thoát khỏi chương trình",
                        Date = DateTime.Now,
                    };

                    LogSystemManager.Insert(logsystem);
                    Application.Exit();
                    //this.Close();
                }
            }
        }

        private void FormPrimary_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000);
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
            {
                logsystem = new LogSystemEntity()
                {
                    IDAccount = account.ID,
                    Event = account.UserName + " đã đăng xuất hệ thống",
                    Date = DateTime.Now,
                };

                LogSystemManager.Insert(logsystem);

                Application.Restart();
            }
        }

        private void btn_FoodMenu_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["FormFoodMenu"] as FormFoodMenu) == null)
            {
                FormFoodMenu frm = new FormFoodMenu();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                //frm.WindowState = FormWindowState.Normal;
                //frm.WindowState /
                
                //this.Text = Title;
                
            }
            FormCollection a = Application.OpenForms;
            Library_Controls.ShowMDI(a, "FormFoodMenu");
        }

        

        private void btn_Invoice_Click(object sender, EventArgs e)
        {
            //truyenchoFormTable = "Dữ liệu frm chính";
            
            FormTable frm = new FormTable();
            //frm.truyendulieuchoformChinh = truyenchoFormTable;
            frm.listTable = ListTableForFormTable;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListTableForFormTable = frm.listTable;
                //truyenchoFormTable = frm.truyendulieuchoformChinh;
                //MessageBox.Show(truyenchoFormTable);
            }

            //if ((Application.OpenForms["FormTable"] as FormTable) == null)
            //{
            //    FormTable frm = new FormTable();
            //    frm.MdiParent = this;
            //    frm.Show();
            //    frm.WindowState = FormWindowState.Maximized;
            //    //this.Text = Title;
            //}
            //FormCollection a = Application.OpenForms;
            //Library_Controls.ShowMDI(a, "FormTable");

            //bool ok = false;
            //foreach (MetroForm item in this.MdiChildren)
            //{
            //    if (item.Name == "FormTable")
            //    {
            //        item.Activate();
            //        ok = true;
            //    }
            //    item.Hide();
            //    ok = false;
            //}

            //if (ok == false)
            //{
            //    FormTable frm = new FormTable();
            //    frm.MdiParent = this;
            //    frm.Show();
            //}


        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["FormBackup"] as FormBackup) == null)
            {
                FormBackup frm = new FormBackup();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                //this.Text = Title;
            }
            FormCollection a = Application.OpenForms;
            Library_Controls.ShowMDI(a, "FormBackup");
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["FormTable"] as FormBackup) == null)
            {
                FormBackup frm = new FormBackup();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                //this.Text = Title;
            }
            FormCollection a = Application.OpenForms;
            Library_Controls.ShowMDI(a, "FormTable");
        }
    }
}