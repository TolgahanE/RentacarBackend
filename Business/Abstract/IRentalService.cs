using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService :IBusinessRepositoryBase<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetailDto();
    }
}
