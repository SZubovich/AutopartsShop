using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopartsShop.Models
{
    public class DefaultPageModel
    {
        public UserModel User { get; set; }

        public List<string> Categories { get; set; }

        public List<string> AdditionalSections { get; set; }
    }
}
