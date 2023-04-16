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
        public  Category Category { get; set; }
        public double ExperienceYear { get; set; }
        public PhysicianRating Rating { get; set; }


    }
}
