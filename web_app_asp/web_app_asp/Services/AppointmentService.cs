using web_app_asp.Models;
using web_app_asp.Repository;
using System.Collections.Generic;
using System.Linq;
using System;
using web_app_asp.ViewModels;

namespace web_app_asp.Services
{
    public interface IAppointmentService
    {
        IEnumerable<Session> GetAvailableSession(DateTime date);
        IEnumerable<AppointmentType> GetAppointmentTypes();
        void CreateAppointment(ViewModelAppointment appointment);
        IEnumerable<ViewModelAppointment> GetAllAppointments();
        void UpdateAppointmentComments(ViewModelAppointment appointment);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAppointmentTypeRepository _appointmentTypeRepository;
        private readonly ISessionRepository _sessionRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, ISessionRepository sessionRepository, IAppointmentTypeRepository appointmentTypeRepository)
        {
            _appointmentRepository = appointmentRepository;
            _sessionRepository = sessionRepository;
            _appointmentTypeRepository = appointmentTypeRepository;
        }

        public IEnumerable<Session> GetAvailableSession(DateTime date)
        {
            var allSessions = _sessionRepository.GetAll();
            var appointmentsBooked = _appointmentRepository.GetAppointmentsByDate(date);
            return allSessions.Except(appointmentsBooked.Select(ab => ab.Session));
        }

        public IEnumerable<AppointmentType> GetAppointmentTypes()
        {
            return _appointmentTypeRepository.GetAll();
        }

        public void CreateAppointment(ViewModelAppointment appointment)
        {
            var dbAppointment = new Appointment
            {
                UserId = appointment.User.UserId,
                AppointmentTypeId = appointment.AppointmentTypeId,
                SessionId = appointment.SessionId,
                AppointmentDate = appointment.AppointmentDate
            };
            _appointmentRepository.Add(dbAppointment);
        }

        public void UpdateAppointmentComments(ViewModelAppointment appointment)
        {
            var appointmentToUpdate = _appointmentRepository.Get(appointment.AppointmentId);
            appointmentToUpdate.Comments = appointment.Comments;
            _appointmentRepository.SaveChanges();
        }

        public IEnumerable<ViewModelAppointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAllAppointments().Select(a => new ViewModelAppointment
            {
                AppointmentId = a.AppointmentId,
                AppointmentTypeId = a.AppointmentTypeId,
                AppointmentType = a.AppointmentType.Type,
                AppointmentDate = a.AppointmentDate,
                SessionId = a.SessionId,
                Session = a.Session,
                User = a.User,
                Comments = a.Comments
            });
        }
    }
}