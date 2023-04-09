using Domain.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Hospital
    {
        public int HospitalId { get; set; }
        public string HospitalName { get;set; }
        public string Address { get; set; }
        public Rating Rating { get; set; }
    }
}
