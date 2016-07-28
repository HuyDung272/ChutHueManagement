using ChutHueManagement.BusinessEntities;
using System;
using ChutHueManagement.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChutHueManagement.BusinessLogicLayer;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormChangePass : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        AccountEntity account;

        string NewPass = string.Empty;

        string error = string.Empty;

        public FormChangePass(AccountEntity account)
        {
            InitializeComponent();
            this.account = account;
        }

        public FormChangePass()
        {
            InitializeComponent();
        }

        private void FormChangePass_Load(object sender, EventArgs e)
        {

        }

        void Clear()
        {
            txt_OldPass.Text = "";
            txt_NewPass.Text = "";
            txt_NewPass_2.Text = "";
        }

        private void btn_ChangePass_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                string oldpasshash = DataUtil.HashPassword(DataUtil.HashPassword(txt_OldPass.Text));
                string newpasshash = DataUtil.HashPassword(DataUtil.HashPassword(txt_NewPass.Text));

                if (AccountManager.ChangePass(account.UserName, oldpasshash, newpasshash, ref error))
                {
                    MessageBox.Show("Đổi mật khẩu thành công !");
                    Clear();
                }
                else
                    MessageBox.Show(error);
            }
            
        }

        

        private bool CheckInput()
        {
            if (StringHelper.IsNullorEmpty(txt_OldPass.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ !");
                return false;
            }
            if (StringHelper.IsNullorEmpty(txt_NewPass.Text) || StringHelper.IsNullorEmpty(txt_NewPass_2.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới !");
                return false;
            }
            if (txt_NewPass_2.Text != txt_NewPass.Text)
            {
                MessageBox.Show("Nhập mật khẩu mới không giống nhau ! ");
                return false;
            }
            return true;
        }
    }
}