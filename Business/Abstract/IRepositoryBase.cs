using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Utilities;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IBusinessRepositoryBase<T> where T: class,IEntity,new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> Get();
        IDataResult<T> GetById(int id);
        //IDataResult<List<CarDetailDto>> GetCarDetailDto();
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
