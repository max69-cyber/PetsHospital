namespace AspVetMedForEnimals.Models
{
    public class Appointment
    {
        public int PetId { get; set; }
        public int ServiceID { get; set; }

        public DateTime DateTime { get; set; }
        public string Notes { get; set; }
    }
}
