using System.Collections.Generic;

namespace BookMyService.Models
{
    public class RegisterViewModel:Register
    {
        public List<Register> Registers { get; set; }
    }
}
