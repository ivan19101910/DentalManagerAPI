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

    public OfficeDTO GetById(int id)
    {
        var office = _officeRepository.GetById(id);
        var mappedOffice = _mapper.Map<OfficeDTO>(office);
        return mappedOffice;
    }

    public List<ShowOfficeDTO> GetAll()
    {
        var offices = _officeRepository.GetAll();
        var mappedList = _mapper.Map<List<Office>, List<ShowOfficeDTO>>(offices.ToList());
        return mappedList;
    }

    public int Create(CreateOfficeDTO office)
    {
        var mappedOffice = _mapper.Map<CreateOfficeDTO, Office>(office);
        var newOffice = _officeRepository.Add(mappedOffice);
        return newOffice.Id;
    }

    public OfficeDTO Update(CreateOfficeDTO office)
    {
        var updateOffice = _mapper.Map<Office>(office);
        var updatedOffice = _officeRepository.Edit(updateOffice);
        var updatedOfficeDTO = _mapper.Map<OfficeDTO>(updatedOffice);
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
