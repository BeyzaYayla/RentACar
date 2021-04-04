using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car1 = new Car { CarId = 6, BrandId = 3, ColorId = 2, ModelYear = 2011, DailyPrice = 65000, Description = "Ford Black Car" };
            Car car2 = new Car { CarId = 7, BrandId = 3, ColorId = 4, ModelYear = 2011, DailyPrice = 70000, Description = "Ford Blue Car" };

            carManager.Add(car1);
            carManager.Add(car2);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(carManager.GetById(car1.CarId).Description);
            Console.WriteLine("---------------------------------------------");
            car1.DailyPrice = 100000;

            carManager.Delete(car2);
            carManager.Update(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " " + car.DailyPrice);
            }
        }
    }
}
