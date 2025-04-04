using AspVetMedForEnimals.Data;
using AspVetMedForEnimals.Interfaces;
using AspVetMedForEnimals.Models;

namespace AspVetMedForEnimals.Services
{
    public class AppointmentService : IAppointment
    {
        public List<Appointment> GetAll()
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (var appointment in AppDataContext.appointments)
            {
                appointments.Add(appointment.Value);
            }
            return appointments;
        }

        public Appointment Get(int id)
        {
            return AppDataContext.appointments.FirstOrDefault(s => s.Key == id).Value;
        }


        public void Post(int petId, int serviceId, DateTime dateTime, string notes)
        {
            Appointment appointment = new Appointment { PetId = petId, ServiceID = serviceId, DateTime = dateTime, Notes = notes };
            int id = AppDataContext.services.LastOrDefault().Key + 1;
            AppDataContext.appointments.Add(id, appointment);
        }

        public void Put(int id, int petId, int serviceId, DateTime dateTime, string notes)
        {
            AppDataContext.appointments.FirstOrDefault(e => e.Key == id).Value.PetId = petId;
            AppDataContext.appointments.FirstOrDefault(e => e.Key == id).Value.ServiceID = serviceId;
            AppDataContext.appointments.FirstOrDefault(e => e.Key == id).Value.DateTime = dateTime;
            AppDataContext.appointments.FirstOrDefault(e => e.Key == id).Value.Notes = notes;

        }

        public void Delete(int id)
        {
            var serviceToDelete = AppDataContext.appointments.FirstOrDefault(e => e.Key == id);
            AppDataContext.appointments.Remove(id);
        }
    }
}
