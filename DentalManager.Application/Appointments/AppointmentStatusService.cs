using DentalManager.Application.Contracts.Appointments;
using DentalManager.Domain.Appointments;
using AutoMapper;

namespace DentalManager.Application.Appointments;

public sealed class AppointmentStatusService : IAppointmentStatusService
{
    private readonly IAppointmentStatusRepository _appointmentStatusRepository;

    private readonly IMapper _mapper;

    public AppointmentStatusService(IAppointmentStatusRepository appointmentStatusRepository, IMapper mapper)
    {
        _appointmentStatusRepository = appointmentStatusRepository;
        _mapper = mapper;
    }

    public AppointmentStatusDTO GetById(int id)
    {
        var status = _appointmentStatusRepository.GetById(id);
        var mappedStatus = _mapper.Map<AppointmentStatusDTO>(status);

        return mappedStatus;
    }

    public List<AppointmentStatusDTO> GetAll()
    {
        var statuses = _appointmentStatusRepository.GetAll();
        var mappedList = _mapper.Map<List<AppointmentStatus>, List<AppointmentStatusDTO>>(statuses.ToList());

        return mappedList;
    }

    public int Create(AppointmentStatusDTO status, CancellationToken cancellationToken)
    {
        var mappedStatus = _mapper.Map<AppointmentStatusDTO, AppointmentStatus>(status);
        var newStatus = _appointmentStatusRepository.Add(mappedStatus, cancellationToken);

        return newStatus.Id;
    }

    public AppointmentStatusDTO Update(AppointmentStatusDTO status, CancellationToken cancellationToken)
    {
        var updateStatus = _mapper.Map<AppointmentStatus>(status);
        var updatedStatus = _appointmentStatusRepository.Update(updateStatus, cancellationToken);
        var updatedStatusDTO = _mapper.Map<AppointmentStatusDTO>(updatedStatus);

        return updatedStatusDTO;
    }

    public void Delete(int id)
    {
        var status = _appointmentStatusRepository.GetById(id);

        if (status != null)
        {
            _appointmentStatusRepository.Delete(id);
        }
    }
}
