using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.DTO;
using book_api.Book.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Book.Controller
{
    [Route("api/book")]
    public class CreateBookController : ControllerBase
    {
        private readonly CreateBookService _createBookService;
        public CreateBookController(CreateBookService createBookService)
        {
            _createBookService = createBookService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDTO dto)
        {
            await _createBookService.Execute(dto);
            return Created();
        }
    }
}