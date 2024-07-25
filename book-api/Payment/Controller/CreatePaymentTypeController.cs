using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.DTO;
using book_api.Payment.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Payment.Controller
{
    [Route("api/payment-type")]
    public class CreatePaymentTypeController : ControllerBase
    {
        private readonly CreatePaymentTypeService _createPaymentTypeService;

        public CreatePaymentTypeController(CreatePaymentTypeService createPaymentTypeService)
        {
            _createPaymentTypeService = createPaymentTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentTypeDTO dto)
        {
            await _createPaymentTypeService.Execute(dto);
            return Created();
        }
    }
}