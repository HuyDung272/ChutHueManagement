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
using DevComponents.DotNetBar;

namespace ChutHueManagement.Forms
{
    public partial class FormMainMenu_Add : DevComponents.DotNetBar.Metro.MetroForm
    {

        private string errorMessage = string.Empty;

        private MainMenuEntity entity;

        public FormMainMenu_Add()
        {
            InitializeComponent();
            btn_Add.Text = "Thêm";
            this.Text = "Thêm mới Loại thực đơn";
            this.radioBtn_IsDelete.Enabled = false;
        }

        public FormMainMenu_Add(MainMenuEntity entity)
        {
            InitializeComponent();
            btn_Add.Text = "Cập nhật";
            this.Text = "Cập nhật Loại thực đơn";
            this.entity = entity;
            this.lblUpdate.Text = "Cập nhật loại thực đơn: " + entity.NameEntryMenu;
            this.lblUpdate.ForeColor = Color.Red;

            txt_NameMainMenu.Text = entity.NameEntryMenu;
            txt_Description.Text = entity.Description;
            radioBtn_IsDelete.Checked = entity.IsDelete;
        }

        private void FormMainMenu_Add_Load(object sender, EventArgs e)
        {

        }

        public void XoaTrang()
        {
            this.txt_NameMainMenu.Clear();
            this.txt_Description.Clear();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            XoaTrang();
        }

        public bool CheckInput()
        {
            if (StringHelper.IsNullorEmpty(txt_NameMainMenu.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên loại thực đơn !");
                return false;
            }

            return true;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public MainMenuEntity GetEntity()
        {
            MainMenuEntity entity = new MainMenuEntity();
            entity.NameEntryMenu = this.txt_NameMainMenu.Text;
            entity.Description = this.txt_Description.Text;
            entity.IsDelete = this.radioBtn_IsDelete.Checked;
            return entity;
        }

        public void SetEntity(MainMenuEntity entity)
        {
            throw new NotImplementedException();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (entity == null)
                {
                    MainMenuEntity mainMenuEntity = GetEntity();
                    if (MainMenuManager.Insert(mainMenuEntity, ref errorMessage) > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }
                else
                {
                    MainMenuEntity mainMenuEntity = GetEntity();
                    mainMenuEntity.ID = this.entity.ID;
                    //mainMenuEntity.IsDelete = this.entity.IsDelete;
                    if (MainMenuManager.UpDate(mainMenuEntity, ref errorMessage))
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }
            }
        }
    }
}
