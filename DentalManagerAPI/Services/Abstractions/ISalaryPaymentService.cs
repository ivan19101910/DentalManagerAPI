using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface ISalaryPaymentService
    {
        List<SalaryPaymentDTO> GetAll();
        SalaryPaymentDTO GetById(int id);
        int Create(SalaryPaymentDTO serviceType);
        SalaryPaymentDTO Update(SalaryPaymentDTO serviceType);
        void Delete(int id);
    }
}
