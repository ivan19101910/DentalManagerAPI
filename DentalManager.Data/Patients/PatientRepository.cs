using DentalManager.Domain.Patients;

namespace DentalManager.Data.Patients;

internal sealed class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    public PatientRepository(DentalManagerDBContext context) : base(context)
    {
        
    }
    public override Patient GetById(int id)
    {
        return _context.Patients.Where(x => x.Id == id)
            .FirstOrDefault();
    }
}
