﻿using DentalManagerAPI.DAL;
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
