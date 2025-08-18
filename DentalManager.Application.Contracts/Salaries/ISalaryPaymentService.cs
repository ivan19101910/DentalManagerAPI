namespace DentalManager.Application.Contracts.Salaries;

public interface ISalaryPaymentService
{
    List<SalaryPaymentDto> GetAll();

    SalaryPaymentDto GetById(int id);

    int Create(CreateSalaryPaymentDto serviceType, CancellationToken cancellationToken);

    CreateSalaryPaymentDto Update(CreateSalaryPaymentDto serviceType, CancellationToken cancellationToken);

    void Delete(int id);
}
