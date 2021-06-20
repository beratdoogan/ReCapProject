using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
        }

        public InMemoryCarDal(InMemoryCarDal ınMemoryCarDal)
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2019,DailyPrice=350,Description="Bmw"},
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear=2016,DailyPrice=150,Description="Renault"},
                new Car{Id=3,BrandId=3,ColorId=1,ModelYear=2019,DailyPrice=200,Description="Rang Rover"},
                new Car{Id=4,BrandId=4,ColorId=2,ModelYear=2020,DailyPrice=300,Description="Audi"},
                new Car{Id=5,BrandId=5,ColorId=3,ModelYear=2019,DailyPrice=250,Description="Volvo"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine(car.Description + " Added!");
        }

        public void Delete(Car car)
        {
            var result = _cars.Where(c => c.Id == car.Id).ToList();
            result.Remove(car);
            Console.WriteLine(car.Description + " removed!");
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int ıd)
        {
            return _cars.Where(c=> c.Id == ıd).ToList();
        }

        public void Update(Car car)
        {
            var result = _cars.Where(u => u.Id == car.Id).ToList();
            foreach (var item in result)
            {
                item.BrandId = car.BrandId;
                item.ColorId = car.ColorId;
                item.DailyPrice = car.DailyPrice;
                item.ModelYear = car.ModelYear;
                item.Description = car.Description;
                Console.WriteLine("Updated!");
            }
        }
    }
}
