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
    public partial class FormPay : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormPay()
        {
            InitializeComponent();
        }
        private Table _table;

       

        public FormPay(Table table)
        {
            _table = table;
            InitializeComponent();
        }

        private void FoemPay_Load(object sender, EventArgs e)
        {

            TableEntity tb = TablesManager.ConvertToList(TablesManager.GetByID(int.Parse(_table.ID)))[0];
            lbSoBan.Text = tb.TableName;
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
        string Get_Invoice_SerialCode()
        {
            DataTable dt;

            dt = InvoiceManager.GetSerialCodeMax();
            string nam = DateTime.Now.Year.ToString().Substring(1, DateTime.Now.Year.ToString().Length - 1);
            if (dt.Rows.Count == 0)
            {
                return nam + "-000000001";
            }
            string mahd = dt.Rows[0][0].ToString();
            string[] temp = mahd.Split('-');
            if (temp[0].CompareTo(nam) != 0)
            {
                return nam + "-000000001";
            }

            int duoi = 0;
            string Duoi = "";
            if (temp[0].CompareTo(nam) == 0)
            {
                mahd = "";
                duoi = (int.Parse(temp[1]) + 1);
                if (duoi < 10)
                {
                    Duoi = "-00000000" + duoi;
                }
                else
                {
                    if (duoi < 100)
                    {
                        Duoi = "-0000000" + duoi;
                    }
                    else
                    {
                        if (duoi < 1000)
                        {
                            Duoi = "-000000" + duoi;
                        }
                        else
                        {
                            if (duoi < 10000)
                            {
                                Duoi = "-00000" + duoi;
                            }
                            else
                            {
                                if (duoi < 100000)
                                {
                                    Duoi = "-0000" + duoi;
                                }
                                else
                                {
                                    if (duoi < 1000000)
                                        Duoi = "-000" + duoi;
                                    else
                                    {
                                        if (duoi < 10000000)
                                            Duoi = "-00" + duoi;
                                        else
                                            Duoi = "-0" + duoi;
                                    }
                                }
                            }
                        }
                    }
                }

                mahd = temp[0] + Duoi;

                return mahd;
            }
            else
                return null;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                string tableName = TablesManager.ConvertToList(TablesManager.GetByID(int.Parse(_table.ID)))[0].TableName;
                InvoiceEntity invoice = new InvoiceEntity(Get_Invoice_SerialCode(), tableName, DateTime.Now, "");
                invoice.ListDetail = _table.ListInvoiceDetail;
                if(InvoiceManager.InsertTS(invoice, ref error)!=0)
                {
                    MessageBox.Show("Đã Thanh Toán Thành Công","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            btnThanhToan.Enabled = true;
        }

    }
}