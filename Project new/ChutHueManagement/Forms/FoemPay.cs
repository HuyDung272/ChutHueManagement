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
    public partial class FoemPay : DevComponents.DotNetBar.Metro.MetroForm
    {
        private bool iSPAy;
        public FoemPay()
        {
            InitializeComponent();
        }
        private Table _table;

        public bool ISPAy
        {
            get
            {
                return iSPAy;
            }

            set
            {
                iSPAy = value;
            }
        }

        public FoemPay(Table table)
        {
            _table = table;
            InitializeComponent();
        }

        private void FoemPay_Load(object sender, EventArgs e)
        {
            lbSoBan.Text = _table.Button.Text;
            lbTGD.Text = _table.TGDen.ToString();
            LoadGRV();
            txtTienKhachDua.Text = "0";
        }
        void LoadGRV()
        {
            double tong = 0;
            for (int i = 0; i < _table.ListInvoiceDetail.Count; i++)
            {
                string nameFood = FoodMenuManager.ConvertToList(FoodMenuManager.GetByID(_table.ListInvoiceDetail[i].IDFoodMenu))[0].NameFood;
                grvChiTiet.Rows.Add(nameFood, _table.ListInvoiceDetail[i].Total, _table.ListInvoiceDetail[i].PriceTotal);
                tong += _table.ListInvoiceDetail[i].PriceTotal;
            }
            txtTongTien.Text = tong.ToString();
            
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double tongtien = double.Parse(txtTongTien.Text);
                double tienKD = double.Parse(txtTienKhachDua.Text);
                txtTienThua.Text = (tienKD - tongtien).ToString();
            }
            catch { }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            iSPAy = true;
        }
    }
}