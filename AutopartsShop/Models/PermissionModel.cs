using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopartsShop.Models
{
    public class PermissionModel
    {
        public bool Admin { get; set; }

        public bool ContantManager { get; set; }

        public bool Courier { get; set; }

        public bool Seller { get; set; }
    }
}
