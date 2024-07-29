using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Persistence;
using book_api.Subject.DTO;
using book_api.Subject.Service;
using Microsoft.EntityFrameworkCore;

namespace Tests.Subject
{
    public class CreateSubjectServiceTest
    {
        [Fact]
        public async Task CreateSuccess()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateSubjectService(context);

            var dto = new CreateSubjectDTO("Description");

            await service.Execute(dto);

            Assert.Equal(1, context.Subjects.Count());
            Assert.Equal("Description", context.Subjects.Single().Description);
        }


        [Fact]
        public async Task WithOutDescription()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateSubjectService(context);

            var dto = new CreateSubjectDTO("");

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe o campo Descrição.", exception.Message);
        }
    }
}