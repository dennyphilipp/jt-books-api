using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Author.Controller
{
    [Route("api/author")]
    public class FindAuthorController : ControllerBase
    {

        private readonly FindAuthorService _findAuthorService;

        public FindAuthorController(FindAuthorService findAuthorService)
        {
            _findAuthorService = findAuthorService;
        }


        [HttpGet("find/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _findAuthorService.FindById(id);
            return Ok(result);
        }

        [HttpGet("find-all")]
        public async Task<IActionResult> FindAll()
        {
            var result = await _findAuthorService.FindAll();
            return Ok(result);
        }
        
    }
}