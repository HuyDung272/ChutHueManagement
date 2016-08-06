using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.Utilities;
using ChutHueManagement.BusinessLogicLayer;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormFoodMenu_Add : DevComponents.DotNetBar.Metro.MetroForm
    {
        MainMenuEntity mainMenuEntity = new MainMenuEntity();

        FoodMenuEntity foodMenuEntity;

        LogSystemEntity logsystem = new LogSystemEntity();

        AccountEntity account = new AccountEntity();

        string errorMessage = string.Empty;

        public FormFoodMenu_Add()
        {
            InitializeComponent();
        }

        public FormFoodMenu_Add(MainMenuEntity mainMenuEntity, AccountEntity account)
        {
            InitializeComponent();
            this.mainMenuEntity = mainMenuEntity;
            Clear();
            cb_IsDelete.Enabled = false;
            foodMenuEntity = null;
            this.account = account;
        }

        public FormFoodMenu_Add(MainMenuEntity mainMenuEntity, FoodMenuEntity foodMenuEntity, AccountEntity account)
        {
            InitializeComponent();
            this.mainMenuEntity = mainMenuEntity;
            this.foodMenuEntity = foodMenuEntity;
            SetEntity(foodMenuEntity);
            labelX1.Text = "Cập nhật loại thực đơn";
            btn_Add.Text = "Cập nhật";
            this.TitleText = "Cập nhật";
            this.account = account;
            //foodMenuEntity = null;
        }

        void SetEntity(FoodMenuEntity entity)
        {
            txt_Description.Text = entity.Description;
            cb_IsDelete.Checked = entity.IsDelete;
            txt_NameFood.Text = entity.NameFood;
            //entity.IdMainMenu = mainMenuEntity.ID;
            txt_Price.Text = entity.Price.ToString();
        }

        private void FormFoodMenu_Add_Load(object sender, EventArgs e)
        {
            this.lbl_NameMainMenu.Text = mainMenuEntity.NameEntryMenu;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            txt_NameFood.Text = "";
            txt_Description.Text = "";
            txt_Price.Text = "";
            cb_IsDelete.Checked = false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        FoodMenuEntity GetEntity()
        {
            FoodMenuEntity entity = new FoodMenuEntity();
            entity.Description = txt_Description.Text;
            entity.IsDelete = cb_IsDelete.Checked;
            entity.NameFood = txt_NameFood.Text;
            entity.IdMainMenu = mainMenuEntity.ID;
            entity.Price = double.Parse(txt_Price.Text);
            return entity;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (foodMenuEntity == null)
                {
                    FoodMenuEntity entity = GetEntity();
                    if (FoodMenuManager.Insert(entity, ref errorMessage) > 0)
                    {
                        logsystem = new LogSystemEntity()
                        {
                            IDAccount = account.ID,
                            Event = account.UserName + " đã thêm mới thực đơn " + entity.NameFood,
                            Date = DateTime.Now,
                        };

                        LogSystemManager.Insert(logsystem);

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
                    FoodMenuEntity entity = GetEntity();
                    entity.ID = this.foodMenuEntity.ID;
                    entity.IdMainMenu = this.foodMenuEntity.IdMainMenu;
                    //mainMenuEntity.IsDelete = this.entity.IsDelete;
                    if (FoodMenuManager.UpDate(entity, ref errorMessage))
                    {

                        logsystem = new LogSystemEntity()
                        {
                            IDAccount = account.ID,
                            Event = account.UserName + " đã cập nhật thực đơn " + foodMenuEntity.NameFood + "[ NameFood: " + entity.NameFood 
                            + ", ID: " + entity.ID + ", IsDelete: " + entity.IsDelete + ", IdMainMenu: " + entity.IdMainMenu + ", Price: " + entity.Price
                            + "]",
                            Date = DateTime.Now,
                        };

                        LogSystemManager.Insert(logsystem);

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

        public bool CheckInput()
        {
            if (StringHelper.IsNullorEmpty(txt_NameFood.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên thực đơn !");
                return false;
            }

            if (StringHelper.IsNullorEmpty(txt_Price.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá!");
                return false;
            }

            if (!StringHelper.IsNumber(txt_Price.Text))
            {
                MessageBox.Show("Bạn phải nhập giá trị số cho thông tin về giá!");
                return false;
            }

            return true;
        }
    }
}