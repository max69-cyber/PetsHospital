using AspVetMedForEnimals.Models;
namespace AspVetMedForEnimals.Data
{
    public static class AppDataContext
    {
        public static Dictionary<int, Pet> pets = new Dictionary<int, Pet>();
        public static Dictionary<int, Service> services = new Dictionary<int, Service>();
        public static Dictionary<int, Appointment> appointments = new Dictionary<int, Appointment>();

    }
}
