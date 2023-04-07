using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Serving
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public DateTime ServedTime { get; set; }

    }
}
