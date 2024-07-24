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
    public class UpdateBookController : ControllerBase
    {
        private readonly UpdateBookService _updateBookService;

        public UpdateBookController(UpdateBookService updateBookService)
        {
            _updateBookService = updateBookService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDTO dto)
        {
            await _updateBookService.Execute(dto);
            return Created();
        }
    }
}