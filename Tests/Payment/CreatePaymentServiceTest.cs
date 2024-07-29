using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Payment.DTO;
using book_api.Payment.Service;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Tests.Payment
{
    public class CreatePaymentServiceTest
    {
        [Fact]
        public async Task CreateSuccess()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreatePaymentService(context);

            var dto = new CreatePaymentDTO(1, 2, (decimal)3.45);

            await service.Execute(dto);

            Assert.Equal(1, context.Payments.Count());
            Assert.Equal(2, context.Payments.Single().BookId);
            Assert.Equal(1, context.Payments.Single().TypeId);

        }

        [Fact]
        public async Task WithOutPaymentType()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreatePaymentService(context);

            var dto = new CreatePaymentDTO(0, 2, (decimal)3.45);

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe o Tipo de Pagamento.", exception.Message);
        }

        [Fact]
        public async Task WithOutBook()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreatePaymentService(context);

            var dto = new CreatePaymentDTO(1, 0, (decimal)3.45);

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe o Livro.", exception.Message);
        }

        [Fact]
        public async Task WithOutValue()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "db_jt")
                .Options;

            using var context = new Context(options);
            var service = new CreatePaymentService(context);

            var dto = new CreatePaymentDTO(1, 2, 0);

            var exception = await Assert.ThrowsAsync<InvalidFieldException>(() => service.Execute(dto));
            Assert.Equal("Informe o Valor.", exception.Message);
        }
    }
}