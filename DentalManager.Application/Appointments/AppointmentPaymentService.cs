using DentalManager.Application.Contracts.Appointments;
using DentalManager.Domain.Appointments;
using AutoMapper;

namespace DentalManager.Application.Appointments;

public sealed class AppointmentPaymentService : IAppointmentPaymentService
{
    private readonly IAppointmentPaymentRepository _appointmentPaymentRepository;

    private readonly IMapper _mapper;

    public AppointmentPaymentService(IAppointmentPaymentRepository appointmentPaymentRepository, IMapper mapper)
    {
        _appointmentPaymentRepository = appointmentPaymentRepository;
        _mapper = mapper;
    }

    public AppointmentPaymentDto GetById(int id)
    {
        var payment = _appointmentPaymentRepository.GetById(id);

        return _mapper.Map<AppointmentPaymentDto>(payment);
    }

    public List<AppointmentPaymentDto> GetAll()
    {
        var payments = _appointmentPaymentRepository.GetAll();

        return _mapper.Map<List<AppointmentPayment>, List<AppointmentPaymentDto>>(payments.ToList());
    }

    public int Create(AppointmentPaymentDto payment, CancellationToken cancellationToken)
    {
        var mappedPayment = _mapper.Map<AppointmentPaymentDto, AppointmentPayment>(payment);
        var newPayment = _appointmentPaymentRepository.Add(mappedPayment, cancellationToken);

        return newPayment.Id;
    }

    public AppointmentPaymentDto Update(AppointmentPaymentDto payment, CancellationToken cancellationToken)
    {
        var updatePayment = _mapper.Map<AppointmentPayment>(payment);
        var updatedPayment = _appointmentPaymentRepository.Update(updatePayment, cancellationToken);

        return _mapper.Map<AppointmentPaymentDto>(updatedPayment);
    }

    public void Delete(int id)
    {
        var payment = _appointmentPaymentRepository.GetById(id);

        if (payment != null)
        {
            _appointmentPaymentRepository.Delete(id);
        }
    }
}
