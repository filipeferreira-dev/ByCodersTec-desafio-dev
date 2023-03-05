using Challenge.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Domain.Models
{
    public class Transaction
    {
        [Key]
        public long Id { get; private set; }

        [ForeignKey("Merchant")]
        public long MerchantId { get; private set; }

        public TransactionTypeEnum Type { get; private set; }

        public DateTime Date { get; private set; }

        public decimal Amount { get; private set; }

        public string Document { get; private set; } = null!;

        public string Card { get; private set; } = null!;

        public Transaction(TransactionTypeEnum type, DateTime date, decimal amount, string document, string card)
        {
            Type = type;
            Date = date;
            Amount = amount;
            Document = document;
            Card = card;
        }

        [Obsolete("Only for EF", true)]
        public Transaction()
        {
        }

    }
}
