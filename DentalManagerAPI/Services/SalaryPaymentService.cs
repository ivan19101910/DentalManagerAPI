using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class SalaryPaymentService : ISalaryPaymentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public SalaryPaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public SalaryPaymentDTO GetById(int id)
        {
            var payment = _unitOfWork.SalaryPaymentRepository.GetById(id);
            return _mapper.Map<SalaryPaymentDTO>(payment);
        }

        public List<SalaryPaymentDTO> GetAll()
        {
            var payments = _unitOfWork.SalaryPaymentRepository.GetAll();
            return _mapper.Map<List<SalaryPayment>, List<SalaryPaymentDTO>>(payments.ToList());
        }

        public int Create(SalaryPaymentDTO payment)
        {
            var mappedPayment = _mapper.Map<SalaryPaymentDTO, SalaryPayment>(payment);

            var newPayment = _unitOfWork.SalaryPaymentRepository.Add(mappedPayment);
            _unitOfWork.Save();

            return newPayment.Id;
        }

        public SalaryPaymentDTO Update(SalaryPaymentDTO payment)
        {
            var updatePayment = _mapper.Map<SalaryPayment>(payment);
            var updatedPayment = _unitOfWork.SalaryPaymentRepository.Edit(updatePayment);

            _unitOfWork.Save();

            return _mapper.Map<SalaryPaymentDTO>(updatedPayment);
        }

        public void Delete(int id)
        {
            var payment = _unitOfWork.SalaryPaymentRepository.GetById(id);
            if (payment != null)
            {
                _unitOfWork.SalaryPaymentRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
