using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Book.Controller
{
    [Route("api/book")]
    public class FindBookController : ControllerBase
    {

        private readonly FindBookService _findBookService;

        public FindBookController(FindBookService findBookService)
        {
            _findBookService = findBookService;
        }


        [HttpGet("find/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _findBookService.FindById(id);
            return Ok(result);
        }

        [HttpGet("find-all")]
        public async Task<IActionResult> FindAll()
        {
            var result = await _findBookService.FindAll();
            return Ok(result);
        }
        
    }
}