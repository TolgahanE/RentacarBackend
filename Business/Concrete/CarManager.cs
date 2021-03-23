using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [CacheAspect()]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            var a = _carDal.GetById(c => c.Id == id);
            if (a == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            return new SuccessDataResult<Car>(a, true, "Ürün Getirildi.");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDto()
        {
            var a = _carDal.GetCarDetail();
            if (DateTime.Now.Hour != 14)
            {
                return new SuccessDataResult<List<CarDetailDto>>(a, "Getirildi..");
            }
            else
            {
                return new ErrorDataResult<List<CarDetailDto>>("Sistem Bakımda.");
            }
        }

        public IDataResult<CarDetailsDto> GetCarDetailsDto(int carId)
        {
            var a = _carDal.GetCarDetails(carId);
            if (a != null)
            {
                return new SuccessDataResult<CarDetailsDto>(a, true,"Araç Getirildi.");
            }
            else
            {
                return new ErrorDataResult<CarDetailsDto>("Araç Bulunamadı.");
            }
        }

        [CacheAspect()]
        //[SecuredOperation("car.list,admin")]
        public IDataResult<List<Car>> GetAll()
        {

            if (DateTime.Now.Hour == 14)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(), false, Messages.MaintanenceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), true, Messages.GetAll);
            }
        }

        public IDataResult<Car> Get()
        {
            var a = _carDal.Get(c => c.Id == 5);
            return new SuccessDataResult<Car>(a, true);
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            // Bir markadan en fazla 10 araç olabilir.
            // Aynı isimli araba olamaz
            IResult result = BusinessRules.Run(CheckBrandCapacity(car.BrandId), CheckCarDescription(car.Description), CheckBrandCategoryCount());
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetByBrandId(int brandid)
        {
            var getbyBrandId = _carDal.GetAll(c => c.BrandId == brandid);
            return new SuccessDataResult<List<Car>>(getbyBrandId, true, Messages.GetAll);
        }


        public IDataResult<List<CarByBrandIdDto>> GetByBrandIdDto(int brandId)
        {
            var getByBrandIdDto = _carDal.GetByBrandId(brandId);

            if (getByBrandIdDto.Count > 0)
            {
                return new SuccessDataResult<List<CarByBrandIdDto>>(getByBrandIdDto, true, Messages.GetAll);
            }
            else
            {
                return new ErrorDataResult<List<CarByBrandIdDto>>(Messages.CarNotFound);
            }



        }

        public IDataResult<List<CarByColorIdDto>> GetByColorIdDto(int colorId)
        {
            var getByColorIdDto = _carDal.GetByColorId(colorId);
            if (getByColorIdDto.Count > 0)
            {
                return new SuccessDataResult<List<CarByColorIdDto>>(getByColorIdDto, true, Messages.GetAll);
            }
            else
            {
                return new ErrorDataResult<List<CarByColorIdDto>>(Messages.CarNotFoundByColorId);
            }
        }


        private IResult CheckBrandCapacity(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result <= 10)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.AddError);
            }
        }

        private IResult CheckCarDescription(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description).Any();
            if (result)
            {
                return new ErrorResult(Messages.SameNameError);
            }
            return new SuccessResult();
        }

        private IResult CheckBrandCategoryCount()
        {
            var result = _brandService.GetAll().Data.Count();
            if (!(result <= 15))
            {
                return new ErrorResult(Messages.OverCapatiyForBrand);
            }

            return new SuccessResult();
        }
    }

}
