using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class WaitList
    {
        public int Id { get; set; }
        public required Physician Physician { get; set; }
        public required Patient Patient { get; set; }
        public DateTime JoinedTime { get; set; }

    }
}
