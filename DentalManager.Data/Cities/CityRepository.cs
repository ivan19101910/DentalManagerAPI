using DentalManager.Domain.Cities;

namespace DentalManager.Data.Cities;

internal sealed class CityRepository : BaseRepository<City>, ICityRepository
{
    public CityRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
