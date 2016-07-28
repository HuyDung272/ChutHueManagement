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

        List<MainMenuEntity> mainMenuEntity = new List<MainMenuEntity>();

        

        public FormFoodMenu()
        {
            InitializeComponent();
        }

        private void FormFoodMenu_Load(object sender, EventArgs e)
        {
            LoadToComboBox();
            LoadListView(this.mainMenuEntity[0].ID);
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
            mainMenuEntity = MainMenuManager.ConvertToList(dt);

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
            dataGridView_Load.DataSource = dt;
            dataGridView_Load.Columns[2].Visible = false;
        }

        private void cBox_MainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}