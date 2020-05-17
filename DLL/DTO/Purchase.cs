using System;
using System.Collections.Generic;

namespace DLL.DTO
{
    public class Purchase
    {
        public int Id { get; set; }

        public List<Item> Items { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
