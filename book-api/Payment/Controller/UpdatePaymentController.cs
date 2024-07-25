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
    public class UpdatePaymentController : ControllerBase
    {
        private readonly UpdatePaymentService _updatePaymentService;

        public UpdatePaymentController(UpdatePaymentService updatePaymentService)
        {
            _updatePaymentService = updatePaymentService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentDTO dto)
        {
            await _updatePaymentService.Execute(dto);
            return Ok();
        }
    }
}