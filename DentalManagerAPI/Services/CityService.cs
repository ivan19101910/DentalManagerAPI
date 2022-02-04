using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class CityService : ICityService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CityDTO GetById(int id)
        {
            var city = _unitOfWork.CityRepository.GetById(id);

            var mappedCity = _mapper.Map<CityDTO>(city);
            return mappedCity;

        }

        public List<CityDTO> GetAll()
        {
            var cities = _unitOfWork.CityRepository.GetAll();
            var mappedList = _mapper.Map<List<City>, List<CityDTO>>(cities.ToList());
            return mappedList;
        }

        public int Create(CityDTO city)
        {
            var mappedCity = _mapper.Map<CityDTO, City>(city);

            var newCity = _unitOfWork.CityRepository.Add(mappedCity);
            _unitOfWork.Save();

            return newCity.Id;
        }

        public CityDTO Update(CityDTO city)
        {
            var updateCity = _mapper.Map<City>(city);
            var updatedCity = _unitOfWork.CityRepository.Edit(updateCity);

            _unitOfWork.Save();

            var updatedCityDTO = _mapper.Map<CityDTO>(updatedCity);

            return updatedCityDTO;
        }

        public void Delete(int id)
        {
            var office = _unitOfWork.CityRepository.GetById(id);
            if (office != null)
            {
                _unitOfWork.CityRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
