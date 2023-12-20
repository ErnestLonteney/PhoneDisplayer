using Microsoft.EntityFrameworkCore;
using PhoneDisplayer.Business.Models;
using PhoneDisplayer.DataLayer.Entities;
using System.Windows;

namespace PhoneDisplayer.DataLayer.Repositories
{
    public class PhoneRepository
    {
        private readonly PhoneContex context;
        public PhoneRepository()
        {
            context = new PhoneContex();
        }

        public IEnumerable<Phone> GetAll() => context.Phones.Include(p => p.Company).ToList();
        public IEnumerable<Phone> GetPhonesByCompanyName(string companyName) => context.Phones.Where(p => p.Company.Name.Trim().ToUpper() == companyName.Trim().ToUpper());
        public int Add(PhoneModel newPhone)
        {
            int res = 0;
            var company = context.Companies.SingleOrDefault(c => c.Name == newPhone.Company);

            var newDbPhone = new Phone
            {
                Name = newPhone.Name,
                Price = newPhone.Price,
            };

            if (company != null)
                newDbPhone.CompanyId = company.Id;

            context.Phones.Add(newDbPhone);

            try
            {
                res = context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return res;
        }

        public int RemoveById(int phoneId)
        {
            int res = 0;
            var phoneForRemoving = context.Phones.Find(phoneId);
            if (phoneForRemoving == null)
                return res;

            context.Phones.Remove(phoneForRemoving);

            try
            {
                res = context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return res;
        }
    }
}
