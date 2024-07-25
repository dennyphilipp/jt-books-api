using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Payment.Controller
{
[Route("api/payment")]
public class DeletePaymentController : ControllerBase
{
    private readonly DeletePaymentService _deletePaymentService;
    
    public DeletePaymentController(DeletePaymentService deletePaymentService)
    {
        _deletePaymentService = deletePaymentService;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deletePaymentService.Execute(id);
        return Ok();
    }
}
}