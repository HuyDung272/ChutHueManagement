using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ChutHueManagement.BusinessLogicLayer;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.Utilities;
using System.Globalization;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class FormTable : DevComponents.DotNetBar.Metro.MetroForm
    {
        private List<Table> listTable;
        public FormTable()
        {
            listTable = new List<Table>();
            InitializeComponent();
        }

        int index = 0;
        public FormTable(List<Table> lt)
        {
            InitializeComponent();
            listTable = lt;
        }

        public List<Table> ListTable
        {
            get
            {
                return listTable;
            }

            set
            {
                listTable = value;
            }
        }
        void LoadGrvThucDon()
        {
            // dataGridViewThucDon.DataSource = FoodMenuManager.GetAll();
            dataGridViewThucDon.DataSource = FoodMenuManager.GetNotDelete();
        }
        void ResetActived()
        {
            for (int i = 0; i < listTable.Count; i++)
            {
                listTable[i].IsActived = false;
            }
        }
        private void FormTable_Load(object sender, EventArgs e)
        {
            lbTGD.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            LoadPanelTables();
            LoadGrvThucDon();
        }

        void LoadTable()
        {
            List<TableEntity> list = TablesManager.ConvertToList(TablesManager.GetAll());
            for (int i = 0; i < list.Count; i++)
            {
                Table table = new Table();
                table.ID = list[i].ID.ToString();
                listTable.Add(table);
            }

        }
        public ButtonX CovnertToButton(TableEntity entity, int x, int y, string name)
        {
            ButtonX _button = new ButtonX();
            _button.Text = entity.TableName;
            _button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            _button.BackgroundImage = global::ChutHueManagement.ChutHueManagement.Properties.Resources.Ban;
            _button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            _button.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            _button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _button.Name = name;
            _button.Size = new System.Drawing.Size(100, 82);
            _button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            _button.TextColor = System.Drawing.Color.Black;
            _button.Location = new System.Drawing.Point(x, y);
            
            return _button;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {

                ButtonX button = (ButtonX)sender;
                toolStripSuaBan.Text = "Sửa Bàn " + button.Text;
                toolStripXoaBan.Text = "Xóa Bàn " + button.Text;
                toolStripSuaBan.Enabled = true;
                toolStripXoaBan.Enabled = true;
                string i = button.Name;
                index = int.Parse(i);
                if (listTable[index].ListInvoiceDetail.Count == 0)
                {
                    btnThanhToan.Enabled = false;
                }
                else
                {
                    btnThanhToan.Enabled = true;
                }
                lbSoBan.Text = button.Text;
                //listTable[index].TGDen. = "";
                lbTGD.Text = listTable[index].TGDen.ToString("dd/MM/yyyy HH:mm:ss");
                LoadGridview(listTable[index].ListInvoiceDetail);
                ResetActived();
                listTable[index].IsActived = true;
            }
            catch
            {
            }
        }

        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
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

                string money = double.Parse(tongtien.ToString()).ToString("#,###", cul.NumberFormat);
                lbTongTien.Text = money + " đ";
            }
            catch { }
        }
        void LoadPanelTables()
        {
            panelTables.Controls.Clear();
            if (listTable.Count == 0)
                LoadTable();
            bool ok = false;
            for (int i = 0; i < listTable.Count; i++)
            {
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
                TableEntity tb = TablesManager.ConvertToList(TablesManager.GetByID(int.Parse(listTable[i].ID)))[0];
                ButtonX _button = CovnertToButton(tb, x, y, i.ToString());
                _button.Click += new EventHandler(Button_Click);
                if (listTable[i].IsActived)
                {
                    ok = true;
                    _button.PerformClick();
                }
                if (i == listTable.Count - 1 && !ok)
                {
                    _button.PerformClick();
                }
                panelTables.Controls.Add(_button);
            }
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
                    //lbTGD.Text = listTable[index].TGDen.ToString("dd/MM/yyyy HH:mm:ss");
                    lbTGD.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
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
        FoodMenuEntity fooMenu;
        private void dataGridViewThucDon_Click(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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
            if (int.Parse(txtSoLuong.Text) > 1)
            {
                int so = int.Parse(txtSoLuong.Text);
                so--;
                txtSoLuong.Text = so.ToString();
            }
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            FormPay frm = new FormPay(listTable[index]);
            if (frm.ShowDialog()==DialogResult.OK)
            {
                listTable[index].ListInvoiceDetail = new List<InvoiceDetailsEntity>();
                grwCTBan.Rows.Clear();
                btnThanhToan.Enabled = false;
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = FoodMenuManager.GetAll();
            dt.DefaultView.RowFilter = string.Format("NameFood LIKE '%{0}%'", textBoxX1.Text);
            dataGridViewThucDon.DataSource = dt;
        }

        private void toolstripthemban_Click(object sender, EventArgs e)
        {
            FormEditAddTable frm = new FormEditAddTable();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Table tb = new Table();
                tb.ID = frm.Tb.ID.ToString();
                listTable.Add(tb);
                LoadPanelTables();
            }
            
        }

        private void toolStripSuaBan_Click(object sender, EventArgs e)
        {
            TableEntity tb = TablesManager.ConvertToList(TablesManager.GetByID(int.Parse(listTable[index].ID)))[0];
            FormEditAddTable frm = new FormEditAddTable(tb);
            if(frm.ShowDialog()==DialogResult.OK)
            {
                LoadPanelTables();
            }
        }

        private void toolStripXoaBan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn " + toolStripXoaBan.Text+"\n" + toolStripXoaBan.Text+", sẽ xóa hết dữ liệu hiện hành.\n Bạn chắc chứ?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (TablesManager.Delete(int.Parse(listTable[index].ID)))
                {
                    MessageBox.Show("Đã " + toolStripXoaBan.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listTable.RemoveAt(index);
                    LoadPanelTables();
                }
                else
                {
                    MessageBox.Show( toolStripXoaBan.Text + "Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnXoaTrangBan_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn Có Chắc Muốn Xóa Trắng Bàn Này?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                listTable[index].ListInvoiceDetail = new List<InvoiceDetailsEntity>();
                LoadPanelTables();
            }
        }

        private void dataGridViewThucDon_DoubleClick(object sender, EventArgs e)
        {
            btnThemVaoBan.PerformClick();
        }

        private void dataGridViewThucDon_SizeChanged(object sender, EventArgs e)
        {
            dataGridViewThucDon.Columns["NameFood"].Width = (int)((double) 0.7 * dataGridViewThucDon.Width);
            dataGridViewThucDon.Columns["Price"].Width = dataGridViewThucDon.Width - dataGridViewThucDon.Columns["NameFood"].Width-5;
        }
    }
}