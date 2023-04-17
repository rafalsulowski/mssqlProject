
namespace mssqlProject.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public string Name { get; set; } = string.Empty;
        public int MaxSize { get; set; }
    }
}
