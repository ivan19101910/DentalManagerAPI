namespace DentalManager.Application.Contracts.Salaries;

public interface ISalaryPaymentService
{
    List<SalaryPaymentDTO> GetAll();

    SalaryPaymentDTO GetById(int id);

    int Create(CreateSalaryPaymentDTO serviceType, CancellationToken cancellationToken);

    CreateSalaryPaymentDTO Update(CreateSalaryPaymentDTO serviceType, CancellationToken cancellationToken);

    void Delete(int id);
}
