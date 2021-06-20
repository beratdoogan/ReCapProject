using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        private EfCarDal efCarDal;

        public EfCarDal(EfCarDal efCarDal)
        {
            this.efCarDal = efCarDal;
        }

        public EfCarDal()
        {
        }

        public void Add(Car entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var addedEntity = rentACarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                rentACarContext.SaveChanges();
            }
        }
        public void Delete(Car entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var deletedEntity = rentACarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rentACarContext.SaveChanges();
            }
        }
        public void Update(Car entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var updatedEntity = rentACarContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                rentACarContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                return rentACarContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                return filter == null ? rentACarContext.Set<Car>().ToList() : rentACarContext.Set<Car>().Where(filter).ToList();
            }
        }


    }
}
