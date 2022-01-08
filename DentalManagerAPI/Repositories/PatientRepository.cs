using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(DentalManagerDBContext context) : base(context)
        {
            
        }
        public override Patient GetById(int id)
        {
            var result = _context.Patients.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
    }
}
