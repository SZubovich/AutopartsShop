using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Models;
using BLL.Mappers;
using DLL.Context;
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
                if (user.ToDAL().RoleId == 0)
                {
                    var role = db.Roles.First(x => x.ContentManager == false && x.Seller == false && x.Сourier == false && x.UserAdmin == false);
                    user.Role = role.FromDAL();
                }
                else
                {
                    user.Role = db.Roles.First(x => x.Id == user.ToDAL().RoleId).FromDAL();
                }

                user.Password = HashService.GetHashString(user.Password);

                db.Users.Add(user.ToDAL());
                db.SaveChanges();
                Console.WriteLine("User has been added!");
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Include(x => x.Role).ToList();

                List<User> mapperUsers = new List<User>(users.Count);

                for (int i = 0; i < users.Count; i++)
                {
                    mapperUsers[i] = users[i].FromDAL();
                }

                return mapperUsers;
            }
        }

        public IEnumerable<User> GetByCondition(Func<User, bool> condition)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Include(x => x.Role).ToList();

                List<User> mapperUsers = new List<User>(users.Count);

                foreach (var user in users)
                {
                    mapperUsers.Add(user.FromDAL());
                }

                return mapperUsers.Where(condition).ToList();
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
                    savedUser.Role = user.Role.ToDAL();
                    db.SaveChanges();
                }

                return;
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
                    db.Users.Remove(user.ToDAL());
                    db.SaveChanges();
                }

                return;
            }
        }

        public void Remove(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }

                return;
            }
        }

        public User Login(string login, string password)
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
