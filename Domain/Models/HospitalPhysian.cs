using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class HospitalPhysian
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int PhysicianId { get; set; }
    }
}
