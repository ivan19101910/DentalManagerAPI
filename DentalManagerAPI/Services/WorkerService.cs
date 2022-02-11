using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DentalManagerAPI.Services
{
    public class WorkerService : IWorkerService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public WorkerService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            var worker = _unitOfWork.WorkerRepository.GetByEmailAndPassword(model.Login, model.Password);
            // return null if user not found
            if (worker == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(worker);

            return new AuthenticateResponse(worker, token);
        }

        public FullWorkerDTO GetWorkerById(int id)
        {
            var worker = _unitOfWork.WorkerRepository.GetById(id);

            var mappedWorker = _mapper.Map<FullWorkerDTO>(worker);
            return mappedWorker;

        }

        public List<ShowWorkerDTO> GetAll()
        {
            var workers = _unitOfWork.WorkerRepository.GetAll();
            var mappedList = _mapper.Map<List<Worker>, List<ShowWorkerDTO>>(workers.ToList());
            return mappedList;
        }

        public int Create(CreateWorkerDTO worker)
        {
            var mappedWorker = _mapper.Map<CreateWorkerDTO, Worker>(worker);

            var newWorker = _unitOfWork.WorkerRepository.Add(mappedWorker);
            _unitOfWork.Save();

            return newWorker.Id;
        }

        public UpdateWorkerDTO Update(UpdateWorkerDTO worker)
        {
            var updateWorker = _mapper.Map<Worker>(worker);
            var updatedWorker = _unitOfWork.WorkerRepository.Edit(updateWorker);

            _unitOfWork.Save();

            var updatedWorkerDTO = _mapper.Map<UpdateWorkerDTO>(updatedWorker);

            return updatedWorkerDTO;
        }

        public void Delete(int id)
        {
            var worker = _unitOfWork.WorkerRepository.GetById(id);
            if (worker != null)
            {
                _unitOfWork.WorkerRepository.Delete(id);
                _unitOfWork.Save();
            }
        }

        private string generateJwtToken(Worker user)
        {
            // generate token that is valid for 7 days
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
}
