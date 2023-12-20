using PhoneDisplayer.DataLayer.Entities;

namespace PhoneDisplayer.DataLayer.Repositories
{
    public class CompanyRepository
    {
        private readonly PhoneContex context;      
        public CompanyRepository()
        {
            context = new PhoneContex();
        }

        public IEnumerable<Company> GetAll() => context.Companies.ToList(); 
    }
}
