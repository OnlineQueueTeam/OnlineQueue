using Domain.States;
namespace Domain.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }


        public class HospitalPhisician
        {
            public int Id { get; set; }
            public required Hospital Hospital { get; set; }
            public required Physician Physician { get; set; }

            public class Hospital
            {
                public int HospitalId { get; set; }
                public string HospitalName { get; set; }
                public string Address { get; set; }
                public Rating Rating { get; set; }

            }
        }
    }
}
