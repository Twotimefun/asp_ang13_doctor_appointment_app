using web_app_asp.Models;
using System;

namespace web_app_asp.ViewModels
{
    public class AuthenticateResponse : UserDetails
    {
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token) : base()
        {
            UserId = user.UserId;
            UserType = user.UserType.Type;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Sex = user.Sex;
            DateOfBirth = user.DateOfBirth;
            Token = token;
        }
    }
}