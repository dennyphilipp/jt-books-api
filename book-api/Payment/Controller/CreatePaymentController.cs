using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.DTO;
using book_api.Payment.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Payment.Controller
{
    [Route("api/payment")]
    public class CreatePaymentController : ControllerBase
    {
        private readonly CreatePaymentService _createPaymentService;

        public CreatePaymentController(CreatePaymentService createPaymentService)
        {
            _createPaymentService = createPaymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentDTO dto)
        {
            await _createPaymentService.Execute(dto);
            return Created();
        }
    }
}