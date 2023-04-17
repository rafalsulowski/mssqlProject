
namespace mssqlProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
