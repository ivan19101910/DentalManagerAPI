using DentalManager.Domain.Services;

namespace DentalManager.Data.Services;

internal sealed class ServiceTypeRepository : RepositoryBase<ServiceType>, IServiceTypeRepository
{
    public ServiceTypeRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
