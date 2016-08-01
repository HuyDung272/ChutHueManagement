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
using ChutHueManagement.Utilities;
using System.IO;

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
            FormCheckAccount frm = new FormCheckAccount();
            
           
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DateTime date = DateTime.Now;
                string FileName = @"[" + string.Format(" {0:dd.MM.yy}", date) + string.Format(@" - {0:HH.mm.ss}", date) + @"] " + txtFileName.Text;

                string path = @"C:\Backup\" + FileName;
                
                int idlog = LogBackupRestoreManager.InsertGetID(new LogBackupRestoreEntity(FileName, date, true, path, txtNote.Text));
                string palettesPath = @"C:\Backup";
                try
                {
                    // If the directory doesn't exist, create it.
                    if (!Directory.Exists(palettesPath))
                    {
                        Directory.CreateDirectory(palettesPath);
                    }
                }
                catch (Exception)
                {
                    // Fail silently
                }
                if (BackupRestoreManager.Backup(FileName))
                {
                    MessageBox.Show("Sao lưu giữ liệu thành công");
                    //btn_themNhanh.Enabled = true;
                    LoadListView();
                }
                else
                {
                    LogBackupRestoreManager.Delete(idlog);
                    MessageBox.Show("Sao lưu dữ liệu thất bại");
                }

            }
            
        }

        private void LoadListView()
        {
            DataTable dt = LogBackupRestoreManager.GetAll(true);
            dt = DataUtil.ChangeColumn(dt);
            if (dt == null) return;
            dataGridViewLoad.DataSource = dt;
            //dataGridViewLoad.Columns[0].Visible = false;
            //header giữa
            foreach (DataGridViewColumn col in dataGridViewLoad.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        
    }
}