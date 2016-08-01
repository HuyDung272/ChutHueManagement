using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Globalization;
using ChutHueManagement.BusinessLogicLayer;
using ChutHueManagement.Utilities;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormReportSales : DevComponents.DotNetBar.Metro.MetroForm
    {
        int indexReportFor = 0;
        int indexMainFood = 0;
        int indexFoodMenu = 0;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
        public FormReportSales()
        {
            InitializeComponent();
        }
        double PriceTotal = 0;
        private void FormReportSales_Load(object sender, EventArgs e)
        {
            //http://stackoverflow.com/questions/20327129/datagridview-with-money-format
            PriceTotal = 0.0;
            string money = double.Parse(PriceTotal.ToString()).ToString("#,###", cul.NumberFormat);
            //lbl_PriceTotal.Text = money + " đồng";
            txt_PriceTotal.Text = money + " đồng";
            //lbl_PriceTotal.Style["text-align"] = "right";
            LoadListReportFor();
            LoadMainFood();
            LoadListFoodMenu();
            GetDay();
        }

        void LoadListReportFor()
        {
            cbox_ReportFor.Items.Add("Theo ngày");
            cbox_ReportFor.Items.Add("Theo khoảng thời gian");
            cbox_ReportFor.Items.Add("Theo tháng");
            cbox_ReportFor.Items.Add("Theo năm");
            cbox_ReportFor.SelectedIndex = 0;
        }

        void LoadMainFood()
        {
            cbox_MainFood.Items.Add("Tất cả");
            cbox_MainFood.Items.Add("Theo loại thực đơn");
            cbox_MainFood.SelectedIndex = 0;
        }

        void GetDay()
        {
            //DateTime dt = DateTime.ParseExact(DateTime.Now.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            dateTimeInput_Start.Value = DateTime.Now;
            dateTimeInput_End.Value = DateTime.Now;
        }

        private void cbox_ReportFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexReportFor = cbox_ReportFor.SelectedIndex;
            if (indexReportFor == 0)
            {
                dateTimeInput_End.Enabled = false;
                dateTimeInput_Start.CustomFormat = "dd/MM/yyyy";
                dateTimeInput_End.CustomFormat = "dd/MM/yyyy";
                return;
            }

            if (indexReportFor == 1)
            {
                dateTimeInput_End.Enabled = true;
                dateTimeInput_Start.Value = DateTime.Now.AddDays(-7);
                dateTimeInput_Start.CustomFormat = "dd/MM/yyyy";
                dateTimeInput_End.CustomFormat = "dd/MM/yyyy";
                return;
            }
            if (indexReportFor == 2)
            {
                dateTimeInput_End.Enabled = true;
                dateTimeInput_Start.CustomFormat = "MM/yyyy";
                dateTimeInput_End.CustomFormat = "MM/yyyy";
                return;
            }
            if (indexReportFor == 3)
            {
                dateTimeInput_End.Enabled = true;
                dateTimeInput_Start.CustomFormat = "yyyy";
                dateTimeInput_End.CustomFormat = "yyyy";
                return;
            }
            //MessageBox.Show(indexReportFor.ToString());
        }

        private void cbox_MainFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexMainFood = cbox_MainFood.SelectedIndex;
            if (indexMainFood == 0)
            {
                cbox_FoodMenu.Enabled = false;
            }
            else
            {
                cbox_FoodMenu.Enabled = true;
            }
        }

        DataTable listFoodMenu;
        void LoadListFoodMenu()
        {
            listFoodMenu = DataUtil.ChangeColumn(FoodMenuManager.GetAll());
            cbox_FoodMenu.DataSource = listFoodMenu;       //MainMenuManager.GetAll();
            cbox_FoodMenu.DisplayMember = "Tên món";
            cbox_FoodMenu.DropDownColumns = "Mã, Tên món";
            cbox_FoodMenu.DropDownHeight = 300;
            cbox_FoodMenu.DropDownHeight = 200;
        }

        private void cbox_FoodMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexFoodMenu = cbox_FoodMenu.SelectedIndex;
            DataRow dr = listFoodMenu.Rows[indexFoodMenu];
            indexFoodMenu = (int)dr[0];
            //MessageBox.Show(indexFoodMenu.ToString());
        }

        

        void LoadData()
        {
            DataTable tables = new DataTable();
            if (indexMainFood == 0)
            {
                var start =  DateTime.Parse(dateTimeInput_Start.Value.ToString("yyyy-MM-dd"));
                var end = new DateTime();
                if (indexReportFor == 1)
                {
                     end = DateTime.Parse(dateTimeInput_End.Value.AddDays(1).ToString("yyyy-MM-dd"));
                }
                else
                {
                     end = DateTime.Parse(dateTimeInput_End.Value.ToString("yyyy-MM-dd"));
                }
                tables = InvoiceManager.GetSalesAllByDateTime(indexReportFor, start, end);
                tables = DataUtil.ChangeColumn(tables);
                //tables.Columns[3].DataType = typeof(decimal);
                dataGridView_Load.DataSource = tables;
                dataGridView_Load.Columns[0].Visible = false;
                dataGridView_Load.Columns[3].DefaultCellStyle.Format = "#,##00 đồng";
                dataGridView_Load.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView_Load.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView_Load.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                //header giữa
                foreach (DataGridViewColumn col in dataGridView_Load.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                PriceTotal = 0;

                for (int i = 0; i < tables.Rows.Count; i++)
                {
                    DataRow dr = tables.Rows[i];
                    double so = (double)dr[3];
                    PriceTotal +=  so;
                }
                
                string money = double.Parse(PriceTotal.ToString()).ToString("#,###", cul.NumberFormat);
                txt_PriceTotal.Text = money + " đồng";
                //lbl_PriceTotal.Text = money + " đồng";
                lbl_Total.Text = "Tổng hóa đơn:";
                txt_Total.Text = tables.Rows.Count.ToString();

            }
            else
            {
                var start = DateTime.Parse(dateTimeInput_Start.Value.ToString("yyyy-MM-dd"));
                var end = new DateTime();
                if (indexReportFor == 1)
                {
                    end = DateTime.Parse(dateTimeInput_End.Value.AddDays(1).ToString("yyyy-MM-dd"));
                }
                else
                {
                    end = DateTime.Parse(dateTimeInput_End.Value.ToString("yyyy-MM-dd"));
                }
                tables = InvoiceManager.GetSalesWithFoodForFoodByDateTime(indexFoodMenu, indexReportFor, start, end);
                tables = DataUtil.ChangeColumn(tables);
                //tables.Columns[]
                //tables.Columns[3].DataType = typeof(decimal);
                dataGridView_Load.DataSource = tables;
                dataGridView_Load.Columns[2].Visible = false;
                //header giữa
                foreach (DataGridViewColumn col in dataGridView_Load.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                PriceTotal = 0;
                int Total = 0;
                for (int i = 0; i < tables.Rows.Count; i++)
                {
                    DataRow dr = tables.Rows[i];
                    PriceTotal += (double)dr[5];
                    Total += (int)dr[4];
                }

                string money = double.Parse(PriceTotal.ToString()).ToString("#,###", cul.NumberFormat);
                txt_PriceTotal.Text = money + " đồng";
                //lbl_PriceTotal.Text = money + " đồng";

                lbl_Total.Text = "Tổng số:";
                txt_Total.Text = Total.ToString();
            }
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}