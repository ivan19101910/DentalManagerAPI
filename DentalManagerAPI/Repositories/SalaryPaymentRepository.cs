using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.Repositories
{
    public class SalaryPaymentRepository : BaseRepository<SalaryPayment>, ISalaryPaymentRepository
    {
        public SalaryPaymentRepository(DentalManagerDBContext context) : base(context)
        {

        }
        public override IQueryable<SalaryPayment> GetAll()
        {
            return base.GetAll().Include(x => x.Worker);
        }
    }
}
