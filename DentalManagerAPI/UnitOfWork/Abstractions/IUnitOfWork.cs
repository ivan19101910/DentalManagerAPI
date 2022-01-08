using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.UnitOfWork.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        public IPatientRepository PatientRepository { get; }
        void Save();
    }
}
