using System;
using System.Collections.Generic;
using System.Linq;
using DLL.Context;
using DLL.DTO;
using BLL.Services;

namespace ConsoleTest
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            //DbInitialize();

            AccountService service = new AccountService();
            var users = service.GetAll();
            RoleService roleService = new RoleService();
            var roles = roleService.GetAll();
            CarBrandService carBrandService = new CarBrandService();
            var cars = carBrandService.GetAll();
            
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Login}, Surname: {user.Password}, Id: {user.Id}, Role: {user.Role.Name}");
            }

            foreach (var role in roles)
            {
                Console.WriteLine($"Name: {role.Name}");
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"Car: {car.Name}");
            }

            service.Login("admin", "admin");

            Console.WriteLine("Click any key to proceed...");
            Console.ReadKey();
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    Role adminRole = new Role { Admin = true };
            //
            //    db.Roles.Add(adminRole);
            //    db.SaveChanges();
            //    Console.WriteLine("Role has been added!");
            //
            //    User admin = new User { Login = "admin", Password = "admin", Role = adminRole };
            //
            //    db.Users.Add(admin);
            //    db.SaveChanges();
            //    Console.WriteLine("User has been added!");
            //
            //    var createdUsers = db.Users.ToList();
            //
            //    var count = createdUsers.Count;
            //
            //    if (count > 0)
            //    {
            //        Console.WriteLine($"login: {createdUsers[0].Login} pass: {createdUsers[0].Password}");
            //    }
            //
            //    Console.ReadKey();
            //}
        }

        private static void DbInitialize()
        {
            Role adminRole = new Role { Name = "Admin", ContentManager = true, UserAdmin = true, Seller = true, Сourier = true };
            Role contentManager = new Role { Name = "ContentManager", ContentManager = true, UserAdmin = false, Seller = false, Сourier = false };
            RoleService roleService = new RoleService();
            roleService.Add(adminRole);
            roleService.Add(contentManager);
            roleService.Add(new Role { Name = "Courier", ContentManager = false, UserAdmin = false, Seller = false, Сourier = true });
            roleService.Add(new Role { Name = "Seller", ContentManager = false, UserAdmin = false, Seller = true, Сourier = false });
            roleService.Add(new Role { Name = "Customer", ContentManager = false, UserAdmin = false, Seller = false, Сourier = false });

            //adminRole.Id = contentManager.Id = 0;

            //RoleService roleService = new RoleService();
            //var adminRole = roleService.GetAll().FirstOrDefault(x => x.UserAdmin == true);
            //var contentManager = roleService.GetAll().FirstOrDefault(x => x.UserAdmin == false);

            User adminUser = new User { Login = "admin", Password = "admin", RoleId = adminRole.Id };
            User contentUser = new User { Login = "content", Password = "content", RoleId = contentManager.Id };
            AccountService accountService = new AccountService();
            accountService.Add(adminUser);
            accountService.Add(contentUser);


            CarBrand renault = new CarBrand { Name = "Ranault", ImagePath = "test1" };
            CarBrand citroen = new CarBrand { Name = "Citroen", ImagePath = "test2" };
            CarBrand peugeot = new CarBrand { Name = "Peugeot", ImagePath = "test3" };
            CarBrand bugatti = new CarBrand { Name = "Bugatti", ImagePath = "test4" };
            CarBrandService carBrandService = new CarBrandService();
            carBrandService.Add(renault);
            carBrandService.Add(citroen);
            carBrandService.Add(peugeot);
            carBrandService.Add(bugatti);

            CarModel logan = new CarModel { Name = "Logan", CarBrandId = renault.Id };
            CarModel stepway = new CarModel { Name = "Stepway", CarBrandId = renault.Id };
            CarModel kaptur = new CarModel { Name = "Kaptur", CarBrandId = renault.Id };
            CarModel koleos = new CarModel { Name = "Koleos", CarBrandId = renault.Id };
            CarModelService carModelService = new CarModelService();
            carModelService.Add(logan);
            carModelService.Add(stepway);
            carModelService.Add(kaptur);
            carModelService.Add(koleos);

            Console.WriteLine("DB has been initialized");
        }
    }
}
