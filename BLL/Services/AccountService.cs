using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Mappers;
using DLL.Context;
using DLL.DTO;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class AccountService : FilterService<User>, IValidator<User>
    {
        public void Add(User user)
        {
            Validate(user);

            using (ApplicationContext db = new ApplicationContext())
            {
                if (user.RoleId == 0)
                {
                    user.Role = db.Roles.First(x => x.ContentManager == false && x.Seller == false && x.Сourier == false && x.UserAdmin == false);
                }
                else
                {
                    user.Role = db.Roles.First(x => x.Id == user.RoleId);
                }

                user.Password = HashService.GetHashString(user.Password);

                db.Users.Add(user);
                db.SaveChanges();
                Console.WriteLine("User has been added!");
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Include(x => x.Role).ToList();
                return users;
            }
        }

        public void Modify(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var savedUser = db.Users.FirstOrDefault(x => x.Login.ToUpper() == user.Login.ToUpper());

                if (savedUser != null)
                {
                    savedUser.Password = user.Password;
                    savedUser.Role = user.Role;
                    db.SaveChanges();
                }

                return;
            }
        }

        public BLL.Models.User Login (string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                password = HashService.GetHashString(password);
                var user = db.Users.Include(x => x.Role).FirstOrDefault(x => x.Login == login && x.Password == password);

                if (user != null)
                {
                    user.Password = string.Empty;
                }

                return user.FromDAL();
            }
        }

        public void Remove(User user)
        {
            Validate(user);

            using (ApplicationContext db = new ApplicationContext())
            {
                var savedUser = db.Users.FirstOrDefault(x => x.Login.ToUpper() == user.Login.ToUpper());

                if (savedUser != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }

                return;
            }
        }

        public bool Validate(User user)
        {
            if (user is null)
            {
                return false;
            }

            return true;
        }

        public bool DoesRecordExist(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.FirstOrDefault(x => x.Login.ToUpper() == user.Login.ToUpper());
                return users is null;
            }
        }
    }
}
