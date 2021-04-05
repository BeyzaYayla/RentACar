using Business.Concrete;
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
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { BrandId = 3, ColorId = 2, ModelYear = 2011, DailyPrice = 650.00, Description = "B" };
            Car car2 = new Car { BrandId = 3, ColorId = 4, ModelYear = 2011, DailyPrice = 700.50, Description = "BMW 3 Series Touring Red" };

            carManager.Add(car1);
            carManager.Add(car2);

            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
