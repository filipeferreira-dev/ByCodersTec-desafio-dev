namespace Challenge.ApplicationService.Messages.Response
{
    public class MerchantResponse
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Owner { get; set; } = null!;

        public IEnumerable<TransactionResponse> Transactions { get; set; } = new HashSet<TransactionResponse>();

        public decimal Balance { get; set; }
    }
}
