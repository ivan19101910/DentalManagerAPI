using DentalManagerAPI.DTOs;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceTypeController : ControllerBase
    {
        private IServiceTypeService _serviceTypeService;
        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<ServiceTypeDTO>> GetAll()
        {
            var result = _serviceTypeService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(ServiceTypeDTO patient)
        {
            try
            {
                var result = _serviceTypeService.Create(patient);
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
        public ActionResult<ServiceTypeDTO> Update(ServiceTypeDTO serviceTypeDTO)
        {
            try
            {
                var result = _serviceTypeService.Update(serviceTypeDTO);
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
                _serviceTypeService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}
