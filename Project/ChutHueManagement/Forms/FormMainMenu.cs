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


namespace ChutHueManagement.Forms
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        public DataTable Table { get; set; }

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
                mainMenuEntity = MainMenuManager.ConvertToList(MainMenuManager.GetAll());
            }

        }

        private void toolStripBtn_Add_Click(object sender, EventArgs e)
        {
            var modelmathangthem = new FormMainMenu_Add();
            if (modelmathangthem.ShowDialog() == DialogResult.OK)
                LoadListView();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            mainMenuEntity = new List<MainMenuEntity>();
            LoadListView();
        }
    }
}
