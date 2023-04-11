using Domain.States;
namespace Domain.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ContactInfo? ContactInfo { get; set; }

    }
}
