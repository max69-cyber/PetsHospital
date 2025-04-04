using AspVetMedForEnimals.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspVetMedForEnimals.Interfaces
{
    public interface IPetsService
    {
        public List<Pet> GetAll();
        public Pet Get(int id);
        public void Post(string name, string species, string breed, int age, string ownerName);
        public void Put(int id, string name, string species, string breed, int age, string ownerName);
        public void Delete(int id);


    }
}
