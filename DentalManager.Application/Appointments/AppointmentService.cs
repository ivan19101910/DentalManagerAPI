using DentalManager.Application.Contracts.Appointments;
using DentalManager.Domain.Appointments;
using AutoMapper;

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

    public int Create(CreateAppointmentDTO appointment)
    {
        var mappedAppointment = _mapper.Map<CreateAppointmentDTO, Appointment>(appointment);
        var newAppointment = _appointmentRepository.Add(mappedAppointment);
        return newAppointment.Id;
    }

    public EditAppointmentDTO Update(EditAppointmentDTO appointment)
    {
        var updateAppointment = _mapper.Map<Appointment>(appointment);
        var updatedAppointment = _appointmentRepository.Edit(updateAppointment);
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
