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
    public partial class FormMainMenu_Add : Form
    {

        private string Textloi = string.Empty;

        private MainMenu entity;

        public FormMainMenu_Add()
        {
            InitializeComponent();
            this.Text = "Thêm mới Loại thực đơn";
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
            return entity;
        }



        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (entity == null)
                {
                    MainMenuEntity mainMenuEntity = GetEntity();
                    if (MainMenuManager.Insert(mainMenuEntity) > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(Textloi);
                    }
                }
                //else
                //{
                //    ModelMatHangEntity modelMatHangEntity = GetEntity();
                //    modelMatHangEntity.MaModelMH = this.entity.MaModelMH;
                //    if (ModelMatHangManager.UpDate(modelMatHangEntity, ref Textloi))
                //    {
                //        MessageBox.Show("Cập nhật thành công!");
                //        DialogResult = DialogResult.OK;
                //    }
                //    else
                //    {
                //        MessageBox.Show(Textloi);
                //    }
                //}
            }
        }
    }
}
