using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class WorkerService : IWorkerService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public WorkerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public WorkerDTO GetWorkerById(int id)
        {
            var worker = _unitOfWork.WorkerRepository.GetById(id);

            var mappedWorker = _mapper.Map<WorkerDTO>(worker);
            return mappedWorker;

        }

        public List<WorkerDTO> GetAll()
        {
            var workers = _unitOfWork.WorkerRepository.GetAll();
            var mappedList = _mapper.Map<List<Worker>, List<WorkerDTO>>(workers.ToList());
            return mappedList;
        }
    }
}
