using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class DayRepository : BaseRepository<Day>, IDayRepository
    {
        public DayRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
