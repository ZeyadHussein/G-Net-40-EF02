using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF02.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }
    }
}
