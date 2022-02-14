using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;
using System.Linq;

namespace DentalManagerAPI.Services
{
    public class AppointmentServiceService : IAppointmentServiceService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AppointmentServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<int> CreateMany(List<AppointmentServiceDTO> appointmentList, int appointmentId)
        {
            List<int> createdIds = new List<int>();

            foreach (var appointment in appointmentList)
            {
                var mappedAppointment = _mapper.Map<AppointmentServiceDTO, Models.AppointmentService>(appointment);

                mappedAppointment.AppointmentId = appointmentId;

                var newAppointment = _unitOfWork.AppointmentServiceRepository.Add(mappedAppointment);
                createdIds.Add(newAppointment.Id);
            }


            _unitOfWork.Save();

            return createdIds;
        }

        public List<AppointmentServiceDTO> UpdateMany(List<AppointmentServiceDTO> appService, int appointmentId)
        {
            var comparer = new AppointmentServiceEqualityComparer();
            var comparerWithoutAmount = new AppointmentServiceEqualityComparerWithoutAmount();

            var appointmentServices = _unitOfWork.AppointmentServiceRepository.GetByAppointmentId(appointmentId);
            var updateAppointmentServices = _mapper.Map<List<Models.AppointmentService>>(appService);
            var difference = updateAppointmentServices.Except(appointmentServices, comparer);
            var forUpdate = difference.Where(x => x.Id != 0);
            difference = difference.Except(forUpdate, comparer);
            if (difference.Any())//if difference contains elements means that object was added(changed)//if only amount changed need to update
            {
                CreateMany(_mapper.Map<List<AppointmentServiceDTO>>(difference), appointmentId);
            }
            if (forUpdate.Any())
            {
                foreach (var appointmentService in forUpdate)
                {
                    var update = appointmentService;
                    _unitOfWork.AppointmentServiceRepository.Edit(update);
                }
                _unitOfWork.Save();
            }
            difference = appointmentServices.Except(updateAppointmentServices, comparer);
            difference = difference.Except(forUpdate, comparerWithoutAmount);
            if (difference.Any())//if difference contains elements means that object was deleted
            {
                //delete
                foreach(var appointmentService in difference)
                {
                    _unitOfWork.AppointmentServiceRepository.Delete(appointmentService.Id);
                }
                _unitOfWork.Save();
            }

            return null;
        }

        public void DeleteAllByAppointmentId(int id)
        {
            var appointmentServices = _unitOfWork.AppointmentServiceRepository.GetByAppointmentId(id);
            if(appointmentServices != null)
            {
                foreach (Models.AppointmentService appService in appointmentServices)
                {
                    _unitOfWork.AppointmentServiceRepository.Delete(appService.Id);
                }
                _unitOfWork.Save();
            }
            
        }

        class AppointmentServiceEqualityComparer : IEqualityComparer<Models.AppointmentService>
        {
            public bool Equals(Models.AppointmentService x, Models.AppointmentService y)
            {
                return x.Id == y.Id && 
                    x.AppointmentId == y.AppointmentId &&
                    x.Amount == y.Amount &&
                    x.ServiceId == y.ServiceId;
            }

            public int GetHashCode(Models.AppointmentService obj)
            {
                unchecked
                {
                    if (obj == null)
                        return 0;
                    int hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
            }
        }

        class AppointmentServiceEqualityComparerWithoutAmount : IEqualityComparer<Models.AppointmentService>
        {
            public bool Equals(Models.AppointmentService x, Models.AppointmentService y)
            {
                return x.Id == y.Id &&
                    x.AppointmentId == y.AppointmentId &&
                    x.ServiceId == y.ServiceId;
            }

            public int GetHashCode(Models.AppointmentService obj)
            {
                unchecked
                {
                    if (obj == null)
                        return 0;
                    int hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
            }
        }
    }
}
