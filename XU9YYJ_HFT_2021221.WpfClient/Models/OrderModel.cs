using GalaSoft.MvvmLight;
using System;

namespace XU9YYJ_HFT_2021221.WpfClient.Models
{
    public class OrderModel : ObservableObject
    {


        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }
        private int itemId;

        public int ItemId
        {
            get { return itemId; }
            set { Set(ref itemId, value); }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { Set(ref quantity, value); }
        }
        private int unitPrice;

        public int UnitPrice
        {
            get { return unitPrice; }
            set { Set(ref unitPrice, value); }
        }
        private string currency;

        public string Currency
        {
            get { return currency; }
            set { Set(ref currency, value); }
        }
        private string note;

        public string Note
        {
            get { return note; }
            set { Set(ref note, value); }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { Set(ref date, value); }
        }

        private string supplierName;

        public string SupplierName
        {
            get { return supplierName; }
            set { Set(ref supplierName, value); }
        }

        private int supplierId;

        public int SupplierId
        {
            get { return supplierId; }
            set { Set(ref supplierId, value); }
        }
        public OrderModel()
        {

        }

        public OrderModel(int id, int itemId, int quantity, int unitPrice, string currency, string note, DateTime date, string supplierName, int supplierId)
        {
            this.id = id;
            this.itemId = itemId;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
            this.currency = currency;
            this.note = note;
            this.date = date;
            this.supplierName = supplierName;
            this.supplierId = supplierId;
        }
        public OrderModel(OrderModel other)
        {
            id = other.id;
            itemId = other.itemId;
            quantity = other.quantity;
            unitPrice = other.unitPrice;
            currency = other.currency;
            note = other.note;
            date = other.date;
            supplierName = other.supplierName;
            supplierId = other.supplierId;
        }
        public override string ToString()
        {
            return $"Id: {id}, Item ID: {itemId}, Qty: {quantity}, Unit price: {unitPrice}, Currency: {currency}, Note: {note}, Date: {date}, Supplier Name: {supplierName}, Supplier ID: {SupplierId}";
        }
    }
}
