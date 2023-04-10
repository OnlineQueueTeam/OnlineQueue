namespace Domain.Models
{

    public class HospitalPhisician
    {
        public int Id { get; set; }
        public required Hospital Hospital { get; set; }
        public required Physician Physician { get; set; }

    }
}
