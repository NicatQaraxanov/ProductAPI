using DomainModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    public interface ILoginRegister
    {
        Task<bool> Register(UserDto request);

        Task<string> Login(UserDto request);
    }
}
