using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF02.Models
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public string BadgeNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public string Tier { get; set; } 
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
    }
}
