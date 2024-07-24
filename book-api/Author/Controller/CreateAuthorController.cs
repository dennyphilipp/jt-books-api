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
    public class CreateAuthorController : ControllerBase
    {
        private readonly CreateAuthorService _createAuthorService;
        public CreateAuthorController(CreateAuthorService createAuthorService)
        {
            _createAuthorService = createAuthorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDTO dto)
        {
            await _createAuthorService.Execute(dto);
            return Created();
        }
    }

}