using System.Collections.Generic;

namespace DLL.DTO
{
    public class Customer
    {
        public int Id { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Address Address { get; set; }

        public Cart Cart { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}
