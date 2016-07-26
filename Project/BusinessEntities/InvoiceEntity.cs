using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.BusinessEntities
{
    public class InvoiceEntity
    {
        private int _id;
        private string _invoiceCode;
        private int _idTable;
        private DateTime _date;
        private string _node;

        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string InvoiceCode
        {
            get
            {
                return _invoiceCode;
            }

            set
            {
                _invoiceCode = value;
            }
        }

        public int IDTable
        {
            get
            {
                return _idTable;
            }

            set
            {
                _idTable = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public string Node
        {
            get
            {
                return _node;
            }

            set
            {
                _node = value;
            }
        }
        public InvoiceEntity()
        {

        }
        public InvoiceEntity(int id, string invoiceCode, int idTable, DateTime date, string node)
        {
            this._id = id;
            this._invoiceCode = invoiceCode;
            this._idTable = idTable;
            this._date = date;
            this._node = node;
        }
        public InvoiceEntity(string invoiceCode, int idTable, DateTime date, string node)
        {
            this._invoiceCode = invoiceCode;
            this._idTable = idTable;
            this._date = date;
            this._node = node;
        }
    }
}
