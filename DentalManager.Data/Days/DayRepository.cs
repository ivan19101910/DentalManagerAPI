using DentalManager.Domain.Days;

namespace DentalManager.Data.Days;

internal sealed class DayRepository : BaseRepository<Day>, IDayRepository
{
    public DayRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
