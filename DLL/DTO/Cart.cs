using System.Collections.Generic;

namespace DLL.DTO
{
    public class Cart
    {
        public int Id { get; set; }

        public List<Item> Items { get; set; }
    }
}
