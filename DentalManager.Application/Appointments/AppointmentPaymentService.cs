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

    public AppointmentPaymentDTO GetById(int id)
    {
        var payment = _appointmentPaymentRepository.GetById(id);
        return _mapper.Map<AppointmentPaymentDTO>(payment);
    }

    public List<AppointmentPaymentDTO> GetAll()
    {
        var payments = _appointmentPaymentRepository.GetAll();
        return _mapper.Map<List<AppointmentPayment>, List<AppointmentPaymentDTO>>(payments.ToList());
    }

    public int Create(AppointmentPaymentDTO payment)
    {
        var mappedPayment = _mapper.Map<AppointmentPaymentDTO, AppointmentPayment>(payment);
        var newPayment = _appointmentPaymentRepository.Add(mappedPayment);
        return newPayment.Id;
    }

    public AppointmentPaymentDTO Update(AppointmentPaymentDTO payment)
    {
        var updatePayment = _mapper.Map<AppointmentPayment>(payment);
        var updatedPayment = _appointmentPaymentRepository.Edit(updatePayment);
        return _mapper.Map<AppointmentPaymentDTO>(updatedPayment);
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
