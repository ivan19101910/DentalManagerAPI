using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface ISalaryPaymentService
    {
        List<SalaryPaymentDTO> GetAll();
        SalaryPaymentDTO GetById(int id);
        int Create(CreateSalaryPaymentDTO serviceType);
        CreateSalaryPaymentDTO Update(CreateSalaryPaymentDTO serviceType);
        void Delete(int id);
    }
}
