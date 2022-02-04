using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.Repositories
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(DentalManagerDBContext context) : base(context)
        {

        }

        public override IQueryable<Service> GetAll()
        {
            return base.GetAll().Include(p => p.ServiceType);
        }
    }
}
