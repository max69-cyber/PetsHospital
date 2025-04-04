using AspVetMedForEnimals.Data;
using AspVetMedForEnimals.Interfaces;
using AspVetMedForEnimals.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AspVetMedForEnimals.Services
{
    public class ServiceService : IService
    {
       
        public List<Service> GetAll()
        {
            List<Service> services = new List<Service>();
            foreach (var service in AppDataContext.services)
            {
                services.Add(service.Value);
            }
            return services;
        }

        public Service Get(int id)
        {
            return AppDataContext.services.FirstOrDefault(s => s.Key == id).Value;
        }


        public void Post(string name, int durationMinutes, decimal price )
        {
            Service service = new Service { Name = name, DurationMinutes = durationMinutes, Price = price };
            int id = AppDataContext.services.LastOrDefault().Key + 1;
            AppDataContext.services.Add(id, service);
        }

        public void Put(int id, string name, int durationMinutes, decimal price)
        {
            AppDataContext.services.FirstOrDefault(e => e.Key == id).Value.Name = name;
            AppDataContext.services.FirstOrDefault(e => e.Key == id).Value.DurationMinutes = durationMinutes;
            AppDataContext.services.FirstOrDefault(e => e.Key == id).Value.Price = price;

        }

        public void Delete(int id)
        {
            var serviceToDelete = AppDataContext.services.FirstOrDefault(e => e.Key == id);
            AppDataContext.services.Remove(id);
        }
    }
}
