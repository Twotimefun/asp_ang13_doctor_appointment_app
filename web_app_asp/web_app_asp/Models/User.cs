using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace web_app_asp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }        
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}