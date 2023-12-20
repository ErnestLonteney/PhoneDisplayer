using Microsoft.EntityFrameworkCore;
using PhoneDisplayer.Business.Models;
using PhoneDisplayer.DataLayer.Repositories;
using System.Windows;

namespace PhoneDisplayer.Business.Services
{
    public class PhoneService
    {
        private readonly PhoneRepository repository;
        public PhoneService()
        {
            repository = new PhoneRepository();
        }

        public List<PhoneModel> GetAllPhones()
        {
            var phonesFromDB = repository.GetAll();

            return phonesFromDB.Select(p => new PhoneModel
            {
                Name = p.Name,
                Company = p.Company?.Name ?? "EMPTY",
                Id = p.Id,
                Price = p.Price,
            }).ToList();
        }

        public List<PhoneModel> GetAllPhonesByCompany(string companyName)
        {
            var phonesFromDB = repository.GetPhonesByCompanyName(companyName);

            return phonesFromDB.Select(p => new PhoneModel
            {
                Name = p.Name,
                Company = p.Company?.Name ?? "EMPTY",
                Id = p.Id,
                Price = p.Price,
            }).ToList();
        }

        public void RemovePhoneById(int phoneId)
        {
            try
            {
                repository.RemoveById(phoneId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddNewPhone(PhoneModel newPhone)
        {
            if (newPhone == null)
                return;

            try
            {
                repository.Add(newPhone);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
