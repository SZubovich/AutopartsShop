using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using DLL.Context;
using DLL.DTO;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CategoryService : ICRUDService<Category>
    {
        public void Add(Category category)
        {
            if (Validate(category) && DoesRecordExist(category))
            {
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
                Console.WriteLine("Category has been added!");
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var categorys = db.Categories.ToList();
                return categorys;
            }
        }

        public void Modify(Category category)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var savedCategory = db.Categories.FirstOrDefault(x => x.Id == category.Id);

                if (savedCategory != null)
                {
                    savedCategory.Name = category.Name;
                    db.SaveChanges();
                }

                return;
            }
        }

        public void Remove(Category category)
        {
            Validate(category);

            using (ApplicationContext db = new ApplicationContext())
            {
                var savedCategory = db.Categories.FirstOrDefault(x => x.Id == category.Id);

                if (savedCategory != null)
                {
                    db.Categories.Remove(savedCategory);
                    db.SaveChanges();
                }

                return;
            }
        }

        public bool Validate(Category category)
        {
            if (category is null)
            {
                return false;
            }

            return true;
        }

        public bool DoesRecordExist(Category category)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Categories.FirstOrDefault(x => x.Name == category.Name);
                return users is null;
            }
        }
    }
}
