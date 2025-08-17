using DentalManager.Application.Contracts.Cities;
using DentalManager.Domain.Cities;
using AutoMapper;

namespace DentalManager.Application.Cities;

public sealed class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    private readonly IMapper _mapper;

    public CityService(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public CityDTO GetById(int id)
    {
        var city = _cityRepository.GetById(id);
        var mappedCity = _mapper.Map<CityDTO>(city);

        return mappedCity;
    }

    public List<CityDTO> GetAll()
    {
        var cities = _cityRepository.GetAll();
        var mappedList = _mapper.Map<List<City>, List<CityDTO>>(cities.ToList());

        return mappedList;
    }

    public int Create(CityDTO city, CancellationToken cancellationToken)
    {
        var mappedCity = _mapper.Map<CityDTO, City>(city);
        var newCity = _cityRepository.Add(mappedCity, cancellationToken);

        return newCity.Id;
    }

    public CityDTO Update(CityDTO city, CancellationToken cancellationToken)
    {
        var updateCity = _mapper.Map<City>(city);
        var updatedCity = _cityRepository.Update(updateCity, cancellationToken);
        var updatedCityDTO = _mapper.Map<CityDTO>(updatedCity);

        return updatedCityDTO;
    }

    public void Delete(int id)
    {
        var city = _cityRepository.GetById(id);

        if (city != null)
        {
            _cityRepository.Delete(id);
        }
    }
}
