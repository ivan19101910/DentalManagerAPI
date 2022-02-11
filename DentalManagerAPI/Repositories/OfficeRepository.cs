using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.Repositories
{
    public class OfficeRepository : BaseRepository<Office>, IOfficeRepository
    {
        public OfficeRepository(DentalManagerDBContext context) : base(context)
        {

        }
        public override IQueryable<Office> GetAll()
        {
            return base.GetAll().Include(x => x.City);
        }
    }
}
