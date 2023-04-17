
namespace mssqlProject.Models
{
    public class HotelDTO
    {
        public int TripId { get; set; }
        public string Designation { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
