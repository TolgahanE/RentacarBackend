using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (CarContext context = new CarContext())
            {
                var table = from operationClaim in context.OperationClaims
                            join userOperationClaim in context.UserOperationClaims
                                on operationClaim.Id equals userOperationClaim.OperationClaimId
                            where userOperationClaim.UserId == user.Id
                            select new OperationClaim()
                            {
                                Id = operationClaim.Id,
                                Name = operationClaim.Name
                            };
                return table.ToList();
            }
        }
    }
}
