using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        // Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi).
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var table = from rental in context.Rentals
                            join car in context.Cars on rental.CarId equals car.Id
                            join customer in context.Customers on rental.CustomerId equals customer.Id
                            join b in context.Brands on car.BrandId equals b.Id
                            join co in context.Colors on car.ColorId equals co.Id
                            select new RentalDetailDto
                            {
                                BrandName = b.Name,
                                RentalId = rental.Id,
                                CarName = car.Description,
                                RentDate = rental.RentDate.Date,
                                ReturnDate = rental.ReturnDate.Date,
                                Color = co.Name,
                                CustomerName = customer.Name
                            };
                return table.ToList();
            }

        }

    }
}
