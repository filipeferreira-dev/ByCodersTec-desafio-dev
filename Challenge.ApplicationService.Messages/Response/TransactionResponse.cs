namespace Challenge.ApplicationService.Messages.Response
{
    public class TransactionResponse
    {
        public long Id { get; set; }

        public string Type { get; set; } = null!;

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Document { get; set; } = null!;

        public string Card { get; set; } = null!;
    }
}
