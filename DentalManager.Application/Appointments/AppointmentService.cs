using AutoMapper;
using DentalManager.Application.Contracts.Appointments;
using DentalManager.Domain.Appointments;
using DomainAppointmentService = DentalManager.Domain.Appointments.AppointmentService;

namespace DentalManager.Application.Appointments;

public sealed class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task AddService(List<AppointmentServiceDto> appointmentList, int appointmentId, CancellationToken cancellationToken)
    {
        var appointment = _appointmentRepository.GetById(appointmentId);

        if(appointment == null)
        {
            //TODO: Add NotFoundException or similar exception
            throw new ArgumentException($"Appointment with ID {appointmentId} does not exist.");
        }

        var mappedAppointmentServices = _mapper.Map<List<AppointmentServiceDto>, List<DomainAppointmentService>>(appointmentList);

        appointment.AddServices(mappedAppointmentServices);
        await _appointmentRepository.Update(appointment, cancellationToken);
    }

    public FullAppointmentDto GetById(int id)
    {
        var appointment = _appointmentRepository.GetById(id);

        return _mapper.Map<FullAppointmentDto>(appointment);
    }

    public List<FullAppointmentDto> GetByWorkerId(int id)
    {
        var appointments = _appointmentRepository.GetByWorkerId(id);

        return _mapper.Map<List<Appointment>, List<FullAppointmentDto>>(appointments.ToList());
    }

    public List<FullAppointmentDto> GetByPatientId(int id)
    {
        var appointments = _appointmentRepository.GetByPatientId(id);

        return _mapper.Map<List<Appointment>, List<FullAppointmentDto>>(appointments.ToList());
    }
    public List<FullAppointmentDto> GetByPhoneNumber(string phoneNumber)
    {
        var appointments = _appointmentRepository.GetByPhoneNumber(phoneNumber);

        return _mapper.Map<List<Appointment>, List<FullAppointmentDto>>(appointments.ToList());
    }

    public List<ShortAppointmentDto> GetAll()
    {
        var appointments = _appointmentRepository.GetAll();

        return _mapper.Map<List<Appointment>, List<ShortAppointmentDto>>(appointments.ToList());
    }

    public int Create(CreateAppointmentDto appointment, CancellationToken cancellationToken)
    {
        var mappedAppointment = _mapper.Map<CreateAppointmentDto, Appointment>(appointment);
        var newAppointment = _appointmentRepository.Add(mappedAppointment, cancellationToken);

        return newAppointment.Id;
    }

    public EditAppointmentDto Update(EditAppointmentDto appointment, CancellationToken cancellationToken)
    {
        var updateAppointment = _mapper.Map<Appointment>(appointment);
        var updatedAppointment = _appointmentRepository.Update(updateAppointment, cancellationToken);

        return _mapper.Map<EditAppointmentDto>(updatedAppointment);
    }

    public void Delete(int id)
    {
        var appointment = _appointmentRepository.GetById(id);

        if (appointment != null)
        {
            _appointmentRepository.Delete(id);
        }
    }
}
