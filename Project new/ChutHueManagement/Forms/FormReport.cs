using ChutHueManagement.BusinessEntities;
using ChutHueManagement.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormReport : Form
    {
        //public FormReport()
        //{
        //    InitializeComponent();
        //}

        //private void FormReport_Load(object sender, EventArgs e)
        //{

        //    this.reportViewer1.RefreshReport();
        //}
        List<InfoEntity> listinfo = new List<InfoEntity>();

        Table table = new Table();

        List<TableEntity> listTableEntity = new List<TableEntity>();

        List<InvoiceDetailsEntity> listInvoiceDetailsEntity = new List<InvoiceDetailsEntity>();

        List<InvoiceEntity> listInvoiceEntity = new List<InvoiceEntity>();

        List<FoodMenuEntity> listFoodMenuEntity = new List<FoodMenuEntity>();

        public FormReport()
        {
            listinfo = InfoManager.ConvertToList(InfoManager.GetInfo());
            InitializeComponent();
        }

        public FormReport(Table table, InvoiceEntity invoiceEntity) : this()
        {

            this.table = table;
            ///
            /// 
            
            /// 
            ///
            listInvoiceDetailsEntity = table.ListInvoiceDetail;
            listTableEntity = TablesManager.ConvertToList(TablesManager.GetByID(int.Parse(table.ID)));
            listFoodMenuEntity = FoodMenuManager.ConvertToList(FoodMenuManager.GetAll());
            listInvoiceEntity.Add(invoiceEntity);
            //InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            LoadReport();
            //this.reportViewer1.RefreshReport();
        }

        void LoadReport()
        {
            reportViewer1.LocalReport.DataSources.Clear(); //clear report

            reportViewer1.LocalReport.ReportEmbeddedResource = "ChutHueManagement.ChutHueManagement.Forms.Report1.rdlc"; // bind reportviewer with .rdlc

            Microsoft.Reporting.WinForms.ReportDataSource infods = new Microsoft.Reporting.WinForms.ReportDataSource("InfoDataSet", listinfo); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource tableds = new Microsoft.Reporting.WinForms.ReportDataSource("TableDataSet", listTableEntity); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource invoiceds = new Microsoft.Reporting.WinForms.ReportDataSource("InvoiceDataSet", listInvoiceEntity); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource invoicedetailsds = new Microsoft.Reporting.WinForms.ReportDataSource("InvoiceDetailsDataSet", listInvoiceDetailsEntity); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource foodmenuds = new Microsoft.Reporting.WinForms.ReportDataSource("FoodMenuDataSet", listFoodMenuEntity); // set the datasource

            reportViewer1.LocalReport.DataSources.Add(infods);
            infods.Value = listinfo;

            reportViewer1.LocalReport.DataSources.Add(tableds);
            tableds.Value = listTableEntity;

            reportViewer1.LocalReport.DataSources.Add(invoiceds);
            invoiceds.Value = listInvoiceEntity;

            reportViewer1.LocalReport.DataSources.Add(invoicedetailsds);
            invoicedetailsds.Value = listInvoiceDetailsEntity;

            reportViewer1.LocalReport.DataSources.Add(foodmenuds);
            foodmenuds.Value = listFoodMenuEntity;

            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport(); // refresh report
        }
    }
}
