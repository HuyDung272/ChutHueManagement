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
    public partial class FormEditAddTable : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormEditAddTable()
        {
            InitializeComponent();
        }
        TableEntity tb;

        public TableEntity Tb
        {
            get
            {
                return tb;
            }

            set
            {
                tb = value;
            }
        }

        public FormEditAddTable(TableEntity tb)
        {
            this.Tb = tb;
            InitializeComponent();
        }

        private void FormEditAddTable_Load(object sender, EventArgs e)
        {
            if(Tb!=null)
            {
                this.Text = lbTieuDe.Text = "Sửa Tên Bàn";
                btnOK.Text = "Sửa";
                txtNameOld.Text = Tb.TableName;
            }
            else
            {
                this.Text = lbTieuDe.Text = "Thêm Bàn";
                btnOK.Text = "Thêm";
                txtNameOld.Text = "";
            }
            
        }

        private void txtNamNew_TextChanged(object sender, EventArgs e)
        {
            if (txtNamNew.Text.CompareTo(txtNameOld.Text) == 0)
                btnOK.Enabled = false;
            else
                btnOK.Enabled = true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(tb !=null)
            {
                tb.TableName = txtNamNew.Text;
                if (TablesManager.UpDate(tb))
                {
                    MessageBox.Show("Sửa Bàn Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Sửa Bàn Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tb = new TableEntity();
                tb.TableName = txtNamNew.Text;
                if (TablesManager.Insert(tb) == 1)
                {
                    List<TableEntity> list = TablesManager.ConvertToList(TablesManager.GetAll());
                    tb = list[list.Count - 1];
                    MessageBox.Show("Thêm Bàn Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Thêm Bàn Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
            this.Close();
        }
    }
}