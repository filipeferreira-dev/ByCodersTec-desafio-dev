using Challenge.ApplicationService.Maps;
using Challenge.Domain.Enums;
using Challenge.Domain.Models;
using FluentAssertions;

namespace Challenge.ApplicationService.Test.Maps
{
    [TestFixture]
    public class MerchantMapperTest
    {

        [Test]
        public void ShouldMapToResponse()
        {
            var merchant = new Merchant("Merchant Name", "Merchant Owner");
            var transaction = new Transaction(TransactionTypeEnum.Vendas, DateTime.Now, 100, "123456789", "123456789");
            merchant.AddTransaction(transaction);

            var response = merchant.MapToResponse();

            response.Should().NotBeNull();
            response.Id.Should().Be(merchant.Id);
            response.Balance.Should().Be(merchant.Balance);
            response.Name.Should().Be(merchant.Name);
            response.Owner.Should().Be(merchant.Owner);
            response.Transactions.Should().NotBeNull();
            response.Transactions.Count().Should().Be(merchant.Transactions.Count());
        }

        [Test]
        public void ShouldMapListToResponse()
        {
            var merchants = new List<Merchant>();
            var merchant1 = new Merchant("Merchant Name", "Merchant Owner");
            var transaction1 = new Transaction(TransactionTypeEnum.Vendas, DateTime.Now, 100, "123456789", "123456789");
            merchant1.AddTransaction(transaction1);

            var merchant2 = new Merchant("Merchant Name", "Merchant Owner");
            var transaction2 = new Transaction(TransactionTypeEnum.Vendas, DateTime.Now, 100, "123456789", "123456789");
            merchant2.AddTransaction(transaction2);

            merchants.Add(merchant1);
            merchants.Add(merchant2);

            var response = merchants.MapToResponse();
            response.Should().NotBeNull();
            response.Should().HaveCount(2);
        }
    }
}
