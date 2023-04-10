namespace Domain.Models
{
    public class HospitalPhysician
    {
        public int Id { get; set; }
        public required Hospital Hospital { get; set; }
        public required Physician Physician { get; set; }

    }
}
