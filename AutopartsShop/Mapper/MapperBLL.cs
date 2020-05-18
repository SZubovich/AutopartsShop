using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutopartsShop.Models;
using BLL.Models;

namespace AutopartsShop.Mapper
{
    public static class MapperBLL
    {
        public static AutopartsShop.Models.UserModel ToView(this BLL.Models.User user)
        {
            return user is null ? null : new UserModel
            {
                Id = user.Id,
                Login = user.Login,
                Password = string.Empty,
                Permissions = user.Role.ToView()
            };
        }

        public static AutopartsShop.Models.PermissionModel ToView(this BLL.Models.Role role)
        {
            return role is null ? null : new PermissionModel
            {
                Admin = role.UserAdmin,
                ContentManager = role.ContentManager,
                Courier = role.Сourier,
                Seller = role.Seller
            };
        }
    }
}
