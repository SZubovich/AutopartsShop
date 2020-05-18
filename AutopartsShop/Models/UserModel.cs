﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopartsShop.Models
{
    public class UserModel : DefaultPageModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public PermissionModel Permissions { get; set; }
    }
}
