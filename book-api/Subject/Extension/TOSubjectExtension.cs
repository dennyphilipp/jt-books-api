using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Subject.Extension
{
    public static class ToSubjectExtension
    {
        public static Domain.Subject ToSubject(this DTO.SubjectDTO dto)
        {
            return new Domain.Subject{Description = dto.Description};
        }
    }
}