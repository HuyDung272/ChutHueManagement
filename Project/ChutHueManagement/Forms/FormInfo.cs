using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

using ChutHueManagement.BusinessLogicLayer;
using ChutHueManagement.BusinessEntities;

namespace ChutHueManagement.Forms
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            InfoEntity entity = InfoManager.ConvertToList(InfoManager.GetInfo())[0];
            SetEntity(entity);
        }

        InfoEntity GetEntity()
        {
            InfoEntity entity = new InfoEntity();
            entity.NameRestaurant = txtNameRestaurant.Text;
            entity.Address = txtAddress.Text;
            entity.PhoneNumber = txtPhoneNumber.Text;
            entity.CellNumber = txtCellPhone.Text;
            entity.Email = txtEmail.Text;
            entity.Description = txtDescription.Text;
            return entity;
        }

        void SetEntity(InfoEntity entity)
        {
            txtNameRestaurant.Text = entity.NameRestaurant;
            txtAddress.Text = entity.Address;
            txtPhoneNumber.Text = entity.PhoneNumber;
            txtCellPhone.Text = entity.CellNumber;
            txtEmail.Text = entity.Email;
            txtDescription.Text = entity.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InfoEntity entity = GetEntity();
            if (InfoManager.UpDate(entity))
            {
                MessageBox.Show("Lưu Thành Công");
            }
            else
            {
                MessageBox.Show("Lưu Thất Bại");
                InfoEntity entityold = InfoManager.ConvertToList(InfoManager.GetInfo())[0];
                SetEntity(entityold);
            }
        }
    }
}
