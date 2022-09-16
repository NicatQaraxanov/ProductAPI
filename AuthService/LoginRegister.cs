using DomainModels.DTOs;
using DomainModels.Models;
using Repository.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Services;

namespace AuthService
{
    public class LoginRegister : ILoginRegister
    {
        private readonly IRepository<User> _repository;

        public LoginRegister(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Register(UserDto request)
        {
            PasswordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User()
            {
                Username = request.Username,
                PassHash = passwordHash,
                PassSalt = passwordSalt
            };
            
            await _repository.AddAsync(user);

            return true;
        }

        public async Task<string> Login(UserDto request)
        {
            var user = _repository.GetByUsername(request.Username);
            if (user == null)
            {
                throw new Exception("Username or password is wrong");
            }

            if (!PasswordService.VerifyPasswordHash(request.Password, user.PassHash, user.PassSalt))
            {
                throw new Exception("Username or password is wrong");
            }

            string token = JWTTokenService.CreateToken(user);

            return token;
        }
    }
}
