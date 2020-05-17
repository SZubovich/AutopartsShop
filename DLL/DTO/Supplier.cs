using System.Collections.Generic;

namespace DLL.DTO
{
    public class Supplier
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public Address Address { get; set; }

        public List<Item> Items { get; set; }
    }
}
