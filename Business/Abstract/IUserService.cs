using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
       List<OperationClaim> GetClaims(User user);
       User GetByEmail(string email);
       void Add(User user);
    }
}
