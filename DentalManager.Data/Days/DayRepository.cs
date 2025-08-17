using DentalManager.Domain.Days;

namespace DentalManager.Data.Days;

internal sealed class DayRepository : RepositoryBase<Day>, IDayRepository
{
    public DayRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
