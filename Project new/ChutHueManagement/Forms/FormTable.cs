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
using DevComponents.DotNetBar.Controls;

using ChutHueManagement.BusinessLogicLayer;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.Utilities;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormTable : DevComponents.DotNetBar.Metro.MetroForm
    {
        public string truyendulieuchoformChinh = "";

        public FormTable()
        {
            InitializeComponent();
        }
        private void FormTable_Load(object sender, EventArgs e)
        {
            //labelX4.Text = Get_Invoice_SerialCode();
            try
            {
                AddPanel();
                LoadGrvThucDon();
                
                listTable[0].Button.PerformClick();
                
            }
            catch { };
        }
        
        public List<Table> listTable = new List<Table>();

        int index = 0;
        void LoadTable()
        {
            List<TableEntity> list = TablesManager.ConvertToList(TablesManager.GetAll());

            for (int i = 0; i < list.Count; i++)
            {

                ButtonX n;
                int x, y;
                if (i % 3 == 0)
                {
                    x = 5;
                    y = ((i / 3) * 100 + 5);
                }
                else if (i % 3 == 1)
                {
                    x = 100 + 10;
                    y = ((i / 3) * 100 + 5);
                }
                else
                {
                    x = 2 * 100 + 15;
                    y = (i / 3) * 100 + 5;
                }
                Table table = new Table();
                table.CovnertToButton(list[i], x, y, i.ToString());
                listTable.Add(table);
                listTable[i].Button.Click += new EventHandler(Button_Click);
            }
        }
        ButtonX ConvertToButton(TableEntity entity, int x, int y)
        {
            ButtonX n = new ButtonX();
            n.Text = entity.TableName.ToString();
            n.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            n.BackgroundImage = global::ChutHueManagement.ChutHueManagement.Properties.Resources.Ban;
            n.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            n.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            n.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            n.Name = entity.ID.ToString();
            n.Size = new System.Drawing.Size(131, 105);
            n.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            n.TextColor = System.Drawing.Color.Black;
            n.Location = new System.Drawing.Point(x, y);
            return n;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {

                ButtonX button = (ButtonX)sender;
                string i = button.Name;
                int index = int.Parse(i);
                if (listTable[index].ListInvoiceDetail.Count == 0)
                {
                    btnThanhToan.Enabled = false;
                }
                else
                {
                    btnThanhToan.Enabled = true;
                }
                lbSoBan.Text = button.Text;
                lbTGD.Text = listTable[index].TGDen.ToString();
                LoadGridview(listTable[index].ListInvoiceDetail);

            }
            catch
            {
            }
        }
        void AddPanel()
        {
            LoadTable();
            for (int i = 0; i < listTable.Count; i++)
            {
                groupPanel1.Controls.Add(listTable[i].Button);
            }
        }
        void LoadGridview(List<InvoiceDetailsEntity> tb)
        {
            try
            {
                double tongtien = 0;
                grwCTBan.Rows.Clear();
                for (int i = 0; i < tb.Count; i++)
                {
                    string nameFood = FoodMenuManager.ConvertToList(FoodMenuManager.GetByID(tb[i].IDFoodMenu))[0].NameFood;
                    int total = tb[i].Total;
                    double priceTotal = tb[i].PriceTotal;
                    tongtien += priceTotal;
                    grwCTBan.Rows.Add(i + 1, nameFood, total, priceTotal);
                }
                lbTongTien.Text = tongtien.ToString();
            }
            catch { }
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {

        }

        private void grwCTBan_Click(object sender, EventArgs e)
        {
            if (grwCTBan.SelectedRows.Count < 0)
            {
                suaMonToolStripMenuItem.Enabled = false;
                XoaToolStripMenuItem.Enabled = false;
            }
            else
            {
                suaMonToolStripMenuItem.Enabled = true;
                XoaToolStripMenuItem.Enabled = true;

            }

        }
        private void ssdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int indexRowSelected = grwCTBan.CurrentCell.RowIndex;
                InvoiceDetailsEntity entity = listTable[index].ListInvoiceDetail[indexRowSelected];
                AddEditInvoiceDetail frm = new AddEditInvoiceDetail(entity);
                frm.ShowDialog();
                entity = frm.Entity;
                frm.Dispose();
                listTable[index].ListInvoiceDetail[indexRowSelected] = entity;
                LoadGridview(listTable[index].ListInvoiceDetail);
            }
            catch { }
        }

        private void sadsadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Bạn có chắc xóa món này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int indexRowSelected = grwCTBan.CurrentCell.RowIndex;
                    listTable[index].ListInvoiceDetail.RemoveAt(indexRowSelected);
                    LoadGridview(listTable[index].ListInvoiceDetail);
                }
            }
            catch { }
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceDetailsEntity entity = new InvoiceDetailsEntity();
            AddEditInvoiceDetail frm = new AddEditInvoiceDetail(entity);
            frm.ShowDialog();
            entity = frm.Entity;
            frm.Dispose();
            if (listTable[index].ListInvoiceDetail.Count == 0)
                listTable[index].TGDen = DateTime.Now;
            listTable[index].ListInvoiceDetail.Add(entity);
            LoadGridview(listTable[index].ListInvoiceDetail);
        }
        FoodMenuEntity fooMenu;
        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridViewThucDon.SelectedRows[0];
                fooMenu = new FoodMenuEntity();
                fooMenu.ID = (int)row.Cells["ID"].Value;
                fooMenu.NameFood = txtMon.Text = row.Cells["NameFood"].Value.ToString();
                fooMenu.Price = (double)row.Cells["Price"].Value;
                txtDonGia.Text = fooMenu.Price.ToString();
                txtSoLuong.Text = "1";
            }
            catch
            {
            }
        }
        void LoadGrvThucDon()
        {
            //List<FoodMenuEntity> list = new List<FoodMenuEntity>();
            //list = FoodMenuManager.ConvertToList(FoodMenuManager.GetAll());
            //for (int i = 0; i < list.Count; i++)
            //{
            //    dataGridViewThucDon.Rows.Add(i + 1, list[i].NameFood, list[i].Price, list[i].Description, list[i].ID);
            //}
            dataGridViewThucDon.DataSource = FoodMenuManager.GetAll();
        }
        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int so = int.Parse(txtSoLuong.Text);
            if (so > 1)
                so--;
            txtSoLuong.Text = so.ToString();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            int so = int.Parse(txtSoLuong.Text);
            so++;
            txtSoLuong.Text = so.ToString();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = "1";
        }
        void AddFoodToInvoiceDetail(List<InvoiceDetailsEntity> list, InvoiceDetailsEntity entity)
        {
            bool ok = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IDFoodMenu == entity.IDFoodMenu)
                {
                    list[i].Total += entity.Total;
                    list[i].PriceTotal += entity.PriceTotal;
                    ok = true;
                    break;
                }
            }
            if (!ok)
            {
                list.Add(entity);
            }
        }
        private void btnThemVaoBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (listTable[index].ListInvoiceDetail.Count == 0)
                {
                    listTable[index].TGDen = DateTime.Now;
                    lbTGD.Text = DateTime.Now.ToString();
                }
                int total = int.Parse(txtSoLuong.Text);
                double priceTotal = total * double.Parse(txtDonGia.Text);
                AddFoodToInvoiceDetail(listTable[index].ListInvoiceDetail, new InvoiceDetailsEntity(0, fooMenu.ID, total, priceTotal));
                //listTable[index].ListInvoiceDetail.Add(new InvoiceDetailsEntity(0, fooMenu.ID, total, priceTotal));
                LoadGridview(listTable[index].ListInvoiceDetail);
                btnThanhToan.Enabled = true;
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
            FormPay frm = new FormPay(listTable[index]);
            frm.ShowDialog();
            if (frm.ISPAy)
            {
                listTable[index].ListInvoiceDetail = new List<InvoiceDetailsEntity>();
                listTable[index].Button.PerformClick();
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //string @string = textBoxX1.Text;
                //string filter = "NameFood LIKE ";
                //for (int i = 0; i < @string.Length; i++)
                //{
                //    filter += "'" + @string[i] + "%' ";
                //}
                //if (@string.Length < 1)
                //    filter = "NameFood LIKE '%%'";
                DataTable dt = FoodMenuManager.GetAll();
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("NameFood LIKE '%{0}%'", textBoxX1.Text);
                dataGridViewThucDon.DataSource = dv;
            }
            catch (Exception ex)
            { Logger.Write(ex); }
        }

        private void FormTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            //truyendulieuchoformChinh = textBoxX1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
