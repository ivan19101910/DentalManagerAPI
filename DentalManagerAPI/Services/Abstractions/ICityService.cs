using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface ICityService
    {
        List<CityDTO> GetAll();
        CityDTO GetById(int id);
        int Create(CityDTO serviceType);
        CityDTO Update(CityDTO serviceType);
        void Delete(int id);
    }
}
