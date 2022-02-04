using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
