namespace ManagingSelfFinanceWebAPI.Models
{
    public class RegisterOperation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int OperationId { get; set; }
        public decimal Amount { get; set; }
    }
}
