using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Role
    {
        public bool Сourier { get; set; }

        public bool ContentManager { get; set; }

        public string Name { get; set; }

        public bool Seller { get; set; }

        public bool UserAdmin { get; set; }
    }
}
