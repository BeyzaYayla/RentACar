using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 10, 7) });
            Console.WriteLine(result.Message);
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("{0} / {1}", rental.CustomerId, rental.RentDate);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Google" });
            customerManager.Add(new Customer { UserId = 3, CompanyName = "İnvivo" });
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + "  " + user.FirstName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { CarName = "Hyundai i20", BrandId = 9, ColorId = 3, ModelYear = 2013, DailyPrice = 200.55m,Description="Available on weekends"});
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
