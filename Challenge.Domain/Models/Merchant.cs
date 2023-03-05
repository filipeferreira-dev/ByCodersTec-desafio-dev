using Challenge.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Domain.Models
{
    public class Merchant
    {
        [Key]
        public long Id { get; private set; }

        [Required]
        public string Name { get; private set; } = null!;

        public string Owner { get; private set; } = null!;

        public ICollection<Transaction> Transactions { get; private set; } = new HashSet<Transaction>();

        public decimal Balance => GetBalance();

        [Obsolete("Only for EF", true)]
        public Merchant()
        {
        }

        public Merchant(string name, string owner)
        {
            Name = name;
            Owner = owner;
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        private decimal GetBalance()
        {
            if(Transactions.Count == 0) return 0;

            var inBoundTransactionTypes = new HashSet<TransactionTypeEnum>()
            {
                TransactionTypeEnum.Debito,
                TransactionTypeEnum.Credito,
                TransactionTypeEnum.RecebimentoEmprestimo,
                TransactionTypeEnum.Vendas,
                TransactionTypeEnum.RecebimentoTED,
                TransactionTypeEnum.RecebimentoDOC
            };

            var outBoundTransactionTypes = new HashSet<TransactionTypeEnum>()
            {
                TransactionTypeEnum.Boleto,
                TransactionTypeEnum.Financiamento,
                TransactionTypeEnum.Aluguel,
            };

            var inbound = Transactions.Where(t => inBoundTransactionTypes.Contains(t.Type)).Sum(t => t.Amount);
            var outbound = Transactions.Where(t => outBoundTransactionTypes.Contains(t.Type)).Sum(t => t.Amount);

            return inbound - outbound;
        }

    }
}
