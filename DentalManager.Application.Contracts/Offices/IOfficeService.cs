namespace DentalManager.Application.Contracts.Offices;

public interface IOfficeService
{
    List<ShowOfficeDTO> GetAll();
    OfficeDTO GetById(int id);
    int Create(CreateOfficeDTO serviceType, CancellationToken cancellationToken);
    OfficeDTO Update(CreateOfficeDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
