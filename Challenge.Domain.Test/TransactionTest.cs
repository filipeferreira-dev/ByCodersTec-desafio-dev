using Challenge.Domain.Enums;
using Challenge.Domain.Models;
using FluentAssertions;


namespace Challenge.Domain.Test
{
    [TestFixture]
    public class TransactionTest
    {

        [Test]
        public void ShouldCreateTransactionSuccessfully()
        {
            var transactionType = TransactionTypeEnum.Boleto;
            var transactionDate = DateTime.Now;
            var transactionAmount = 100;
            var transactionDocument = "123456789";
            var transactionCard = "123456789";

            var transaction = new Transaction(transactionType, transactionDate, transactionAmount, transactionDocument, transactionCard);

            transaction.Should().NotBeNull();
            transaction.Type.Should().Be(transactionType);
            transaction.Date.Should().Be(transactionDate);
            transaction.Amount.Should().Be(transactionAmount);
            transaction.Document.Should().Be(transactionDocument);
            transaction.Card.Should().Be(transactionCard);
        }
    }
}
