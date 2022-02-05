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
        private IServiceTypeRepository _serviceTypeRepository;
        private IServiceRepository _serviceRepository;
        private ICityRepository _cityRepository;
        private IOfficeRepository _officeRepository;
        private IAppointmentStatusRepository _appointmentStatusRepository;
        private IAppointmentPaymentRepository _appointmentPaymentRepository;
        private IAppointmentRepository _appointmentRepository;
        private ISalaryPaymentRepository _salaryPaymentRepository;
        private IPositionRepository _positionRepository;
        private IDayRepository _dayRepository;
        private ITimeSegmentRepository _timeSegmentRepository;
        private IScheduleRepository _scheduleRepository;

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

        public IServiceTypeRepository ServiceTypeRepository
        {
            get
            {
                return _serviceTypeRepository ??= new ServiceTypeRepository(_context);
            }
        }

        public IServiceRepository ServiceRepository
        {
            get
            {
                return _serviceRepository ??= new ServiceRepository(_context);
            }
        }

        public ICityRepository CityRepository
        {
            get
            {
                return _cityRepository ??= new CityRepository(_context);
            }
        }

        public IOfficeRepository OfficeRepository
        {
            get
            {
                return _officeRepository ??= new OfficeRepository(_context);
            }
        }

        public IAppointmentStatusRepository AppointmentStatusRepository
        {
            get
            {
                return _appointmentStatusRepository ??= new AppointmentStatusRepository(_context);
            }
        }

        public IAppointmentPaymentRepository AppointmentPaymentRepository
        {
            get
            {
                return _appointmentPaymentRepository ??= new AppointmentPaymentRepository(_context);
            }
        }

        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                return _appointmentRepository ??= new AppointmentRepository(_context);
            }
        }

        public IPositionRepository PositionRepository
        {
            get
            {
                return _positionRepository ??= new PositionRepository(_context);
            }
        }

        public ISalaryPaymentRepository SalaryPaymentRepository
        {
            get
            {
                return _salaryPaymentRepository ??= new SalaryPaymentRepository(_context);
            }
        }

        public IDayRepository DayRepository
        {
            get
            {
                return _dayRepository ??= new DayRepository(_context);
            }
        }

        public ITimeSegmentRepository TimeSegmentRepository
        {
            get
            {
                return _timeSegmentRepository ??= new TimeSegmentRepository(_context);
            }
        }

        public IScheduleRepository ScheduleRepository
        {
            get
            {
                return _scheduleRepository ??= new ScheduleRepository(_context);
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
