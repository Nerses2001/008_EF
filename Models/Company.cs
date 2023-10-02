namespace _008_EF_.Models
{
    internal class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }  

        public virtual Country Country { get; set; }    
        public virtual List<Phone> Phones { get; set; }

        public Company()
        {
            Phones = new List<Phone>();

        }

    }
}
