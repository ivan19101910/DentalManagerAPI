using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<CityDTO>> GetAll()
        {
            var result = _cityService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(CityDTO patient)
        {
            try
            {
                var result = _cityService.Create(patient);
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
        public ActionResult<CityDTO> UpdateUser(CityDTO serviceDTO)
        {
            try
            {
                var result = _cityService.Update(serviceDTO);
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
                _cityService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}
