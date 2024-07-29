using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.DTO;
using book_api.Book.Service;
using book_api.Infrastructure.Exception;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Tests.Book
{
    public class CreateBookServiceTests
    {
        [Fact]
        public async Task CreateSuccess()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateBookService(context);

            var dto = new CreateBookDTO("Title", "Publischer", 1, "2024", new List<int> { 1, 2 }, new List<int> { 2, 1 });

            await service.Execute(dto);

            Assert.Equal(1, context.Books.Count());
            Assert.Equal("Title", context.Books.Single().Title);
        }

        [Fact]
        public async Task WithOutTitle()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateBookService(context);

            var dto = new CreateBookDTO("", "Publischer", 1, "2024", new List<int> { 1, 2 }, new List<int> { 2, 1 });

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe o Título.", exception.Message);
        }

        [Fact]
        public async Task WithOuPublischer()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateBookService(context);

            var dto = new CreateBookDTO("Title", "", 1, "2024", new List<int> { 1, 2 }, new List<int> { 2, 1 });

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe a Editora.", exception.Message);
        }

        [Fact]
        public async Task WithOuVersion()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateBookService(context);

            var dto = new CreateBookDTO("Title", "Publischer", 0, "2024", new List<int> { 1, 2 }, new List<int> { 2, 1 });

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe a Edição.", exception.Message);
        }

        [Fact]
        public async Task WithOuYear()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateBookService(context);

            var dto = new CreateBookDTO("Title", "Publischer", 1, "", new List<int> { 1, 2 }, new List<int> { 2, 1 });

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe o ano.", exception.Message);
        }

        [Fact]
        public async Task YearThreeDigits()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateBookService(context);

            var dto = new CreateBookDTO("Title", "Publischer", 1, "202", new List<int> { 1, 2 }, new List<int> { 2, 1 });

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe o ano com 4 dígitos.", exception.Message);
        }

        [Fact]
        public async Task WithOutAuthors()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateBookService(context);

            var dto = new CreateBookDTO("Title", "Publischer", 1, "2024", null, new List<int> { 2, 1 });

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Inform os Autores.", exception.Message);
        }

        [Fact]
        public async Task WithOutSubjects()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreateBookService(context);

            var dto = new CreateBookDTO("Title", "Publischer", 1, "2024", new List<int> { 1, 2 }, null);

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Inform os Assuntos.", exception.Message);
        }
    }
}