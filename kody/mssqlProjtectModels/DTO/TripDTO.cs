namespace mssqlProject.Models.DTO
{
    public class TripDTO
    {
        public int PromoterId { get; set; }
        public int BudgetId { get; set; }
        public int HotelId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }
}
