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
            //entity.Address = txt_diachi.Text;
            //entity.PhoneNumber = txt_dienthoai.Text;
            //entity.CellNumber = txt_fax.Text;
            //entity.Email = txt_email.Text;
            //entity.Description = tx
            return entity;
        }

        void SetEntity(InfoEntity entity)
        {
            txtNameRestaurant.Text = entity.NameRestaurant;
            //txt_diachi.Text = entity.DiaChi;
            //txt_dienthoai.Text = entity.DienThoai;
            //txt_fax.Text = entity.Fax;
            //txt_masothue.Text = entity.MaSoThue;
            //txt_email.Text = entity.Email;
            //txt_website.Text = entity.Website;
            //txt_mota.Text = entity.MoTa;
        }
    }
}
