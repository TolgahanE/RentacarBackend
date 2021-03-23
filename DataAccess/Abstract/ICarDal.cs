using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail();
        List<CarByBrandIdDto> GetByBrandId(int brandId);
        List<CarByColorIdDto> GetByColorId(int colorId);
        CarDetailsDto GetCarDetails(int carId);

    }
}
