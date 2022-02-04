using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class OfficeRepository : BaseRepository<Office>, IOfficeRepository
    {
        public OfficeRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
