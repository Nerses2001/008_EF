using _008_EF_.Models;

namespace _008_EF_
{
    internal class GenData
    {
       private readonly Random random = new ();

        public  void GenerateData(Context db)
        {
            List<Country> countriesList = GenerateCountries();

            List<Company> companiesList = GenerateCompanies(countriesList);

            GeneratePhones(db, companiesList);
        }

        private List<Country> GenerateCountries()
        {
            List<Country> countriesList = new();

            foreach (string countryName in countries)
            {
                Country country = new()
                {
                    Name = countryName
                };

                countriesList.Add(country);
            }

            return countriesList;
        }

        private List<Company> GenerateCompanies(List<Country> countriesList)
        {
            List<Company> companiesList = new();

            foreach (string companyName in companyNames)
            {
                Country country = countriesList[random.Next(countriesList.Count)];

                Company company = new()
                {
                    Name = companyName,
                    Country = country
                };

                companiesList.Add(company);
            }

            return companiesList;
        }

        private void GeneratePhones(Context db, List<Company> companiesList)
        {
            foreach (string phoneModel in phoneModels)
            {
                Company company = companiesList[random.Next(companiesList.Count)];

                Phone phone = new()
                {
                    Name = phoneModel,
                    Price = random.Next(20000, 80000), 
                    Company = company
                };

                db.Phones.Add(phone);
            }

            db.SaveChanges();
        }

        private readonly List<string> companyNames = new() { "Nokia", "Motorola", "LG", "Sony", "Huawei", "OnePlus", "Google", "HTC", "BlackBerry" };
        private readonly List<string> countries = new() { "United States", "India", "China", "Brazil", "Japan", "United Kingdom", "Russia", "Germany", "South Korea", "Australia" };
        private readonly List<string> phoneModels = new() { "iPhone 13", "Samsung Galaxy S21", "Google Pixel 6", "OnePlus 9", "Xiaomi Mi 11", "Huawei P40", "LG Velvet", "Sony Xperia 1 III", "Motorola Edge", "Realme GT", "Nokia 9", "HTC U20", "BlackBerry Key3", "OPPO Reno 6", "Vivo X70", "Lenovo Legion Phone", "Asus ROG Phone 6", "ZTE Axon 30", "Alcatel 5X", "TCL 30 Pro", "Meizu 18", "Xolo Era X" };
    }
}
