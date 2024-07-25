using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Payment.Controller
{
    [Route("api/payment-type")]
    public class FindPaymentTypeController : ControllerBase
    {

        private readonly FindPaymentTypeService _findPaymentTypeService;

        public FindPaymentTypeController(FindPaymentTypeService findPaymentTypeService)
        {
            _findPaymentTypeService = findPaymentTypeService;
        }


        [HttpGet("find/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _findPaymentTypeService.FindById(id);
            return Ok(result);
        }

        [HttpGet("find-all")]
        public async Task<IActionResult> FindAll()
        {
            var result = await _findPaymentTypeService.FindAll();
            return Ok(result);
        }

    }
}