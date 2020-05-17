namespace DLL.DTO
{
    public class Item
    {
        public int Id { get; set; }

        public string Brand { get; set; }
         
        public int Name { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
         
        public decimal UnitPrice { get; set; }
         
        public int QuantityAvailable { get; set; }
         
        public double Weight { get; set; }

        public string ImagePath { get; set; }
    }
}
