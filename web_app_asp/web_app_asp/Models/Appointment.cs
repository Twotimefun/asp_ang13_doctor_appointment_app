    using System;
using System.Collections;

namespace web_app_asp.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int AppointmentTypeId { get; set; }
        public virtual AppointmentType AppointmentType { get; set; }
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Comments { get; set; }      
    
    }
}