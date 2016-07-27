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

namespace ChutHueManagement.Forms
{
    public partial class FormTable : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormTable()
        {
            InitializeComponent();
        }
        private void FormTable_Load(object sender, EventArgs e)
        {
            LoadTable2();
        }

        void LoadTable2()
        {
            List<TableEntity> list = TablesManager.ConvertToList(TablesManager.GetAll());
            for(int i=0;i<list.Count;i++)
            {
                ButtonX x;
                if(i%3 == 0)
                {
                    x = ConvertToButton(list[i], 5, ((i / 3)*105 +(i/3)*5)+ 15);
                }else if(i%3==1)
                {
                    x = ConvertToButton(list[i], 131+10 ,( (i / 3)*105  + (i/3)*5 )+15);
                }
                else x = ConvertToButton(list[i], 2*131+15, ((i/ 3)*105 + (i / 3) * 5)+ 15);
                x.Click += new EventHandler(Button_Click);
                groupPanel1.Controls.Add(x);
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
                string id = groupPanel1.Controls.ToString();
                ButtonX button = (ButtonX)sender;
                id = button.Name;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
