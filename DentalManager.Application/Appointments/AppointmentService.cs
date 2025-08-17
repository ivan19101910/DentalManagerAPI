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

    public async Task AddService(List<AppointmentServiceDTO> appointmentList, int appointmentId, CancellationToken cancellationToken)
    {
        var appointment = _appointmentRepository.GetById(appointmentId);

        if(appointment == null)
        {
            //TODO: Add NotFoundException or similar exception
            throw new ArgumentException($"Appointment with ID {appointmentId} does not exist.");
        }

        var mappedAppointmentServices = _mapper.Map<List<AppointmentServiceDTO>, List<DomainAppointmentService>>(appointmentList);

        appointment.AddServices(mappedAppointmentServices);
        await _appointmentRepository.Update(appointment, cancellationToken);
    }

    public FullAppointmentDTO GetById(int id)
    {
        var appointment = _appointmentRepository.GetById(id);

        return _mapper.Map<FullAppointmentDTO>(appointment);
    }

    public List<FullAppointmentDTO> GetByWorkerId(int id)
    {
        var appointments = _appointmentRepository.GetByWorkerId(id);

        return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
    }

    public List<FullAppointmentDTO> GetByPatientId(int id)
    {
        var appointments = _appointmentRepository.GetByPatientId(id);

        return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
    }
    public List<FullAppointmentDTO> GetByPhoneNumber(string phoneNumber)
    {
        var appointments = _appointmentRepository.GetByPhoneNumber(phoneNumber);

        return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
    }

    public List<ShortAppointmentDTO> GetAll()
    {
        var appointments = _appointmentRepository.GetAll();

        return _mapper.Map<List<Appointment>, List<ShortAppointmentDTO>>(appointments.ToList());
    }

    public int Create(CreateAppointmentDTO appointment, CancellationToken cancellationToken)
    {
        var mappedAppointment = _mapper.Map<CreateAppointmentDTO, Appointment>(appointment);
        var newAppointment = _appointmentRepository.Add(mappedAppointment, cancellationToken);

        return newAppointment.Id;
    }

    public EditAppointmentDTO Update(EditAppointmentDTO appointment, CancellationToken cancellationToken)
    {
        var updateAppointment = _mapper.Map<Appointment>(appointment);
        var updatedAppointment = _appointmentRepository.Update(updateAppointment, cancellationToken);

        return _mapper.Map<EditAppointmentDTO>(updatedAppointment);
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
