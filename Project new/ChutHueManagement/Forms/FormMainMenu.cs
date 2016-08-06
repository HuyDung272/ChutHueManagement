using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.BusinessLogicLayer;
using ChutHueManagement.Utilities;


namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormMainMenu : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        public FormMainMenu(AccountEntity account)
        {
            this.account = account;
            InitializeComponent();
        }
        public DataTable Table { get; set; }

        AccountEntity account = new AccountEntity();

        string errormessage = string.Empty;

        private List<MainMenuEntity> mainMenuEntity;
        public void LoadListView(DataTable dt)
        {
            dataGridViewLoad.DataSource = dt;
            if (dataGridViewLoad.Columns.Count > 0)
            {
                dataGridViewLoad.Columns[0].Visible = false;
            }
        }
        public void LoadListView()
        {
            Table = DataUtil.ChangeColumn(MainMenuManager.GetAll());
            //Table = MainMenuManager.GetAll();
            if (Table != null)
            {
                //Table.Columns.Add(new DataColumn("Trạng thái"));
                //foreach (DataRow dataRow in Table.Rows)
                //{
                //    switch ((int)dataRow["Tình Trạng"])
                //    {
                //        case 0:
                //            dataRow["Trạng thái"] = "Đang bị khóa";
                //            break;
                //        case 1:
                //            dataRow["Trạng thái"] = "Đang được bán";
                //            break;
                //    }
                //    if ((int)dataRow["Số lượng"] == 0)
                //    {
                //        dataRow["Trạng thái"] = "Đang hết hàng";
                //        dataRow["Tình trạng"] = 2;
                //    }

                //}
                dataGridViewLoad.DataSource = Table;
                //dataGridViewLoad.Columns[0].Visible = false;
                //dataGridViewLoad.Columns["Tình trạng"].Visible = false;
                dataGridViewLoad.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewLoad.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //header giữa
                foreach (DataGridViewColumn col in dataGridViewLoad.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                mainMenuEntity = MainMenuManager.ConvertToList(MainMenuManager.GetAll());
            }

        }
        private void toolStripBtn_Add_Click(object sender, EventArgs e)
        {
            var formMainMenu_Add = new FormMainMenu_Add(this.account);
            if (formMainMenu_Add.ShowDialog() == DialogResult.OK)
                LoadListView();
        }
        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            mainMenuEntity = new List<MainMenuEntity>();
            LoadListView();
        }

        private void toolStripBtn_UpDate_Click(object sender, EventArgs e)
        {
            if (dataGridViewLoad.SelectedRows.Count > 0)
            {
                var row = dataGridViewLoad.SelectedRows[0];
                var entity = new MainMenuEntity()
                {
                    ID = (int)row.Cells[0].Value,
                    NameEntryMenu = (string)row.Cells[1].Value,
                    IsDelete = (bool)row.Cells[2].Value,
                    Description = (string)row.Cells[3].Value,
                };
                FormMainMenu_Add formMainMenu_Add = new FormMainMenu_Add(entity, this.account);
                if (formMainMenu_Add.ShowDialog() == DialogResult.OK)
                    LoadListView();
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripBtn_Add_Click(sender, e);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripBtn_UpDate_Click(sender, e);
        }

        private void toolStripBtn_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewLoad.SelectedRows.Count > 0)
            {
                int i = 0;
                var row = dataGridViewLoad.SelectedRows[0];
                var entity = new MainMenuEntity()
                {
                    ID = (int)row.Cells[0].Value,
                    NameEntryMenu = (string)row.Cells[1].Value,
                    IsDelete = (bool)row.Cells[2].Value,
                    Description = (string)row.Cells[3].Value,
                };

                var c = MessageBox.Show("Bạn muốn xóa Loại thực đơn \"" + entity.NameEntryMenu + "\" hay không?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (c == DialogResult.Yes)
                {
                    if (MainMenuManager.Delete((int)row.Cells[0].Value, ref errormessage))
                    {
                        i++;
                    }
                    else
                    {
                        MessageBox.Show(errormessage);
                        LoadListView();
                        return;
                    }

                    MessageBox.Show("Xóa thành công Loại thực đơn " + entity.NameEntryMenu);

                    LoadListView();
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripBtn_Delete_Click(sender, e);
        }
    }
}
