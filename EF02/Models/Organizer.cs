using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF02.Models
{
    public class Organizer
    {
        public int OrganizerId { get; set; }
        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public bool IsVerified { get; set; }

        public Profile Profile { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
