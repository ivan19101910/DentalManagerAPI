using AutoMapper;
using DentalManager.Application.Contracts;
using DentalManager.Application.Contracts.Workers;
using DentalManager.Domain.Appointments;
using DentalManager.Domain.Workers;
using DentalManagerAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DentalManager.Application.Workers;

public sealed class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;

    private readonly IAppointmentRepository _appointmentRepository;

    private readonly IMapper _mapper;

    private readonly AppSettings _appSettings;

    public WorkerService(IWorkerRepository workerRepository, IAppointmentRepository appointmentRepository, IMapper mapper, IOptions<AppSettings> appSettings)
    {
        _workerRepository = workerRepository;
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var worker = _workerRepository.GetByEmailAndPassword(model.Login, model.Password);
        var mappedWorker = _mapper.Map<WorkerDTO>(worker);

        if (worker == null) 
            return null;

        var token = generateJwtToken(worker);

        return new AuthenticateResponse(mappedWorker, token);
    }

    public decimal CalculateSalaryByWorkerId(int workerId, int monthNumber, int year)
    {
        var worker = _workerRepository.GetById(workerId);
        var appointments = _appointmentRepository.GetByWorkerId(workerId, monthNumber, year);
        decimal monthlySalary;

        if(worker.Position.BaseRate != 0)
        {
            monthlySalary = worker.Position.BaseRate;
        }
        else
        {
            monthlySalary = appointments.Sum(x => x.TotalSum).GetValueOrDefault();
        }

        return monthlySalary;
    }

    public FullWorkerDTO GetWorkerById(int id)
    {
        var worker = _workerRepository.GetById(id);
        var mappedWorker = _mapper.Map<FullWorkerDTO>(worker);

        return mappedWorker;
    }

    public List<ShowWorkerDTO> GetAll()
    {
        var workers = _workerRepository.GetAll();
        var mappedList = _mapper.Map<List<Worker>, List<ShowWorkerDTO>>(workers.ToList());

        return mappedList;
    }
    public List<FullWorkerDTO> GetWorkersByNameSurname(string name, string surname)
    {
        var workers = _workerRepository.GetByNameSurname(name, surname);
        var mappedList = _mapper.Map<List<Worker>, List<FullWorkerDTO>>(workers.ToList());

        return mappedList;
    }
    public List<FullWorkerDTO> GetWorkersByAddress(string city, string address)
    {
        var workers = _workerRepository.GetByAddress(city, address);
        var mappedList = _mapper.Map<List<Worker>, List<FullWorkerDTO>>(workers.ToList());

        return mappedList;
    }
    public int Create(CreateWorkerDTO worker)
    {
        var mappedWorker = _mapper.Map<CreateWorkerDTO, Worker>(worker);
        var newWorker = _workerRepository.Add(mappedWorker);

        return newWorker.Id;
    }

    public UpdateWorkerDTO Update(UpdateWorkerDTO worker)
    {
        var updateWorker = _mapper.Map<Worker>(worker);
        var updatedWorker = _workerRepository.Edit(updateWorker);
        var updatedWorkerDTO = _mapper.Map<UpdateWorkerDTO>(updatedWorker);

        return updatedWorkerDTO;
    }

    public void Delete(int id)
    {
        var worker = _workerRepository.GetById(id);

        if (worker != null)
        {
            _workerRepository.Delete(id);
        }
    }

    private string generateJwtToken(Worker user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
