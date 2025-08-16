using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Patients;

public partial class Patient : IEntity<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
}
