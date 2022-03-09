using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class WorkerScheduleService : IWorkerScheduleService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public WorkerScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public WorkerScheduleDTO GetById(int id)
        {
            var schedule = _unitOfWork.WorkerScheduleRepository.GetById(id);

            return _mapper.Map<WorkerScheduleDTO>(schedule);
        }

        public List<WorkerScheduleDTO> GetAll()
        {
            var schedules = _unitOfWork.WorkerScheduleRepository.GetAll();
            return _mapper.Map<List<WorkerSchedule>, List<WorkerScheduleDTO>>(schedules.ToList());
        }

        public int Create(WorkerScheduleDTO schedule)
        {
            var mappedSchedule = _mapper.Map<WorkerScheduleDTO, WorkerSchedule>(schedule);

            var newSchedule = _unitOfWork.WorkerScheduleRepository.Add(mappedSchedule);
            _unitOfWork.Save();

            return newSchedule.Id;
        }

        public WorkerScheduleDTO Update(WorkerScheduleDTO schedule)
        {
            var updateSchedule = _mapper.Map<WorkerSchedule>(schedule);
            var updatedSchedule = _unitOfWork.WorkerScheduleRepository.Edit(updateSchedule);

            _unitOfWork.Save();

            var updatedScheduleDTO = _mapper.Map<WorkerScheduleDTO>(updatedSchedule);

            return updatedScheduleDTO;
        }

        public void Delete(int id)
        {
            var schedule = _unitOfWork.WorkerScheduleRepository.GetById(id);
            if (schedule != null)
            {
                _unitOfWork.WorkerScheduleRepository.Delete(id);
                _unitOfWork.Save();
            }
        }

        public void DeleteAllByWorkerId(int id)
        {
            var workerSchedules = _unitOfWork.WorkerScheduleRepository.GetByWorkerId(id);
            if (workerSchedules != null)
            {
                foreach (WorkerSchedule workerSchedule in workerSchedules)
                {
                    _unitOfWork.WorkerScheduleRepository.Delete(workerSchedule.Id);
                }
                _unitOfWork.Save();
            }

        }

        public List<int> CreateMany(List<WorkerScheduleDTO> schedulesList, int workerId)
        {
            List<int> createdIds = new List<int>();

            foreach (var schedule in schedulesList)
            {
                var mappedSchedule = _mapper.Map<WorkerScheduleDTO, WorkerSchedule>(schedule);

                mappedSchedule.WorkerId = workerId;

                var newSchedule = _unitOfWork.WorkerScheduleRepository.Add(mappedSchedule);
                createdIds.Add(newSchedule.Id);
            }


            _unitOfWork.Save();

            return createdIds;
        }

        public List<WorkerScheduleDTO> UpdateMany(List<WorkerScheduleDTO> workerSchedules, int workerId)
        {
            var comparer = new WorkerScheduleEqualityComparer();
            //var comparerWithoutAmount = new AppointmentServiceEqualityComparerWithoutAmount();

            var schedules = _unitOfWork.WorkerScheduleRepository.GetByWorkerId(workerId);
            var updateWorkerSchedules = _mapper.Map<List<WorkerSchedule>>(workerSchedules);
            var difference = updateWorkerSchedules.Except(schedules, comparer);
            //var forUpdate = difference.Where(x => x.Id != 0);
            //difference = difference.Except(forUpdate, comparer);
            if (difference.Any())//if difference contains elements means that object was added(changed)//if only amount changed need to update
            {
                CreateMany(_mapper.Map<List<WorkerScheduleDTO>>(difference), workerId);
            }
            //if (forUpdate.Any())
            //{
            //    foreach (var appointmentService in forUpdate)
            //    {
            //        var update = appointmentService;
            //        _unitOfWork.WorkerScheduleRepository.Edit(update);
            //    }
            //    _unitOfWork.Save();
            //}


            difference = schedules.Except(updateWorkerSchedules, comparer);
            //difference = difference.Except(forUpdate, comparer);
            if (difference.Any())//if difference contains elements means that object was deleted
            {
                //delete
                foreach (var workerSchedule in difference)
                {
                    _unitOfWork.WorkerScheduleRepository.Delete(workerSchedule.Id);
                }
                _unitOfWork.Save();
            }

            return null;
        }

        class WorkerScheduleEqualityComparer : IEqualityComparer<WorkerSchedule>
        {
            public bool Equals(WorkerSchedule x, WorkerSchedule y)
            {
                return x.Id == y.Id &&
                    x.ScheduleId == y.ScheduleId &&
                    x.WorkerId == y.WorkerId;
            }

            public int GetHashCode(WorkerSchedule obj)
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

        //class AppointmentServiceEqualityComparerWithoutAmount : IEqualityComparer<Models.AppointmentService>
        //{
        //    public bool Equals(Models.AppointmentService x, Models.AppointmentService y)
        //    {
        //        return x.Id == y.Id &&
        //            x.AppointmentId == y.AppointmentId &&
        //            x.ServiceId == y.ServiceId;
        //    }

        //    public int GetHashCode(Models.AppointmentService obj)
        //    {
        //        unchecked
        //        {
        //            if (obj == null)
        //                return 0;
        //            int hashCode = obj.Id.GetHashCode();
        //            hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
        //            return hashCode;
        //        }
        //    }
        //}
    }
}
