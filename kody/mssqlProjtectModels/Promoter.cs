﻿namespace mssqlProject.Models
{
    
    public class Promoter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}
