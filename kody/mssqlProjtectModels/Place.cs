
namespace mssqlProject.Models
{
    public class Place
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
