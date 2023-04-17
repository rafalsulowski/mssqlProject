
namespace mssqlProject.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TripId { get; set; }
        public string Email { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
