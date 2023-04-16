using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstracts;

namespace Domain.Models
{
    public class Patient:Person
    {
        public int PatientId { get; set; }

        public override string ToString()
        {
            return $"PatientId:{PatientId}, FirstName:{FirstName}, LastName:{LastName}, PhoneNumber:{PhoneNumber}";
        }
    }
}
