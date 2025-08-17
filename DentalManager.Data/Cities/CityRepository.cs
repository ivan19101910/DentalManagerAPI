using DentalManager.Domain.Cities;

namespace DentalManager.Data.Cities;

internal sealed class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
