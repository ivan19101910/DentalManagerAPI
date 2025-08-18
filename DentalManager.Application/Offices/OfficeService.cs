using DentalManager.Application.Contracts.Offices;
using DentalManager.Domain.Offices;
using AutoMapper;

namespace DentalManager.Application.Offices;

public sealed class OfficeService : IOfficeService
{
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;

    public OfficeService(IOfficeRepository officeRepository, IMapper mapper)
    {
        _officeRepository = officeRepository;
        _mapper = mapper;
    }

    public OfficeDto GetById(int id)
    {
        var office = _officeRepository.GetById(id);
        var mappedOffice = _mapper.Map<OfficeDto>(office);

        return mappedOffice;
    }

    public List<ShowOfficeDto> GetAll()
    {
        var offices = _officeRepository.GetAll();
        var mappedList = _mapper.Map<List<Office>, List<ShowOfficeDto>>(offices.ToList());

        return mappedList;
    }

    public int Create(CreateOfficeDto office, CancellationToken cancellationToken)
    {
        var mappedOffice = _mapper.Map<CreateOfficeDto, Office>(office);
        var newOffice = _officeRepository.Add(mappedOffice, cancellationToken);

        return newOffice.Id;
    }

    public OfficeDto Update(CreateOfficeDto office, CancellationToken cancellationToken)
    {
        var updateOffice = _mapper.Map<Office>(office);
        var updatedOffice = _officeRepository.Update(updateOffice, cancellationToken);
        var updatedOfficeDTO = _mapper.Map<OfficeDto>(updatedOffice);

        return updatedOfficeDTO;
    }

    public void Delete(int id)
    {
        var office = _officeRepository.GetById(id);

        if (office != null)
        {
            _officeRepository.Delete(id);
        }
    }
}
