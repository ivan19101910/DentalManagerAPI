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

    public SalaryPaymentDTO GetById(int id)
    {
        var payment = _salaryPaymentRepository.GetById(id);
        return _mapper.Map<SalaryPaymentDTO>(payment);
    }

    public List<SalaryPaymentDTO> GetAll()
    {
        var payments = _salaryPaymentRepository.GetAll();
        return _mapper.Map<List<SalaryPayment>, List<SalaryPaymentDTO>>(payments.ToList());
    }

    public int Create(CreateSalaryPaymentDTO payment)
    {
        var mappedPayment = _mapper.Map<CreateSalaryPaymentDTO, SalaryPayment>(payment);
        var newPayment = _salaryPaymentRepository.Add(mappedPayment);
        return newPayment.Id;
    }

    public CreateSalaryPaymentDTO Update(CreateSalaryPaymentDTO payment)
    {
        var updatePayment = _mapper.Map<SalaryPayment>(payment);
        var updatedPayment = _salaryPaymentRepository.Edit(updatePayment);
        return _mapper.Map<CreateSalaryPaymentDTO>(updatedPayment);
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
