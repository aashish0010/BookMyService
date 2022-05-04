using System;

namespace BookMyService.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BookDate { get; set; }
        public string Category { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime StartDate { get; set; } 
        public string ProviderDetail { get; set; }
    }
}
