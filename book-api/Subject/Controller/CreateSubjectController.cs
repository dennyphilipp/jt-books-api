using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Subject.DTO;
using book_api.Subject.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Subject.Controller
{
     [Route("api/subject")]
    public class CreateSubjectController : ControllerBase
    {
        private readonly CreateSubjectService _createSubjectService;

        public CreateSubjectController(CreateSubjectService createSubjectService)
        {
            _createSubjectService = createSubjectService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubjectDTO dto)
        {
            await _createSubjectService.Execute(dto);
            return Created();
        }
    }
}