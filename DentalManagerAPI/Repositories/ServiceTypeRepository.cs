using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class ServiceTypeRepository : BaseRepository<ServiceType>, IServiceTypeRepository
    {
        public ServiceTypeRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
