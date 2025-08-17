using DentalManager.Domain.Positions;

namespace DentalManager.Data.Positions;

internal sealed class PositionRepository : RepositoryBase<Position>, IPositionRepository
{
    public PositionRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
