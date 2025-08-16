using DentalManager.Domain.Positions;

namespace DentalManager.Data.Positions;

internal sealed class PositionRepository : BaseRepository<Position>, IPositionRepository
{
    public PositionRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
