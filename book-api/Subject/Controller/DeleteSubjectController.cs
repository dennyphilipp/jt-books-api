using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Subject.Service;
using Microsoft.AspNetCore.Mvc;

namespace book_api.Subject.Controller
{
    [Route("api/subject")]
    public class DeleteSubjectController : ControllerBase
    {
        private readonly DeleteSubjectService _deleteSubjectService;

        public DeleteSubjectController(DeleteSubjectService deleteSubjectService)
        {
            _deleteSubjectService = deleteSubjectService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteSubjectService.Execute(id);
            return Ok();
        }
    }
}