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

        public AppointmentPaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AppointmentPaymentDTO GetById(int id)
        {
            var payment = _unitOfWork.AppointmentPaymentRepository.GetById(id);
            return _mapper.Map<AppointmentPaymentDTO>(payment);
        }

        public List<AppointmentPaymentDTO> GetAll()
        {
            var payments = _unitOfWork.AppointmentPaymentRepository.GetAll();
            return _mapper.Map<List<AppointmentPayment>, List<AppointmentPaymentDTO>>(payments.ToList());
        }

        public int Create(AppointmentPaymentDTO payment)
        {
            var mappedPayment = _mapper.Map<AppointmentPaymentDTO, AppointmentPayment>(payment);
            var newPayment = _unitOfWork.AppointmentPaymentRepository.Add(mappedPayment);
            _unitOfWork.Save();

            return newPayment.Id;
        }

        public AppointmentPaymentDTO Update(AppointmentPaymentDTO payment)
        {
            var updatePayment = _mapper.Map<AppointmentPayment>(payment);
            
            var updatedPayment = _unitOfWork.AppointmentPaymentRepository.Edit(updatePayment);

            _unitOfWork.Save();

            return _mapper.Map<AppointmentPaymentDTO>(updatedPayment);
        }

        public void Delete(int id)
        {
            var payment = _unitOfWork.AppointmentPaymentRepository.GetById(id);
            if (payment != null)
            {
                _unitOfWork.AppointmentPaymentRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
