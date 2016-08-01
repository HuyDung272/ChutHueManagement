using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ChutHueManagement.BusinessLogicLayer;
using ChutHueManagement.Utilities;
using ChutHueManagement.BusinessEntities;
using System.IO;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormRestore : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormRestore()
        {
            InitializeComponent();
        }

        private void FormRestore_Load(object sender, EventArgs e)
        {
            cbox_BackupRestore.Items.Add("Phục hồi dữ liệu");
            cbox_BackupRestore.Items.Add("Nhật ký");
            cbox_BackupRestore.SelectedIndex = 0;
            cbox_BackupRestore.Width = 300;
        }
        
        private void cbox_BackupRestore_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowindex = cbox_BackupRestore.SelectedIndex;

            if (rowindex == 0)
            {
                LoadListBackup();
                btn_Restore.Enabled = true;
            }
            else
            {
                LoadListRestore();
                btn_Restore.Enabled = false;
            }
            //MessageBox.Show(rowindex.ToString());
            //mainMenuEntity = listmainMenuEntity[rowindex];
        }

        void LoadListBackup()
        {
            DataTable dt = LogBackupRestoreManager.GetAll(true);
            dt = DataUtil.ChangeColumn(dt);
            if (dt == null) return;
            dataGridViewLoad.DataSource = dt;
            //header giữa
            foreach (DataGridViewColumn col in dataGridViewLoad.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        void LoadListRestore()
        {
            DataTable dt = LogBackupRestoreManager.GetAll(false);
            dt = DataUtil.ChangeColumn(dt);
            if (dt == null) return;
            dataGridViewLoad.DataSource = dt;
            //header giữa
            foreach (DataGridViewColumn col in dataGridViewLoad.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            if (dataGridViewLoad.SelectedRows.Count > 0)
            {
                var row = dataGridViewLoad.SelectedRows[0];
                var entity = new LogBackupRestoreEntity()
                {
                    ID = (int)row.Cells[0].Value,
                    Name = (string)row.Cells[1].Value,
                    Date = (DateTime)row.Cells[2].Value,
                    IsBackup = (bool)row.Cells[3].Value,
                    Path = (string)row.Cells[4].Value,
                    Note = (string)row.Cells[5].Value,
                };
            DialogResult dlr = MessageBox.Show("Bạn có muốn phục hồi dữ liệu từ " + entity.Name, "Phục hồi dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No)
            {
                    return;
            }
            FormCheckAccount frm = new FormCheckAccount();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                    DateTime date = DateTime.Now;
                    //string FileName = @" [" + string.Format(" {0:dd.MM.yy}", date) + string.Format(@" - {0:HH.mm.ss}", date) + @"] " + txtFileName.Text;

                    string path = entity.Path+".bak";
                    string Note = "Backup từ " + entity.Name;
                    
                    if (BackupRestoreManager.Restore(path))
                    {
                        LogBackupRestoreManager.Insert(new LogBackupRestoreEntity(entity.Name, date, false, path, Note));
                        MessageBox.Show("Phục hồi dữ liệu thành công");

                        //btn_themNhanh.Enabled = true;
                        cbox_BackupRestore.SelectedIndex = 1;
                    }
                    else
                    {
                        MessageBox.Show("Phục hồi dữ liệu thất bại");
                    }

                }
            }
        }
    }
}