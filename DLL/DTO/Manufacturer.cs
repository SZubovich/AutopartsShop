using System.Collections.Generic;

namespace DLL.DTO
{
    public class Manufacturer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public List<Item> Items { get; set; }
    }
}
