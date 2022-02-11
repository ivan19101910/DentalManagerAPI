using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DentalManagerDBContext context) : base(context)
        {

        }
        public override IQueryable<Appointment> GetAll()
        {
            return base.GetAll().Include(p => p.Worker).Include(x => x.Patient).Include(x => x.Status);
        }
    }
}
