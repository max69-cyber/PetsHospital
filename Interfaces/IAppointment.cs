using AspVetMedForEnimals.Models;

namespace AspVetMedForEnimals.Interfaces
{
    public interface IAppointment
    {
        public List<Appointment> GetAll();
    public Appointment Get(int id);
        public void Post(int petId, int serviceId, DateTime dateTime, string notes);
        public void Put(int id, int petId, int serviceId, DateTime dateTime, string notes);
        public void Delete(int id);

    }
}
