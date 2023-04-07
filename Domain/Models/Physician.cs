using Domain.Abstracts;
using Domain.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Physician:Person
    {
        public int Id { get; set; }
        public required int CategoryId { get; set; }
        public float ExperienceYear { get; set; }
        public Rating Rating { get; set; }


    }
}
