using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Services;

public interface IServiceRepository : IRepository<Service>
{
    public IQueryable<Service> GetByServiceType(string serviceType);
}
