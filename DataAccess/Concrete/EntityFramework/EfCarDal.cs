using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (CarContext context = new CarContext())
            {
                var table = from ca in context.Cars
                            join co in context.Colors on ca.ColorId equals co.Id
                            join b in context.Brands on ca.BrandId equals b.Id
                            select new CarDetailDto
                            {
                                Id = ca.Id,
                                ModelYear = ca.ModelYear,
                                ColorName = co.Name,
                                BrandName = b.Name,
                                DailyPrice = ca.DailyPrice,
                                CarName = ca.Description,
                            };
                return table.ToList();
            }
        }

        public CarDetailsDto GetCarDetails(int carId)
        {
            using (CarContext context = new CarContext())
            {
                var table = from ca in context.Cars.Where(c=>c.Id==carId)
                    join co in context.Colors on ca.ColorId equals co.Id
                    join b in context.Brands on ca.BrandId equals b.Id
                    select new CarDetailsDto
                    {
                        ModelYear = ca.ModelYear,
                        ColorName = co.Name,
                        BrandName = b.Name,
                        DailyPrice = ca.DailyPrice,
                        CarName = ca.Description,
                    };
                return table.SingleOrDefault();
            }
        }


        public List<CarByBrandIdDto> GetByBrandId(int brandId)
        {
            using (CarContext context = new CarContext())
            {
                var table = from ca in context.Cars.Where(c => c.BrandId == brandId)
                            join co in context.Colors on ca.ColorId equals co.Id
                            join b in context.Brands on ca.BrandId equals b.Id
                            select new CarByBrandIdDto
                            {
                                CarName = ca.Description,
                                ModelYear = ca.ModelYear,
                                ColorName = co.Name,
                                BrandName = b.Name,
                                DailyPrice = ca.DailyPrice,
                            };
                return table.ToList();
            }
        }

        public List<CarByColorIdDto> GetByColorId(int colorId)
        {
            using (CarContext context = new CarContext())
            {
                var table = from car in context.Cars.Where(c => c.ColorId == colorId)
                    join color in context.Colors on car.ColorId equals color.Id
                    join brand in context.Brands on car.BrandId equals brand.Id
                    select new CarByColorIdDto()
                    {
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        CarName = car.Description,
                        BrandName = brand.Name,
                        ColorName = color.Name
                    };
                return table.ToList();
            }
        }

    }
}
