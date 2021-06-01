using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            InMemoryCarDal ınMemoryCarDal = new InMemoryCarDal(new InMemoryCarDal());
            ınMemoryCarDal.Add(new Car {Id=6,BrandId=2,ColorId=4,DailyPrice=100,ModelYear=2019,Description="Toyota"});

            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id + " " + item.Description);
            }
            
            Console.ReadLine();

        }
    }
}
