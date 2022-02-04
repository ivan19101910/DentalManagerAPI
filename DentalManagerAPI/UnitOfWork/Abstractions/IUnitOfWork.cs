using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.UnitOfWork.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        public IPatientRepository PatientRepository { get; }
        public IWorkerRepository WorkerRepository { get; }
        public IServiceTypeRepository ServiceTypeRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public ICityRepository CityRepository { get; }
        public IOfficeRepository OfficeRepository { get; }
        public IAppointmentPaymentRepository AppointmentPaymentRepository { get; }
        public IAppointmentStatusRepository AppointmentStatusRepository { get; }
        void Save();
    }
}
