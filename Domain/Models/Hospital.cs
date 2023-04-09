using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
<<<<<<<< HEAD:Domain/Models/Hospital.cs
    public class Hospital
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }

========
    public class HospitalPhisician
    {
        public int Id { get; set; }
        public required Hospital Hospital { get; set; }
        public required Physician Physician { get; set; }
>>>>>>>> b46cbb04968a89239bb83e3e4f517e70d0c4b3b0:Domain/Models/HospitalPhisician.cs
    }
}
