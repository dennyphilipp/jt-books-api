using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Author.Controller
{
    [Route("api/author")]
    public class DeleteAuthorController : ControllerBase
    {
        private readonly DeleteAuthorService _deleteAuthorService;
        public DeleteAuthorController(DeleteAuthorService deleteAuthorService)
        {
            _deleteAuthorService = deleteAuthorService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteAuthorService.Execute(id);
            return Ok();
        }
    }
}