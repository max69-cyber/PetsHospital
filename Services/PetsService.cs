using AspVetMedForEnimals.Interfaces;
using AspVetMedForEnimals.Models;
using Microsoft.AspNetCore.Mvc;
using AspVetMedForEnimals.Data;
namespace AspVetMedForEnimals.Pets
{
    public class PetsService : IPetsService
    {
        public List<Pet> GetAll()
        {
            List<Pet> pets = new List<Pet>();
            foreach (var pet in AppDataContext.pets)
            {
                pets.Add(pet.Value);
            }
            return pets;
        }

        public Pet Get(int id)
        {
            return AppDataContext.pets.FirstOrDefault(s => s.Key == id).Value;
        }

        int id = 0;

        public void Post(string name, string species, string breed, int age, string ownerName)
        {
            Pet pet = new Pet { Name = name, Species = species, Breed = breed, Age = age, OwnerName = ownerName};
            id = AppDataContext.pets.LastOrDefault().Key + 1;
            AppDataContext.pets.Add(id, pet);
        }

        public void Put(int id, string name, string species, string breed, int age, string ownerName)
        {
            //var serviceToEdit = AppDataContext.pets.FirstOrDefault(e => e.Key == id);
            //var pet = new Pet { Name = name, Species = species, Breed = breed, Age = age, OwnerName = ownerName };
            AppDataContext.pets.FirstOrDefault(e => e.Key == id).Value.Name = name;
            AppDataContext.pets.FirstOrDefault(e => e.Key == id).Value.Species = species;
            AppDataContext.pets.FirstOrDefault(e => e.Key == id).Value.Breed = breed;
            AppDataContext.pets.FirstOrDefault(e => e.Key == id).Value.Age = age;
            AppDataContext.pets.FirstOrDefault(e => e.Key == id).Value.OwnerName = ownerName;

            //var petToEdit = AppDataContext.pets.FirstOrDefault(e => e.Key == id).Value;
            //AppDataContext.pets.= new Pet
            //{
            //    Name = name,
            //    Species = species,
            //    Breed = breed,
            //    Age = age,
            //    OwnerName = ownerName
            //};

        }

        

        public void Delete(int id)
        {
            var petToDelete = AppDataContext.pets.FirstOrDefault(e => e.Key == id);
            AppDataContext.pets.Remove(id);
        }
    }
}
