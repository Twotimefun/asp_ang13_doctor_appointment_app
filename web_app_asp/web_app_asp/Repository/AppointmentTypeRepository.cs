using web_app_asp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using web_app_asp.Persistence;

namespace web_app_asp.Repository
{
    public interface IAppointmentTypeRepository : IDbRepository<AppointmentType>
    {
    }

    public class AppointmentTypeRepository : DbRepository<AppointmentType>, IAppointmentTypeRepository
    {
        public AppointmentTypeRepository(DatabaseContext db) : base(db)
        {
        }
    }
}
