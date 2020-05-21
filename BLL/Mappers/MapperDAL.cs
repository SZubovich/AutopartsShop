using System;
using System.Collections.Generic;
using System.Text;
using BLL.Models;
using DLL.DTO;

namespace BLL.Mappers
{
    public static class MapperDAL
    {
        #region From DAL
        public static Models.User FromDAL(this DLL.DTO.User user)
        { 
            return user is null ? null : new Models.User
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role.FromDAL()
            };
        }

        public static Models.Role FromDAL(this DLL.DTO.Role role)
        {
            return role is null ? null : new Models.Role
            {
                Name = role.Name,
                ContentManager = role.ContentManager,
                Seller = role.Seller,
                UserAdmin = role.UserAdmin,
                Сourier = role.Сourier
            };
        }
        #endregion

        #region To DAL
        public static DLL.DTO.User ToDAL(this Models.User user)
        {
            return user is null ? null : new DLL.DTO.User
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role.ToDAL()
            };
        }

        public static DLL.DTO.Role ToDAL(this Models.Role role)
        {
            return role is null ? null : new DLL.DTO.Role
            {
                Name = role.Name,
                ContentManager = role.ContentManager,
                Seller = role.Seller,
                UserAdmin = role.UserAdmin,
                Сourier = role.Сourier
            };
        }
        #endregion
    }
}
