using DentalManager.Domain.Salaries;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.Data.Salaries;

internal sealed class SalaryPaymentRepository : BaseRepository<SalaryPayment>, ISalaryPaymentRepository
{
    public SalaryPaymentRepository(DentalManagerDBContext context) : base(context)
    {

    }

    public override IQueryable<SalaryPayment> GetAll()
    {
        return base.GetAll()
            .Include(x => x.Worker);
    }
}
