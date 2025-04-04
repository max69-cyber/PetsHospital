using AspVetMedForEnimals.Models;

namespace AspVetMedForEnimals.Interfaces
{
    public interface IService
    {
        public List<Service> GetAll();
        public Service Get(int id);
        public void Post(string name, int durationMinutes, decimal price);
        public void Put(int id, string name, int durationMinutes, decimal price);
        public void Delete(int id);
    }
}
