

namespace mssqlProject.Models
{
    public class CommentDTO
    {
        public int PlaceId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
