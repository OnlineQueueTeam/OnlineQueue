namespace Domain.Models
{
    public class HospitalPhysician
    {
        public int Id { get; set; }
        public  Hospital Hospital { get; set; }
        public  Physician Physician { get; set; }

    }
}
