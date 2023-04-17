namespace mssqlProject.Models
{
    public class BudgetDTO
    {
        public int TripId { get; set; }
        public double BudgetSize { get; set; }
        public int ShareHoldersCount { get; set; }
        public string BankAccunt { get; set; } = string.Empty;
    }
}
