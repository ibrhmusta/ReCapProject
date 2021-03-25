using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //RentalTest();
            //UserAndCustomerTest();

            
            
        }

        private static void UserAndCustomerTest()
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //User user = new User { UserName = "Narily", UserLastName = "Scanf", UserEmail = "narilyscanf@outlook.com", UserPassword = "narilyscanf" };
            ////userManager.Add(user);

            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { UserID = (userManager.Get(user).Data.UserID), CompanyName = "Chance" });

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var results in result.Message)
            {
                Console.WriteLine(result.Message);
            }

            //rentalManager.Add(new Rental { CarID = 12, CustomerID = 4, RentDate = new DateTime(2021, 02, 12), ReturnDate = new DateTime(2021, 02, 13) });

            //Console.WriteLine();
            //foreach (var results in result.Data)
            //{
            //    Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}",
            //        results.RentalID, results.CarName, results.CustomerName, results.CustomerLastName, results.CompanyName, results.RentDate, results.ReturnDate);
            //}

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("BrandName: {0}  BrandModel: {1}",brand.BrandName, brand.BrandModel);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("CarID: {0}\nBrandName: {1}\nBrandModel: {2}\nColorName: {3}\nDailyPrice: {4}\nDescription: {5}\n",
                    car.CarID, car.BrandName, car.BrandModel, car.ColorName, car.DailyPrice, car.Description);
            }

        }
    }
}
