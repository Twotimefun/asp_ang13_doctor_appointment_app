using web_app_asp.Models;
using web_app_asp.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using web_app_asp.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using web_app_asp.ViewModels;
using Microsoft.Extensions.Options;

namespace web_app_asp.Services
{
    public interface IUserService
    {
        User GetUserById(int id);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        void RegisterUser(string username, string password, string userType);
        void UpdateUserById(int id, UserDetails details);
        public User GetUserByEmail(string email);
        void DeleteUser(int userId);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository, IUserTypeRepository userTypeRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public void RegisterUser(string username, string password, string userType)
        {
            _userRepository.Add(new User { Email = username, Password = password, UserType = _userTypeRepository.GetUserType(userType) });
        }

        public void UpdateUserById(int id, UserDetails details)     
        {
            var user = GetUserById(id);
            user.FirstName = details.FirstName;
            user.LastName = details.LastName;
            user.DateOfBirth = details.DateOfBirth;
            user.Sex = details.Sex;
            user.PhoneNumber = details.PhoneNumber;
            _userRepository.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Remove(new User { UserId = userId });
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.GetUserByLogin(model.Username, model.Password);

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}