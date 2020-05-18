using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopartsShop.Models
{
    public class UsersListModel : DefaultPageModel
    {
        public List<UserModel> Users { get; set; }
    }
}
