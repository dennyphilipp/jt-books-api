using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Payment.Controller
{
    [Route("api/payment-type")]
    public class DeletePaymentTypeController : ControllerBase
    {
        private readonly DeletePaymentTypeService _deletePaymentTypeService;

        public DeletePaymentTypeController(DeletePaymentTypeService deletePaymentTypeService)
        {
            _deletePaymentTypeService = deletePaymentTypeService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deletePaymentTypeService.Execute(id);
            return Ok();
        }
    }
}