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
        private string _tableName;
        private DateTime _date;
        private string _note;

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

        public string TableName
        {
            get
            {
                return _tableName;
            }

            set
            {
                _tableName = value;
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

        public string Note
        {
            get
            {
                return _note;
            }

            set
            {
                _note = value;
            }
        }
        public InvoiceEntity()
        {

        }
        public InvoiceEntity(int id, string invoiceCode, string tableName, DateTime date, string note)
        {
            this._id = id;
            this._invoiceCode = invoiceCode;
            this._tableName = tableName;
            this._date = date;
            this._note = note;
        }
        public InvoiceEntity(string invoiceCode, string tableName, DateTime date, string note)
        {
            this._invoiceCode = invoiceCode;
            this._tableName = tableName;
            this._date = date;
            this._note = note;
        }
    }
}
