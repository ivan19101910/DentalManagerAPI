using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class SalaryPaymentRepository : BaseRepository<SalaryPayment>, ISalaryPaymentRepository
    {
        public SalaryPaymentRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
