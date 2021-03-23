using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        // Kullanıcı Bilgisi ve Rolleri verdik bu sayede.
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
