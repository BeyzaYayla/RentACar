using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        public IDataResult<User> Login(UserForLoginDto userForLoginDto);
        public IResult UserExists(string email);
        public IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
