namespace DentalManager.Application.Contracts.Offices;

public interface IOfficeService
{
    List<ShowOfficeDTO> GetAll();
    OfficeDTO GetById(int id);
    int Create(CreateOfficeDTO serviceType);
    OfficeDTO Update(CreateOfficeDTO serviceType);
    void Delete(int id);
}
