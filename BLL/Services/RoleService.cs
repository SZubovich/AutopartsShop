using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Services;
using DLL.Context;
using DLL.DTO;

namespace BLL.Services
{
    public class RoleService : FilterService<Role>, IValidator<Role>
    {
        public void Add(Role role)
        {
            if (Validate(role) || DoesRecordExist(role))
            {
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Roles.Add(role);
                db.SaveChanges();
                Console.WriteLine("Role has been added!");
            }
        }

        public IEnumerable<Role> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Roles.ToList();
                return users;
            }
        }

        public void Modify(Role role)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var savedRole = db.Roles.FirstOrDefault(x => x.Name == role.Name);

                if (savedRole != null)
                {
                    savedRole.ContentManager = role.ContentManager;
                    savedRole.UserAdmin = role.UserAdmin;
                    savedRole.Name = role.Name;
                    savedRole.Seller = role.Seller;
                    savedRole.Сourier = role.Сourier;

                    db.SaveChanges();
                }

                return;
            }
        }

        public void Remove(Role role)
        {
            Validate(role);

            using (ApplicationContext db = new ApplicationContext())
            {
                var savedRole = db.Roles.FirstOrDefault(x => x.Id == role.Id);

                if (savedRole != null)
                {
                    db.Roles.Remove(savedRole);
                    db.SaveChanges();
                }

                return;
            }
        }

        public bool Validate(Role role)
        {
            return role is null;
        }

        public bool DoesRecordExist(Role role)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Roles.FirstOrDefault(x => x.Name == role.Name);
                return !(users is null);
            }
        }
    }
}
