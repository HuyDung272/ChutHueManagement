using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChutHueManagement.BusinessEntities;
using DevComponents.DotNetBar;

namespace ChutHueManagement.ChutHueManagement
{
    public class Table
    {
        
        private ButtonX _button;
        private List<InvoiceDetailsEntity> _listInvoiceDetail;
        private string _iD;
        private DateTime _tGDen;
        public ButtonX Button
        {
            get
            {
                return _button;
            }

            set
            {
                _button = value;
            }
        }

        public List<InvoiceDetailsEntity> ListInvoiceDetail
        {
            get
            {
                return _listInvoiceDetail;
            }

            set
            {
                _listInvoiceDetail = value;
            }
        }

        public string ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public DateTime TGDen
        {
            get
            {
                return _tGDen;
            }

            set
            {
                _tGDen = value;
            }
        }

        public Table()
        {
            _button = new ButtonX();
            _listInvoiceDetail = new List<InvoiceDetailsEntity>();
        }
        public void CovnertToButton(TableEntity entity, int x, int y, string name)
        {
            _iD = entity.ID.ToString();
            _button.Text = entity.TableName.ToString();
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
        }
    }
}
