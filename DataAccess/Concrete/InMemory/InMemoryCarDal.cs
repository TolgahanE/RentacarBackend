using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{BrandId = 1,ColorId = 1,DailyPrice = 500M,Description = "Mercedes",Id = 1,ModelYear ="2010"},
                new Car{BrandId = 2,ColorId = 2,DailyPrice = 400M,Description = "Audi",Id = 2,ModelYear ="2015"},
                new Car{BrandId = 3,ColorId = 2,DailyPrice = 250M,Description = "Wolksvagen",Id = 3,ModelYear = "2005"},
                new Car{BrandId = 4,ColorId = 5,DailyPrice = 350M,Description = "Seat",Id = 4, ModelYear = "2018"}
            };
        }


        public List<Car> GetById(int id)
        {
            return _car.Where(c => c.Id == id).ToList();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c=>c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c=>c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarByBrandIdDto> GetByBrandId(int brandid)
        {
            throw new NotImplementedException();
        }

        public List<CarByColorIdDto> GetByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarByBrandIdDto> GetByBrandId(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarByBrandIdDto> GetByBrandId()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetPCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }


        CarDetailsDto ICarDal.GetCarDetails(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
