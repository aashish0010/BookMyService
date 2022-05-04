namespace BookMyService.Models
{
    public class Booked
    {
        public int Id { get; set; }
        public string ServiceProvider { get; set; }
        public string Service { get; set; }
        public string ServiceSeeker { get; set; }
        public string Status { get; set; }
    }
}
