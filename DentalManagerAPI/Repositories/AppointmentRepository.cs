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
        public override Appointment GetById(int id)
        {
            return _context.Appointments.Where(x => x.Id == id).Include(x => x.AppointmentServices).ThenInclude(x => x.Service).FirstOrDefault();
            //return _context.Appointments.Where(x => x.Id == id).FirstOrDefault();
        }
        public override Appointment Edit(Appointment entity)
        {
            
            _context.Entry(entity).State = EntityState.Modified;
            
            return entity;
        }
    }
}
