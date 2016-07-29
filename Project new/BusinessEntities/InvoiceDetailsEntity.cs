using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.BusinessEntities
{
    public class InvoiceDetailsEntity
    {
        private int _iD;
        private int _iDInvoice;
        private int _iDFoodMenu;
        private int _total;
        private double _priceTotal;

        public int ID
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

        public int IDInvoice
        {
            get
            {
                return _iDInvoice;
            }

            set
            {
                _iDInvoice = value;
            }
        }

        public int IDFoodMenu
        {
            get
            {
                return _iDFoodMenu;
            }

            set
            {
                _iDFoodMenu = value;
            }
        }

        public int Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
            }
        }

        public double PriceTotal
        {
            get
            {
                return _priceTotal;
            }

            set
            {
                _priceTotal = value;
            }
        }
        public InvoiceDetailsEntity()
        {

        }
        public InvoiceDetailsEntity(int id, int idInvoice, int idFoodMenu, int total, double pricetotal)
        {
            this._iD = id;
            this._iDInvoice = idInvoice;
            this._iDFoodMenu = idFoodMenu;
            this._total = total;
            this._priceTotal = pricetotal;
        }
        public InvoiceDetailsEntity( int idInvoice, int idFoodMenu, int total, double pricetotal)
        {
            this._iDInvoice = idInvoice;
            this._iDFoodMenu = idFoodMenu;
            this._total = total;
            this._priceTotal = pricetotal;
        }
    }
}
