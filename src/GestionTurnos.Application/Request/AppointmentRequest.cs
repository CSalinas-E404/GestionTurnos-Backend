using GestionTurnos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionTurnos.Application.Request
{
    public class AppointmentRequest
    {
        public Guid StaffId { get; set; }

        public Guid ClientId { get; set; }

        public Guid ServiceId { get; set; }

        public DateTime Day { get; set; }

        public DateTime StartTime { get; set; }

        public string? Observation { get; set; }

        public PaymentMethod Payment { get; set; }
    }
}
