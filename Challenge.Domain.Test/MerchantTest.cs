using Challenge.Domain.Enums;
using Challenge.Domain.Models;
using FluentAssertions;

namespace Challenge.Domain.Test
{
    [TestFixture]
    public class MerchantTest
    {
        [Test]
        public void ShouldCreateMerchantSuccessfully()
        {
            var merchantName = "Merchant Name";
            var merchantOwner = "Merchant Owner";

            var merchant = new Merchant(merchantName, merchantOwner);

            merchant.Should().NotBeNull();
            merchant.Name.Should().Be(merchantName);
            merchant.Owner.Should().Be(merchantOwner);
            merchant.Transactions.Should().HaveCount(0);
            merchant.Balance.Should().Be(0);
        }

        [Test]
        public void ShouldAddTransaction()
        {
            var merchant = new Merchant("Merchant Name", "Merchant Owner");

            var transaction = new Transaction(TransactionTypeEnum.Boleto, DateTime.Now, 100, "123456789", "123456789");

            merchant.AddTransaction(transaction);

            merchant.Transactions.Should().Contain(transaction);
        }

        [Test]
        public void ShouldCalculatePositiveBalance()
        {
            var merchant = new Merchant("Merchant Name", "Merchant Owner");

            var transaction = new Transaction(TransactionTypeEnum.Vendas, DateTime.Now, 100, "123456789", "123456789");

            merchant.AddTransaction(transaction);

            merchant.Balance.Should().Be(100);
        }

        [Test]
        public void ShouldCalculateNegativeBalance()
        {
            var merchant = new Merchant("Merchant Name", "Merchant Owner");

            var transaction = new Transaction(TransactionTypeEnum.Boleto, DateTime.Now, 100, "123456789", "123456789");

            merchant.AddTransaction(transaction);

            merchant.Balance.Should().Be(-100);
        }

        [Test]
        public void ShouldCalculateBalance()
        {
            var merchant = new Merchant("Merchant Name", "Merchant Owner");

            var transactions = new List<Transaction>()
            {
                new Transaction(TransactionTypeEnum.Boleto, DateTime.Now, 100, "123456789", "123456789"),
                new Transaction(TransactionTypeEnum.Vendas, DateTime.Now, 100, "123456789", "123456789"),
                new Transaction(TransactionTypeEnum.Financiamento, DateTime.Now, 100, "123456789", "123456789"),
                new Transaction(TransactionTypeEnum.Aluguel, DateTime.Now, 100, "123456789", "123456789"),
                new Transaction(TransactionTypeEnum.Debito, DateTime.Now, 100, "123456789", "123456789"),
                new Transaction(TransactionTypeEnum.Credito, DateTime.Now, 100, "123456789", "123456789"),
                new Transaction(TransactionTypeEnum.RecebimentoEmprestimo, DateTime.Now, 100, "123456789", "123456789"),
                new Transaction(TransactionTypeEnum.RecebimentoTED, DateTime.Now, 100, "123456789", "123456789"),
                new Transaction(TransactionTypeEnum.RecebimentoDOC, DateTime.Now, 100, "123456789", "123456789"),

            };
            transactions.ForEach(t => merchant.AddTransaction(t));

            merchant.Balance.Should().Be(300);
        }


    }
}
