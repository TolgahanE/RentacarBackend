using System;
using System.Collections;
using System.Collections.Generic;
using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));
            IColorService colorService = new ColorManager(new EfColorDal());
            IBrandService brandService = new BrandManager(new EfBrandDal());
            IRentalService rentalService = new RentalManager(new EfRentalDal());
            IUserService userService = new UserManager(new EfUserDal());
            ICustomerService customerService = new CustomerManager(new EfCustomerDal());



            //Rental(rentalService);


        }

        private static void Rentala(IRentalService rentalService)
        {
            List<Rental> rentals = new List<Rental>
            {
                new Rental
                {
                    Id = 1, CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 05, 20),
                    ReturnDate = new DateTime(2021, 06, 30)
                },
                new Rental
                {
                    Id = 2, CarId = 2, CustomerId = 2, RentDate = new DateTime(2021, 06, 20),
                    ReturnDate = new DateTime(2021, 07, 30)
                },
                new Rental
                {
                    Id = 3, CarId = 2, CustomerId = 3, RentDate = new DateTime(2021, 03, 20),
                    ReturnDate = new DateTime(2021, 03, 30)
                },
                new Rental
                {
                    Id = 4, CarId = 3, CustomerId = 4, RentDate = new DateTime(2021, 04, 20),
                    ReturnDate = new DateTime(2021, 04, 30)
                },
                new Rental
                {
                    Id = 5, CarId = 5, CustomerId = 5, RentDate = new DateTime(2021, 07, 20),
                    ReturnDate = new DateTime(2021, 07, 30)
                },
            };

            foreach (var rental in rentals)
            {
                Console.WriteLine(rentalService.Add(rental).Message);
            }
        }
    }

}
