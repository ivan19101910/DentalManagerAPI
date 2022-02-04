using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class AppointmentPaymentService : IAppointmentPaymentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OfficeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public OfficeDTO GetById(int id)
        {
            var office = _unitOfWork.OfficeRepository.GetById(id);

            var mappedOffice = _mapper.Map<OfficeDTO>(office);
            return mappedOffice;

        }

        public List<OfficeDTO> GetAll()
        {
            var offices = _unitOfWork.OfficeRepository.GetAll();
            var mappedList = _mapper.Map<List<Office>, List<OfficeDTO>>(offices.ToList());
            return mappedList;
        }

        public int Create(OfficeDTO office)
        {
            var mappedOffice = _mapper.Map<OfficeDTO, Office>(office);

            var newOffice = _unitOfWork.OfficeRepository.Add(mappedOffice);
            _unitOfWork.Save();

            return newOffice.Id;
        }

        public OfficeDTO Update(OfficeDTO office)
        {
            var updateOffice = _mapper.Map<Office>(office);
            var updatedOffice = _unitOfWork.OfficeRepository.Edit(updateOffice);

            _unitOfWork.Save();

            var updatedOfficeDTO = _mapper.Map<OfficeDTO>(updatedOffice);

            return updatedOfficeDTO;
        }

        public void Delete(int id)
        {
            var office = _unitOfWork.OfficeRepository.GetById(id);
            if (office != null)
            {
                _unitOfWork.OfficeRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
