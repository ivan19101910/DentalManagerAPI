using DentalManager.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.Data.Services;

internal sealed class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(DentalManagerDBContext context) : base(context)
    {

    }

    public override IQueryable<Service> GetAll()
    {
        return base.GetAll()
            .Include(p => p.ServiceType);
    }

    public override Service GetById(int id)
    {
        return base.GetAll()
            .Where(x => x.Id == id)
            .Include(x => x.ServiceType)
            .FirstOrDefault();
    }

    public IQueryable<Service> GetByServiceType(string serviceType)
    {
        return _context.Services.Where(x => x.ServiceType.Name == serviceType)
            .Include(x => x.ServiceType);    
    }
}
