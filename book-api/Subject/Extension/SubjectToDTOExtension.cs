using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Subject.DTO;

namespace book_api.Subject.Extension
{
    public static class SubjectToDTOExtension
    {

        public static SubjectDTO ToDTO(this Domain.Subject subject)
        {
            return new SubjectDTO(subject.Id, subject.Description);
        }
    }
}