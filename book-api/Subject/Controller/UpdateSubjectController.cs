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
    public class UpdateSubjectController : ControllerBase
    {
        private readonly UpdateSubjectService _updateSubjectService;

        public UpdateSubjectController(UpdateSubjectService updateSubjectService)
        {
            _updateSubjectService = updateSubjectService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubjectDTO dto)
        {
            await _updateSubjectService.Execute(dto);
            return Ok();
        }
    }
}