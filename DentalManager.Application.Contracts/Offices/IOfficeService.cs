namespace DentalManager.Application.Contracts.Offices;

public interface IOfficeService
{
    List<ShowOfficeDto> GetAll();
    OfficeDto GetById(int id);
    int Create(CreateOfficeDto serviceType, CancellationToken cancellationToken);
    OfficeDto Update(CreateOfficeDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
