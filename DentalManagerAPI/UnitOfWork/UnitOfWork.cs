using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories;
using DentalManagerAPI.Repositories.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IPatientRepository _patientRepository;
        private IWorkerRepository _workerRepository;
        private DentalManagerDBContext _context;

        public UnitOfWork(DentalManagerDBContext context)
        {
            _context = context;

        }

        public IPatientRepository PatientRepository
        {
            get
            {
                return _patientRepository ??= new PatientRepository(_context);
            }
        }

        public IWorkerRepository WorkerRepository
        {
            get
            {
                return _workerRepository ??= new WorkerRepository(_context);
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
