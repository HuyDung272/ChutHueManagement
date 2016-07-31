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

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormCheckAccount : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormCheckAccount()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string user = txt_UserName.Text;
            string passwordhash = DataUtil.HashPassword(DataUtil.HashPassword(txt_Password.Text));

            if (IsInput())
            {
                try
                {
                    var nv = AccountManager.LogIn(user, passwordhash);
                    if (nv != null)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thông tin không chính xác!");
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
                catch
                {
                    
                }
                finally
                {
                  
                }
            }
            
        }

        private bool IsInput()
        {
            if (StringHelper.IsNullorEmpty(txt_UserName.Text))
            {
                MessageBox.Show("Tài khoản không được để trống !");
                return false;
            }
            if (StringHelper.IsNullorEmpty(txt_Password.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống !");
                return false;
            }
            return true;
        }
    }
}