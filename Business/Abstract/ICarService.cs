using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        //List<Car> GetById(int Id);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailDto();
        IDataResult<CarDetailsDto> GetCarDetailsDto(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);
        IDataResult<List<Car>> GetByBrandId(int brandid);
        IDataResult<List<CarByBrandIdDto>> GetByBrandIdDto(int brandid);
        IDataResult<List<CarByColorIdDto>> GetByColorIdDto(int colorId);
    }
}
