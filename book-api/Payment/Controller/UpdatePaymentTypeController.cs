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
    public class UpdatePaymentTypeController : ControllerBase
    {
        private readonly UpdatePaymentTypeService _updatePaymentTypeService;

        public UpdatePaymentTypeController(UpdatePaymentTypeService updatePaymentTypeService)
        {
            _updatePaymentTypeService = updatePaymentTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentTypeDTO dto)
        {
            await _updatePaymentTypeService.Execute(dto);
            return Created();
        }
    }
}