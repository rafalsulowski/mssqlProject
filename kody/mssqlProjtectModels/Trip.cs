using mssqlProject.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace mssqlProject.Models
{
    
    public class Trip
    {
        public int Id { get; set; }
        public int PromoterId { get; set; } //bez nawigacji do Promoter bo zapetla sie podczas odczytu
        public Budget? Budget { get; set; }
        public Hotel? Hotel { get; set; }
        public List<Place> Places { get; set; } = new List<Place>();
        public List<Participant> Participants { get; set; } = new List<Participant>(); 
        public List<Group> Groups { get; set; } = new List<Group>();

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }
}
