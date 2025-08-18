using AutoMapper;
using DentalManager.Application.Contracts.Salaries;
using DentalManager.Domain.Salaries;

namespace DentalManager.Application.Salaries;

public sealed class SalaryPaymentService : ISalaryPaymentService
{
    private readonly ISalaryPaymentRepository _salaryPaymentRepository;

    private readonly IMapper _mapper;

    public SalaryPaymentService(ISalaryPaymentRepository salaryPaymentRepository, IMapper mapper)
    {
        _salaryPaymentRepository = salaryPaymentRepository;
        _mapper = mapper;
    }

    public SalaryPaymentDto GetById(int id)
    {
        var payment = _salaryPaymentRepository.GetById(id);

        return _mapper.Map<SalaryPaymentDto>(payment);
    }

    public List<SalaryPaymentDto> GetAll()
    {
        var payments = _salaryPaymentRepository.GetAll();

        return _mapper.Map<List<SalaryPayment>, List<SalaryPaymentDto>>(payments.ToList());
    }

    public int Create(CreateSalaryPaymentDto payment, CancellationToken cancellationToken)
    {
        var mappedPayment = _mapper.Map<CreateSalaryPaymentDto, SalaryPayment>(payment);
        var newPayment = _salaryPaymentRepository.Add(mappedPayment, cancellationToken);

        return newPayment.Id;
    }

    public CreateSalaryPaymentDto Update(CreateSalaryPaymentDto payment, CancellationToken cancellationToken)
    {
        var updatePayment = _mapper.Map<SalaryPayment>(payment);
        var updatedPayment = _salaryPaymentRepository.Update(updatePayment, cancellationToken);

        return _mapper.Map<CreateSalaryPaymentDto>(updatedPayment);
    }

    public void Delete(int id)
    {
        var payment = _salaryPaymentRepository.GetById(id);

        if (payment != null)
        {
            _salaryPaymentRepository.Delete(id);
        }
    }
}
