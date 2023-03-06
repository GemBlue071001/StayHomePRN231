using BusinessLogicLayer.ViewModel;
using DataAccessLayer.Interface;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }


        public User addUser (UserVM userVm)
        {

            CreatePasswordHash(userVm.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var _user = new User()
            {
                Id= Guid.NewGuid(),
                FullName=userVm.FullName,
                Name=userVm.Name,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt
            };
            _userRepository.Insert(_user);
            _userRepository.Save();
            return _user;
        }


        public string Login(UserVM account)
        {
            
            var _account
                = _userRepository.getUserByName(account.Name);


            if (!VerifyPasswordHash(account.Password, _account.PasswordHash, _account.PasswordSalt))
            {
                return null;
            }
            else
            {
                return CreateToken(_account);
            }

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim( "name" , user.Name),
                new Claim("string", "Admin"),
             
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
