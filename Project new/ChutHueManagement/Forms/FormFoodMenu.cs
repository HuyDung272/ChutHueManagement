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

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormFoodMenu : DevComponents.DotNetBar.Metro.MetroForm
    {

        MainMenuEntity mainMenuEntity = new MainMenuEntity();

        List<MainMenuEntity> listmainMenuEntity = new List<MainMenuEntity>();

        List<FoodMenuEntity> listFoodMenuEntity = new List<FoodMenuEntity>();

        string errormessage = string.Empty;

        public FormFoodMenu()
        {
            InitializeComponent();
            LoadToComboBox();
        }

        private void FormFoodMenu_Load(object sender, EventArgs e)
        {
            LoadToComboBox();
            LoadListView(this.listmainMenuEntity[0].ID);
        }

        List<MainMenuEntity> GetInfoMainMenu()
        {
            List<MainMenuEntity> entity = MainMenuManager.ConvertToList(MainMenuManager.GetAll());
            return entity;
        }

        List<MainMenuEntity> GetMainMenuNotDelete(List<MainMenuEntity> list)
        {
            List<MainMenuEntity> entity = new List<MainMenuEntity>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsDelete == false)
                {
                    entity.Add(list[i]);
                }
            }
            return entity;
        }

        void LoadToComboBox()
        {
            DataTable dt = DataUtil.ChangeColumn(MainMenuManager.GetAllNotDelete());
            listmainMenuEntity = MainMenuManager.ConvertToList(dt);

            cBox_MainMenu.DataSource = dt;       //MainMenuManager.GetAll();
            cBox_MainMenu.DisplayMember = "Loại thực đơn";
            cBox_MainMenu.DropDownColumns = "Mã, Loại thực đơn";
            cBox_MainMenu.DropDownHeight = 75;

            //mainMenuEntity = GetMainMenuNotDelete(GetInfoMainMenu());
            //cBox_MainMenu.DataSource = mainMenuEntity;       //MainMenuManager.GetAll();
            //cBox_MainMenu.DisplayMember = "NameEntryMenu";
            //cBox_MainMenu.DropDownColumns = "ID, NameEntryMenu";
            //cBox_MainMenu.DropDownHeight = 75;
            ////SetAutoCompleKhachHang(dt);
        }

        void LoadListView(int idMainMenu)
        {
            DataTable dt = DataUtil.ChangeColumn(FoodMenuManager.GetByIDMainMenu(idMainMenu));
            listFoodMenuEntity = FoodMenuManager.ConvertToList(dt);
            dataGridView_Load.DataSource = dt;
            dataGridView_Load.Columns[2].Visible = false;
        }

        private void cBox_MainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MainMenuEntity rowmainmenu = getMainMenuEntity((DataRowView)cBox_MainMenu.SelectedValue);
            int rowindex = cBox_MainMenu.SelectedIndex;
            mainMenuEntity = listmainMenuEntity[rowindex];
            LoadListView(mainMenuEntity.ID);
        }

        private MainMenuEntity getMainMenuEntity(DataRowView row)
        {
            var entity = new MainMenuEntity()
            {
                ID = (int)row[0],
                NameEntryMenu = (string)row[1],
                IsDelete = (bool)row[2],
                Description = (string)row[2]
            };
            return entity;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var FoodMenu_add = new FormFoodMenu_Add(mainMenuEntity);
            if (FoodMenu_add.ShowDialog() == DialogResult.OK)
                LoadListView(mainMenuEntity.ID);
        }

        private void btn_UpDate_Click(object sender, EventArgs e)
        {
            if (dataGridView_Load.SelectedRows.Count > 0)
            {
                var row = dataGridView_Load.SelectedRows[0];
                var entity = new FoodMenuEntity()
                {
                    ID = (int)row.Cells[0].Value,
                    NameFood = (string)row.Cells[1].Value,
                    IdMainMenu = (int)row.Cells[2].Value,
                    Price = (double)row.Cells[3].Value,
                    IsDelete = (bool)row.Cells[4].Value,
                    Description = (string)row.Cells[5].Value,
                };
                FormFoodMenu_Add FoodMenu_add = new FormFoodMenu_Add(mainMenuEntity, entity);
                if (FoodMenu_add.ShowDialog() == DialogResult.OK)
                    LoadListView(mainMenuEntity.ID);
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Add_Click(sender, e);
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Load.SelectedRows.Count > 0)
            {
                var row = dataGridView_Load.SelectedRows[0];
                var entity = new FoodMenuEntity()
                {
                    ID = (int)row.Cells[0].Value,
                    NameFood = (string)row.Cells[1].Value,
                    IdMainMenu = (int)row.Cells[2].Value,
                    Price = (double)row.Cells[3].Value,
                    IsDelete = (bool)row.Cells[4].Value,
                    Description = (string)row.Cells[5].Value,
                };
                FormFoodMenu_Add FoodMenu_add = new FormFoodMenu_Add(mainMenuEntity, entity);
                if (FoodMenu_add.ShowDialog() == DialogResult.OK)
                    LoadListView(mainMenuEntity.ID);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_Load.SelectedRows.Count > 0)
            {
                int i = 0;
                var row = dataGridView_Load.SelectedRows[0];
                var entity = new FoodMenuEntity()
                {
                    ID = (int)row.Cells[0].Value,
                    NameFood = (string)row.Cells[1].Value,
                    IdMainMenu = (int)row.Cells[2].Value,
                    Price = (double)row.Cells[3].Value,
                    IsDelete = (bool)row.Cells[4].Value,
                    Description = (string)row.Cells[5].Value,
                };

                var c = MessageBox.Show("Bạn muốn xóa \"" + entity.NameFood + "\" hay không?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (c == DialogResult.Yes)
                {
                    if (FoodMenuManager.Delete((int)row.Cells[0].Value, ref errormessage))
                    {
                        i++;
                    }
                    else
                    {
                        MessageBox.Show(errormessage);
                        LoadListView(mainMenuEntity.ID);
                        return;
                    }

                    MessageBox.Show("Xóa thành công thực đơn " + entity.NameFood);

                    LoadListView(mainMenuEntity.ID);
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Delete_Click(sender, e);
        }
    }
}