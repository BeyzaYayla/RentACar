using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ CarId=1, BrandId=1, ColorId=3, ModelYear=2010, DailyPrice=50000, Description="Honda Red Car"},
                new Car{ CarId=2, BrandId=1, ColorId=1, ModelYear=2008, DailyPrice=45000, Description="Honda Black Car"},
                new Car{ CarId=3, BrandId=2, ColorId=2, ModelYear=2015, DailyPrice=120000, Description="Mercedes White Car"},
                new Car{ CarId=4, BrandId=2, ColorId=2, ModelYear=2017, DailyPrice=140000, Description="Mercedes White Car"},
                new Car{ CarId=5, BrandId=3, ColorId=3, ModelYear=2018, DailyPrice=110000, Description="Ford Red Car"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
