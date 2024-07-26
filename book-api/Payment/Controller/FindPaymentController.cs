using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Payment.Controller
{
    [Route("api/payment")]
    public class FindPaymentController : ControllerBase
    {

        private readonly FindPaymentService _findPaymentService;

        public FindPaymentController(FindPaymentService findPaymentService)
        {
            _findPaymentService = findPaymentService;
        }


        [HttpGet("find/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _findPaymentService.FindById(id);
            return Ok(result);
        }

        [HttpGet("find-all")]
        public async Task<IActionResult> FindAll()
        {
            var result = await _findPaymentService.FindAll();
            return Ok(result);
        }

    }
}