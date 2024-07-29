using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Author.Service;
using book_api.Infrastructure.Exception;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Tests.Author
{
    public class CreateAuthorServiceTests
    {
        [Fact]
        public async Task CreateSuccess()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateAuthorService(context);

            var dto = new CreateAuthorDTO("Name");

            await service.Execute(dto);

            Assert.Equal(1, context.Authors.Count());
            Assert.Equal("Name", context.Authors.Single().Name);
        }

        [Fact]
        public async Task WithOutName()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateAuthorService(context);

            var dto = new CreateAuthorDTO("");

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe o campo Nome.", exception.Message);
        }
    }
}