namespace PhoneDisplayer.DataLayer
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public Company()
        {
            Phones = new List<Phone>();
        }
    }
}
