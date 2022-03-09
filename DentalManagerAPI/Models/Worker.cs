namespace DentalManagerAPI.Models
{
    public class Worker : IEntity<int>
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
        public virtual Office Office { get; set; }
        public virtual Position Position { get; set; }
        public virtual IList<WorkerSchedule>? WorkerSchedules { get; set; }
    }
}
