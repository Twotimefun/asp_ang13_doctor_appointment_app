using web_app_asp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using web_app_asp.Persistence;

namespace web_app_asp.Repository
{
    public interface ISessionRepository : IDbRepository<Session>
    {
    }

    public class SessionRepository : DbRepository<Session>, ISessionRepository
    {
        public SessionRepository(DatabaseContext db) : base(db)
        {
        }
    }
}
