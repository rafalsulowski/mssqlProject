

namespace mssqlProject.Models
{
    public class ParticipantDTO
    {
        public int TripId { get; set; }
        public int GroupId { get; set; }
        public string Email { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
