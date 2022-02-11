using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSegmentController : ControllerBase
    {
        private ITimeSegmentService _timeSegmentService;
        public TimeSegmentController(ITimeSegmentService timeSegmentService)
        {
            _timeSegmentService = timeSegmentService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<TimeSegmentDTO>> GetAll()
        {
            var result = _timeSegmentService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(TimeSegmentDTO timeSegment)
        {
            try
            {
                var result = _timeSegmentService.Create(timeSegment);
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
        public ActionResult<TimeSegmentDTO> Update(TimeSegmentDTO timeSegmentDTO)
        {
            try
            {
                var result = _timeSegmentService.Update(timeSegmentDTO);
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
                _timeSegmentService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}
