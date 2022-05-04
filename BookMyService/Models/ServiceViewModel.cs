using System.Collections.Generic;

namespace BookMyService.Models
{
    public class ServiceViewModel : Service
    {
        public List<Service> ServiceList { get; set; }
    }
}
