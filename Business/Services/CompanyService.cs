using PhoneDisplayer.Business.Models;
using PhoneDisplayer.DataLayer.Repositories;

namespace PhoneDisplayer.Business.Services
{
    public class CompanyService
    {
        private CompanyRepository companyRepository;

        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }

        public List<CompanyModel> GetAllCompanies()
        {
            var allFromDb = companyRepository.GetAll();

            return allFromDb.Select(c => new CompanyModel
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();    
        }
    }
}
