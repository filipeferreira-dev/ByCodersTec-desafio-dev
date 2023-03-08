using Challenge.ApplicationService.Maps;
using Challenge.Domain.Enums;
using Challenge.Domain.Models;
using FluentAssertions;

namespace Challenge.ApplicationService.Test.Maps
{
    [TestFixture]
    public class TransactionMapperTest
    {

        [Test]
        public void ShouldMapToResponse()
        {
            var entity = new Transaction(TransactionTypeEnum.Vendas, DateTime.Now, 100, "123456789", "123456789");

            var response = entity.MapToResponse();

            response.Should().NotBeNull();
            response.Id.Should().Be(entity.Id);
            response.Amount.Should().Be(entity.Amount);
            response.Date.Should().Be(entity.Date);
            response.Type.Should().Be("Vendas");
        }

        [Test]
        public void ShouldMapListToResponse()
        {
            var entities = new List<Transaction>();
            var entity1 = new Transaction(TransactionTypeEnum.Vendas, DateTime.Now, 100, "123456789", "123456789");
            var entity2 = new Transaction(TransactionTypeEnum.Boleto, DateTime.Now, 100, "123456789", "123456789");

            entities.Add(entity1);
            entities.Add(entity2);

            var response = entities.MapToResponse();
            response.Should().NotBeNull();
            response.Should().HaveCount(2);
        }
    }
}
