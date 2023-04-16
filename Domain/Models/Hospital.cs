using Domain.States;
using System.Numerics;

namespace Domain.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HospitalRating HospitalRating { get; set; }
      

    }
}
