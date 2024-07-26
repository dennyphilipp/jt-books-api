using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Book.Controller
{
    [Route("api/book")]
    public class ReportBookController : ControllerBase
    {
        private readonly ReportBookService _reportBookService;

        public ReportBookController(ReportBookService reportBookService)
        {
            _reportBookService = reportBookService;
        }

        [HttpGet("report")]
        public async Task<IActionResult> Report()
        {
            var pdfByte = await _reportBookService.Execute();
            return File(pdfByte, "application/pdf", "Report.pdf");
        }
    }
}