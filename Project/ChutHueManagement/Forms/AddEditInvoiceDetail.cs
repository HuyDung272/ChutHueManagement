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
namespace ChutHueManagement.ChutHueManagement
{
    public partial class AddEditInvoiceDetail : DevComponents.DotNetBar.Metro.MetroForm
    {
        private InvoiceDetailsEntity entity = new InvoiceDetailsEntity();

        public InvoiceDetailsEntity Entity
        {
            get
            {
                return entity;
            }

            set
            {
                entity = value;
            }
        }

        public AddEditInvoiceDetail()
        {
            InitializeComponent();
        }

        public AddEditInvoiceDetail(InvoiceDetailsEntity entity)
        {
            this.Entity = entity;
            InitializeComponent();
        }
        private void AddEditInvoiceDetail_Load(object sender, EventArgs e)
        {
            if (Entity.IDFoodMenu == 0)
            {
                this.cbbMon.Enabled = true;
                this.Text = "Thêm món mới";
                this.btnOK.Text = "Thêm";
            }
            else
            {
                this.cbbMon.Enabled = false;
                this.Text = "Sửa món mới";
                this.btnOK.Text = "Sửa";
                this.txtsoLuong.Text = Entity.Total.ToString();
                this.txtThanhTien.Text = Entity.PriceTotal.ToString();
            }
            LoadCBB();
        }
        void LoadCBB()
        {
            cbbMon.Items.Clear();
            List<FoodMenuEntity> list = FoodMenuManager.ConvertToList(FoodMenuManager.GetAll());
            cbbMon.DisplayMember = "NameFood";
            cbbMon.ValueMember = "ID";
            cbbMon.DataSource = list;
        }

        private void txtsoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtsoLuong.Text.Length > 0)
                {
                    int soLuong = int.Parse(txtsoLuong.Text);
                    txtThanhTien.Text = (soLuong * FoodMenuManager.ConvertToList(FoodMenuManager.GetByID((int)cbbMon.SelectedValue))[0].Price).ToString();
                }
                else
                {
                    txtsoLuong.Text = "1";
                    int soLuong = int.Parse(txtsoLuong.Text);
                    txtThanhTien.Text = (soLuong * FoodMenuManager.ConvertToList(FoodMenuManager.GetByID((int)cbbMon.SelectedValue))[0].Price).ToString();
                }
            }
            catch {
            }
            
        }

        private void txtsoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Entity.IDFoodMenu = (int) cbbMon.SelectedValue;
            Entity.PriceTotal = int.Parse(txtThanhTien.Text);
            Entity.Total = int.Parse(txtsoLuong.Text);
            if(btnOK.Text == "Thêm")
            {
                if (Entity != null)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                if (Entity != null)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}