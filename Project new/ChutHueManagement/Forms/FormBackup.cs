using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.BusinessLogicLayer;


namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormBackup : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string FileName = @" [" + string.Format(" {0:dd.MM.yy}", date) + string.Format(@" - {0:HH.mm.ss}", date) + @"] " + txtFileName.Text;

            string path = @"C:\Backup\" + FileName;

            if (BackupRestoreManager.Backup(FileName))
            {
                MessageBox.Show("Sao lưu giữ liệu thành công");
                LogBackupRestoreManager.Insert(new LogBackupRestoreEntity(FileName, date, true, path, txtNote.Text));
                //btn_themNhanh.Enabled = true;
                LoadListView();
            }
        }

        private void LoadListView()
        {
            DataTable dt = LogBackupRestoreManager.GetAll(true);
            if (dt == null) return;
            dataGridViewLoad.DataSource = dt;
            dataGridViewLoad.Columns[0].Visible = false;
        }
    }
}