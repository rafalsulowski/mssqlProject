
namespace mssqlProject.Models
{
    public class PlaceDTO
    {
        public int TripId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
