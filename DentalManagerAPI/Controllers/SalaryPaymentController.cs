﻿using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaryPaymentController : ControllerBase
    {
        private ISalaryPaymentService _salaryPaymentService;
        public SalaryPaymentController(ISalaryPaymentService salaryPaymentService)
        {
            _salaryPaymentService = salaryPaymentService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<SalaryPaymentDTO>> GetAll()
        {
            var result = _salaryPaymentService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(SalaryPaymentDTO payment)
        {
            try
            {
                var result = _salaryPaymentService.Create(payment);
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
        public ActionResult<SalaryPaymentDTO> UpdateUser(SalaryPaymentDTO salaryPaymentDTO)
        {
            try
            {
                var result = _salaryPaymentService.Update(salaryPaymentDTO);
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
                _salaryPaymentService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}

