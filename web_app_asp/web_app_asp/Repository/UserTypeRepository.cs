using web_app_asp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using web_app_asp.Persistence;

namespace web_app_asp.Repository
{
    public interface IUserTypeRepository : IDbRepository<UserType>
    {
        public UserType GetUserType(string userType);
    }

    public class UserTypeRepository : DbRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(DatabaseContext db) : base(db)
        {
        }

        public UserType GetUserType(string userType)
        {
            return Db.UserTypes.SingleOrDefault(ut => ut.Type == userType);
        }
    }
}
