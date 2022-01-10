using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app_asp.Services;
using web_app_asp.ViewModels;

namespace web_app_asp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult GetAvailableSessions(DateTime appointmentDate)
        {
            var date = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day);
            return Ok(_appointmentService.GetAvailableSession(date));
        }

        [HttpGet]
        public IActionResult GetAppointmentTypes()
        {
            return Ok(_appointmentService.GetAppointmentTypes());
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateAppointment(ViewModelAppointment appointment)
        {
            var date = appointment.AppointmentDate;
            appointment.AppointmentDate = new DateTime(date.Year, date.Month, date.Day);
            var availableSessions = _appointmentService.GetAvailableSession(appointment.AppointmentDate);

            // SQLite utilizes unique index to prevent duplicates. This would otherwise prevent double bookings.
            if (availableSessions.Select(x => x.SessionId).Contains(appointment.SessionId))
            {
                dynamic user = HttpContext.Items["User"];
                appointment.User = user;
                _appointmentService.CreateAppointment(appointment);
                return Ok(new { message = "Appointment successfully submitted!" });
            }

            return BadRequest(new { message = "An appointment is already booked for this time." });
        }

        [StaffAuthorize]
        [HttpPost]
        public IActionResult UpdateAppointmentComments(ViewModelAppointment appointment)
        {
            _appointmentService.UpdateAppointmentComments(appointment);
            return Ok(new { message = "Appointment successfully updated!" });
        }


        [StaffAuthorize]
        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            return Ok(_appointmentService.GetAllAppointments());
        }
    }
}
