using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Author.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Author.Controller
{
    [Route("api/author")]
    public class UpdateAuthorController : ControllerBase
    {
        private readonly UpdateAuthorService _updateAuthorService;
        public UpdateAuthorController(UpdateAuthorService updateAuthorService)
        {
            _updateAuthorService = updateAuthorService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpadteAuthorDTO dto)
        {
            await _updateAuthorService.Execute(dto);
            return Ok();
        }
    }
}