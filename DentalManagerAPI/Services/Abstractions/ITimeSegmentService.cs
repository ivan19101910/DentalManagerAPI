using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface ITimeSegmentService
    {
        List<TimeSegmentDTO> GetAll();
        TimeSegmentDTO GetById(int id);
        int Create(TimeSegmentDTO serviceType);
        TimeSegmentDTO Update(TimeSegmentDTO serviceType);
        void Delete(int id);
    }
}
