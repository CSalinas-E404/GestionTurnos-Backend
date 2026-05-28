using GestionTurnos.Application.Abstraction;
using GestionTurnos.Application.Abstraction.Infrastructure;
using GestionTurnos.Application.Mapper;
using GestionTurnos.Application.Request;
using GestionTurnos.Application.Response;

namespace GestionTurnos.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<AppointmentResponse> GetAll()
        {
            var appointments = _appointmentRepository.GetAll();

            return appointments
                .Select(a => a.ToResponse())
                .ToList();
        }

        public AppointmentResponse GetById(Guid id)
        {
            var appointment = _appointmentRepository.GetById(id) 
                ?? throw new Exception("Turno no encontrado.");
            return appointment.ToResponse();
        }

        public AppointmentResponse CreateAppointment(AppointmentRequest request)
        {
            var endTime = request.StartTime.TimeOfDay.Add(TimeSpan.FromHours(1));

            if (_appointmentRepository.ExistsOverlappingAppointment(request.StaffId, request.StartTime.TimeOfDay, endTime))
            {
                throw new Exception("El profesional ya tiene un turno asignado en ese horario.");
            }

            if (_appointmentRepository.ExistsOverlappingAppointmentForClient(request.ClientId, request.StartTime.TimeOfDay, endTime))
            {
                throw new Exception("El cliente ya tiene un turno asignado en ese horario.");
            }

            var appointment = request.ToEntity();
            var appointmentCreated = _appointmentRepository.Add(appointment);

            var fullyLoaded = _appointmentRepository.GetById(appointmentCreated.Id) 
                ?? throw new Exception("Error al cargar el turno creado.");

            return fullyLoaded.ToResponse();
        }

        public AppointmentResponse UpdateAppointment(Guid id, AppointmentRequest request)
        {
            var existing = _appointmentRepository.GetById(id) 
                ?? throw new Exception("Turno no encontrado.");

            var endTime = request.StartTime.TimeOfDay.Add(TimeSpan.FromHours(1));

            if (_appointmentRepository.ExistsOverlappingAppointment(request.StaffId, request.StartTime.TimeOfDay, endTime, id))
            {
                throw new Exception("El profesional ya tiene un turno asignado en ese horario.");
            }

            if (_appointmentRepository.ExistsOverlappingAppointmentForClient(request.ClientId, request.StartTime.TimeOfDay, endTime, id))
            {
                throw new Exception("El cliente ya tiene un turno asignado en ese horario.");
            }

            existing.StaffId = request.StaffId;
            existing.ClientId = request.ClientId;
            existing.ServiceId = request.ServiceId;
            existing.Day = request.Day;
            existing.StartTime = request.StartTime.TimeOfDay;
            existing.EndTime = endTime;
            existing.Observation = request.Observation;
            existing.Payment = request.Payment;

            _appointmentRepository.Update(existing);

            var fullyLoaded = _appointmentRepository.GetById(id) 
                ?? throw new Exception("Error al recargar el turno actualizado.");

            return fullyLoaded.ToResponse();
        }

        public AppointmentResponse UpdateStatus(Guid id, GestionTurnos.Domain.Entities.AppointmentStatus newStatus)
        {
            var existing = _appointmentRepository.GetById(id) 
                ?? throw new Exception("Turno no encontrado.");

            existing.Status = newStatus;
            
            _appointmentRepository.Update(existing);

            var fullyLoaded = _appointmentRepository.GetById(id) 
                ?? throw new Exception("Error al recargar el turno actualizado.");

            return fullyLoaded.ToResponse();
        }

        public void DeleteAppointment(Guid id)
        {
            var existing = _appointmentRepository.GetById(id) 
                ?? throw new Exception("Turno no encontrado.");
            _appointmentRepository.Delete(id);
        }
    }
}