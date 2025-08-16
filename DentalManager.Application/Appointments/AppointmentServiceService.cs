using DentalManager.Application.Contracts.Appointments;
using DomainAppointmentService = DentalManager.Domain.Appointments.AppointmentService;
using DentalManager.Domain.Appointments;
using AutoMapper;
using System.Linq;

namespace DentalManager.Application.Appointments;

public sealed class AppointmentServiceService : IAppointmentServiceService
{
    private readonly IAppointmentServiceRepository _appointmentServiceRepository;
    private readonly IMapper _mapper;

    public AppointmentServiceService(IAppointmentServiceRepository appointmentServiceRepository, IMapper mapper)
    {
        _appointmentServiceRepository = appointmentServiceRepository;
        _mapper = mapper;
    }

    public List<int> CreateMany(List<AppointmentServiceDTO> appointmentList, int appointmentId)
    {
        List<int> createdIds = new List<int>();
        foreach (var appointment in appointmentList)
        {
            var mappedAppointment = _mapper.Map<AppointmentServiceDTO, DomainAppointmentService>(appointment);
            mappedAppointment.AppointmentId = appointmentId;
            var newAppointment = _appointmentServiceRepository.Add(mappedAppointment);
            createdIds.Add(newAppointment.Id);
        }
        return createdIds;
    }

    public List<AppointmentServiceDTO> UpdateMany(List<AppointmentServiceDTO> appService, int appointmentId)
    {
        var comparer = new AppointmentServiceEqualityComparer();
        var comparerWithoutAmount = new AppointmentServiceEqualityComparerWithoutAmount();
        var appointmentServices = _appointmentServiceRepository.GetByAppointmentId(appointmentId).ToList();
        var updateAppointmentServices = _mapper.Map<List<DomainAppointmentService>>(appService);
        var difference = updateAppointmentServices.Except(appointmentServices, comparer).ToList();
        var forUpdate = difference.Where(x => x.Id != 0).ToList();
        difference = difference.Except(forUpdate, comparer).ToList();
        if (difference.Any())
        {
            CreateMany(_mapper.Map<List<AppointmentServiceDTO>>(difference), appointmentId);
        }
        if (forUpdate.Any())
        {
            foreach (var appointmentService in forUpdate)
            {
                var update = appointmentService;
                _appointmentServiceRepository.Edit(update);
            }
        }
        difference = appointmentServices.Except(updateAppointmentServices, comparer).ToList();
        difference = difference.Except(forUpdate, comparerWithoutAmount).ToList();
        if (difference.Any())
        {
            foreach(var appointmentService in difference)
            {
                _appointmentServiceRepository.Delete(appointmentService.Id);
            }
        }
        return null;
    }

    public void DeleteAllByAppointmentId(int id)
    {
        var appointmentServices = _appointmentServiceRepository.GetByAppointmentId(id).ToList();
        if(appointmentServices != null)
        {
            foreach (var appService in appointmentServices)
            {
                _appointmentServiceRepository.Delete(appService.Id);
            }
        }
    }

    class AppointmentServiceEqualityComparer : IEqualityComparer<DomainAppointmentService>
    {
        public bool Equals(DomainAppointmentService x, DomainAppointmentService y)
        {
            return x.Id == y.Id && 
                x.AppointmentId == y.AppointmentId &&
                x.Amount == y.Amount &&
                x.ServiceId == y.ServiceId;
        }

        public int GetHashCode(DomainAppointmentService obj)
        {
            unchecked
            {
                if (obj == null)
                    return 0;
                int hashCode = obj.Id.GetHashCode();
                hashCode = hashCode * 397 ^ obj.Id.GetHashCode();
                return hashCode;
            }
        }
    }

    class AppointmentServiceEqualityComparerWithoutAmount : IEqualityComparer<DomainAppointmentService>
    {
        public bool Equals(DomainAppointmentService x, DomainAppointmentService y)
        {
            return x.Id == y.Id &&
                x.AppointmentId == y.AppointmentId &&
                x.ServiceId == y.ServiceId;
        }

        public int GetHashCode(DomainAppointmentService obj)
        {
            unchecked
            {
                if (obj == null)
                    return 0;
                int hashCode = obj.Id.GetHashCode();
                hashCode = hashCode * 397 ^ obj.Id.GetHashCode();
                return hashCode;
            }
        }
    }
}
