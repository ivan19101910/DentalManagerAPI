using DentalManager.Domain.Offices;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.Data.Offices;

internal sealed class OfficeRepository : BaseRepository<Office>, IOfficeRepository
{
    public OfficeRepository(DentalManagerDBContext context) : base(context)
    {

    }
    public override IQueryable<Office> GetAll()
    {
        return base.GetAll().Include(x => x.City);
    }
}
