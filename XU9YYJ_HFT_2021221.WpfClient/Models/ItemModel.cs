namespace XU9YYJ_HFT_2021221.WpfClient.Models
{
    public class ItemModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public int SupplierId { get; set; }
        public ItemModel(int id, string name, string uom, int supid)
        {
            Id = id;
            Name = name;
            UnitOfMeasure = uom;
            SupplierId = supid;
        }
        public ItemModel()
        {

        }
    }
}
