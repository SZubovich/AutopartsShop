using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using DLL.Context;
using DLL.DTO;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CarModelService
    {
        public void Add(CarModel carModel)
        {
            if (Validate(carModel) && DoesRecordExist(carModel))
            {
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                if (carModel.CarBrandId == 0)
                {
                    carModel.CarBrand = db.CarBrands.First();
                }
                else
                {
                    carModel.CarBrand = db.CarBrands.First(x => x.Id == carModel.CarBrandId);
                }

                db.CarModels.Add(carModel);
                db.SaveChanges();
                Console.WriteLine("CarModel has been added!");
            }
        }

        public IEnumerable<CarModel> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var carModels = db.CarModels.ToList();
                return carModels;
            }
        }

        public void Modify(CarModel carModel)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var savedCarModel = db.CarModels.FirstOrDefault(x => x.Id == carModel.Id);

                if (savedCarModel != null)
                {
                    savedCarModel.Name = carModel.Name;
                    db.SaveChanges();
                }

                return;
            }
        }

        public void Remove(CarModel carModel)
        {
            Validate(carModel);

            using (ApplicationContext db = new ApplicationContext())
            {
                var savedCarModel = db.CarModels.FirstOrDefault(x => x.Id == carModel.Id);

                if (savedCarModel != null)
                {
                    db.CarModels.Remove(savedCarModel);
                    db.SaveChanges();
                }

                return;
            }
        }

        public bool Validate(CarModel carModel)
        {
            return carModel is null;
        }

        public bool DoesRecordExist(CarModel carModel)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.CarModels.FirstOrDefault(x => x.Name == carModel.Name);
                return users is null;
            }
        }
    }
}
