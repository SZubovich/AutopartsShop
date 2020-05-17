using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using DLL.Context;
using DLL.DTO;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    class ManufacturerService : ICRUDService<Manufacturer>
    {
        public void Add(Manufacturer manufacturer)
        {
            if (Validate(manufacturer) && DoesRecordExist(manufacturer))
            {
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
                Console.WriteLine("Manufacturer has been added!");
            }
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var manufacturers = db.Manufacturers.ToList();
                return manufacturers;
            }
        }

        public void Modify(Manufacturer manufacturer)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var savedManufacturer = db.Manufacturers.FirstOrDefault(x => x.Id == manufacturer.Id);

                if (savedManufacturer != null)
                {
                    savedManufacturer.Name = manufacturer.Name;
                    db.SaveChanges();
                }

                return;
            }
        }

        public void Remove(Manufacturer manufacturer)
        {
            Validate(manufacturer);

            using (ApplicationContext db = new ApplicationContext())
            {
                var savedManufacturer = db.Manufacturers.FirstOrDefault(x => x.Id == manufacturer.Id);

                if (savedManufacturer != null)
                {
                    db.Manufacturers.Remove(savedManufacturer);
                    db.SaveChanges();
                }

                return;
            }
        }

        public bool Validate(Manufacturer manufacturer)
        {
            if (manufacturer is null)
            {
                return false;
            }

            return true;
        }

        public bool DoesRecordExist(Manufacturer manufacturer)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Manufacturers.FirstOrDefault(x => x.Name == manufacturer.Name);
                return users is null;
            }
        }
    }
}
