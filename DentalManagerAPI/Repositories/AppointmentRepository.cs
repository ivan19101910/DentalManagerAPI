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
            //return _context.Appointments.Where(x => x.Id == id).Include(x => x.AppointmentServices).ThenInclude(x => x.Service).FirstOrDefault();
            return _context.Appointments
                .Where(x => x.Id == id)
                .Include(x => x.AppointmentServices)
                .ThenInclude(x => x.Service)
                .Include(x => x.Worker)
                .ThenInclude(x => x.Position)
                .Include(x => x.Patient)
                .Include(x => x.Status)
                .FirstOrDefault();
        }
        public IQueryable<Appointment> GetByWorkerId(int id)
        {
            //return _context.Appointments.Where(x => x.Id == id).Include(x => x.AppointmentServices).ThenInclude(x => x.Service).FirstOrDefault();
            return _context.Appointments
                .Where(x => x.WorkerId == id)
                .Include(x => x.AppointmentServices)
                .ThenInclude(x => x.Service)
                .Include(x => x.Worker)
                .ThenInclude(x => x.Position)
                .Include(x => x.Patient)
                .Include(x => x.Status);
        }
        public IQueryable<Appointment> GetByWorkerId(int id, int monthNumber, int year)
        {
            //return _context.Appointments.Where(x => x.Id == id).Include(x => x.AppointmentServices).ThenInclude(x => x.Service).FirstOrDefault();
            return _context.Appointments
                .Where(x => x.WorkerId == id && x.AppointmentDate.Month == monthNumber && x.AppointmentDate.Year == year)
                .Include(x => x.AppointmentServices)
                .ThenInclude(x => x.Service)
                .Include(x => x.Worker)
                .ThenInclude(x => x.Position)
                .Include(x => x.Patient)
                .Include(x => x.Status);
        }
        public IQueryable<Appointment> GetByPatientId(int id)
        {
            //return _context.Appointments.Where(x => x.Id == id).Include(x => x.AppointmentServices).ThenInclude(x => x.Service).FirstOrDefault();
            return _context.Appointments
                .Where(x => x.PatientId == id)
                .Include(x => x.AppointmentServices)
                .ThenInclude(x => x.Service)
                .Include(x => x.Worker)
                .ThenInclude(x => x.Position)
                .Include(x => x.Patient)
                .Include(x => x.Status);
        }
        public IQueryable<Appointment> GetByPhoneNumber(string phoneNumber)
        {
            return _context.Appointments
                .Include(x => x.AppointmentServices)
                .ThenInclude(x => x.Service)
                .Include(x => x.Worker)
                .ThenInclude(x => x.Position)
                .Include(x => x.Patient)
                .Where(x => x.Patient.PhoneNumber == phoneNumber)
                .Include(x => x.Status)
                ;
        }
        public override Appointment Edit(Appointment entity)
        {
            
            _context.Entry(entity).State = EntityState.Modified;
            
            return entity;
        }
    }
}
