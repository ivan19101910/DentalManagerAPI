using DentalManagerAPI.Models;

namespace DentalManagerAPI.Repositories.Abstractions
{
    public interface IServiceRepository : IRepository<Service>
    {
        public IQueryable<Service> GetByServiceType(string serviceType);
    }
}
