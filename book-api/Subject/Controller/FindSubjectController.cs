using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Subject.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Subject.Controller
{
    [Route("api/subject")]
    public class FindSubjectController : ControllerBase
    {

        private readonly FindSubjectService _findSubjectService;

        public FindSubjectController(FindSubjectService findSubjectService)
        {
            _findSubjectService = findSubjectService;
        }


        [HttpGet("find/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _findSubjectService.FindById(id);
            return Ok(result);
        }

        [HttpGet("find-all")]
        public async Task<IActionResult> FindAll()
        {
            var result = await _findSubjectService.FindAll();
            return Ok(result);
        }

    }
}