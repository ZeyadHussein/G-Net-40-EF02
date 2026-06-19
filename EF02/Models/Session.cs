using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF02.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string Title { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
