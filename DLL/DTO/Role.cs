using System.Collections.Generic;

namespace DLL.DTO
{
    public class Role
    {
        public int Id { get; set; }

        public bool Сourier { get; set; }

        public bool ContentManager { get; set; }

        public string Name { get; set; }

        public bool Seller { get; set; }

        public bool UserAdmin { get; set; }

        public List<User> Users { get; set; }
    }
}