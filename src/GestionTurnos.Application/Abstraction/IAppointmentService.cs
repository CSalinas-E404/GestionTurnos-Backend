using GestionTurnos.Application.Request;
using GestionTurnos.Application.Response;

namespace GestionTurnos.Application.Abstraction
{
    public interface IAppointmentService
    {
        List<AppointmentResponse> GetAll();
        AppointmentResponse CreateAppointment(AppointmentRequest request);
        AppointmentResponse GetById(Guid id);
        AppointmentResponse UpdateAppointment(Guid id, AppointmentRequest request);
        void DeleteAppointment(Guid id);
        
    }
}