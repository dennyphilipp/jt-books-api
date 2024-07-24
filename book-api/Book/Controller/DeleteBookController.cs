using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Book.Controller
{
    [Route("api/book")]
    public class DeleteBookController : ControllerBase
    {
        private readonly DeleteBookService _deleteBookService;
        public DeleteBookController(DeleteBookService deleteBookService)
        {
            _deleteBookService = deleteBookService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Create(int id)
        {
            await _deleteBookService.Execute(id);
            return Ok();
        }
        
    }
}