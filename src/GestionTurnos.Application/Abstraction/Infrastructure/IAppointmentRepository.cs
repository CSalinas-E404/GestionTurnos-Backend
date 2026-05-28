using GestionTurnos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionTurnos.Application.Abstraction.Infrastructure
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        List<Appointment> GetAll();
        bool ExistsOverlappingAppointment(
        Guid staffId,
        TimeSpan startTime,
        TimeSpan endTime,
        Guid? excludeAppointmentId = null
        );
        bool ExistsOverlappingAppointmentForClient(
        Guid clientId,
        TimeSpan startTime,
        TimeSpan endTime,
        Guid? excludeAppointmentId = null
        );
    }
}
