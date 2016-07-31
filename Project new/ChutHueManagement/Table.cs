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
        private List<InvoiceDetailsEntity> _listInvoiceDetail;
        private string _iD;
        private DateTime _tGDen;
        private bool _isActived;
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

        public bool IsActived
        {
            get
            {
                return _isActived;
            }

            set
            {
                _isActived = value;
            }
        }

        public Table()
        {
            _listInvoiceDetail = new List<InvoiceDetailsEntity>();
        }

    }
}
