using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using DLL.Context;
using DLL.DTO;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CarBrandService : ICRUDService<CarBrand>
    {
        public void Add(CarBrand carBrand)
        {
            //if (Validate(carBrand) && DoesRecordExist(carBrand))
            //{
            //    return;
            //}

            using (ApplicationContext db = new ApplicationContext())
            {
                db.CarBrands.Add(carBrand);
                db.SaveChanges();
                Console.WriteLine("CarBrand has been added!");
            }
        }

        public IEnumerable<CarBrand> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var carBrands = db.CarBrands.ToList();
                return carBrands;
            }
        }

        public void Modify(CarBrand carBrand)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var savedCarBrand = db.CarBrands.FirstOrDefault(x => x.Id == carBrand.Id);

                if (savedCarBrand != null)
                {
                    savedCarBrand.Name = carBrand.Name;
                    db.SaveChanges();
                }

                return;
            }
        }

        public void Remove(CarBrand carBrand)
        {
            Validate(carBrand);

            using (ApplicationContext db = new ApplicationContext())
            {
                var savedCarBrand = db.CarBrands.FirstOrDefault(x => x.Id == carBrand.Id);

                if (savedCarBrand != null)
                {
                    db.CarBrands.Remove(savedCarBrand);
                    db.SaveChanges();
                }

                return;
            }
        }

        public bool Validate(CarBrand carBrand)
        {
            if (carBrand is null)
            {
                return false;
            }

            return true;
        }

        public bool DoesRecordExist(CarBrand carBrand)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.CarBrands.FirstOrDefault(x => x.Name == carBrand.Name);
                return users is null;
            }
        }
    }
}
