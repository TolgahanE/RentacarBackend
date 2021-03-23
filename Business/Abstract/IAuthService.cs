using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegister, string password);
        IDataResult<User> Login(UserForLoginDto userForLogin);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
