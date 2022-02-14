﻿using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;
        private IAppointmentServiceService _appointmentServiceService;
        
        public AppointmentController(IAppointmentService appointmentService, IAppointmentServiceService appointmentServiceService)
        {
            _appointmentService = appointmentService;
            _appointmentServiceService = appointmentServiceService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<ShortAppointmentDTO>> GetAll()
        {
            var result = _appointmentService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        //[Authorize]
        [HttpGet]
        [Route("getById/{appointmentId}")]
        public ActionResult<FullAppointmentDTO> GetById(int appointmentId)
        {
            var result = _appointmentService.GetById(appointmentId);
            if (result != null)
                return result;
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(CreateAppointmentDTO appointment)
        {
            try
            {
                var result = _appointmentService.Create(appointment);
                if (result != null)
                {
                    //if(appointment.AppointmentServices != null)//Bug on my PC, need to remove?
                        //_appointmentServiceService.CreateMany(appointment.AppointmentServices, result);//Create services to binded appointment
                    return result;
                }
                    
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
        public ActionResult<EditAppointmentDTO> Update(EditAppointmentDTO appointmentDTO)
        {
            try
            {
                var result = _appointmentService.Update(appointmentDTO);
                //_appointmentServiceService.Update()
                if (result.AppointmentServices == null || result.AppointmentServices.Count == 0)
                {
                    _appointmentServiceService.DeleteAllByAppointmentId(result.Id);
                }
                else
                {
                    _appointmentServiceService.UpdateMany(appointmentDTO.AppointmentServices, result.Id);
                }
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
                _appointmentService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}
