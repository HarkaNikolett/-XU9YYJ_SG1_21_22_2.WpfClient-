namespace XU9YYJ_HFT_2021221.WpfClient.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public int VATNumber { get; set; }


        public string Address { get; set; }
        public SupplierModel()
        {

        }
        public SupplierModel(int id, string name, int vat, string address)
        {
            Id = id;
            Name = name;
            VATNumber = vat;
            Address = address;
        }


    }
}
