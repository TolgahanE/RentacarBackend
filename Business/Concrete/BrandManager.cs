using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),true,Messages.GetAll);
        }

        public IDataResult<Brand> Get()
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.Id == 1), true, "Ürün Getirildi.");
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.GetById(c => c.Id == id), true, "Ürün Getirildi.");
        }

        public IResult Add(Brand brand)
        {
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Brand brand)
        {
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            return new SuccessResult(Messages.Deleted);
        }
    }
}
