using DentalManagerAPI.DTOs;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<ServiceDTO>> GetAll()
        {
            var result = _serviceService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(ServiceDTO patient)
        {
            try
            {
                var result = _serviceService.Create(patient);
                if (result != null)
                    return result;
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<ServiceDTO> UpdateUser(ServiceDTO serviceDTO)
        {
            try
            {
                var result = _serviceService.Update(serviceDTO);
                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<int> Delete(int id)
        {
            try
            {
                _serviceService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}

