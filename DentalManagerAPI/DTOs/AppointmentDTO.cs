﻿using DentalManagerAPI.Models;

namespace DentalManagerAPI.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }
        public TimeSpan? RealEndTime { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int WorkerId { get; set; }
        public int PatientId { get; set; }
        public int StatusId { get; set; }
        public decimal? TotalSum { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual AppointmentStatus Status { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual List<AppointmentService> AppointmentServices { get; set; }
    }
}
