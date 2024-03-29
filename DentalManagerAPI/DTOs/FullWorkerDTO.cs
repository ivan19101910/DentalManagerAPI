﻿namespace DentalManagerAPI.DTOs
{
    public class FullWorkerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string Address { get; set; }
        public int? PositionId { get; set; }
        public int? OfficeId { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeAddress { get; set; }
        public string PositionName { get; set; }
        public IList<WorkerScheduleByIdDTO> WorkerSchedules { get; set; }
    }
}
