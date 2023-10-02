using _008_EF_;
using _008_EF_.Models;

/* Adding data 
using (Context context = new())
{
    GenData data = new();
    data.GenerateData(context);

}

*/

using (Context context = new())
{
    var phones = (from Phone phone in context.Phones
                  where phone.CompanyId == 1
                  select phone).ToList();

    foreach (var item in phones)
    {
        Console.WriteLine($"{item.Name} - {item.Price}");
    }

    var phones2 = context.Phones.Where(p => p.CompanyId == 1);
}

Console.WriteLine(new string('-',100));

using (Context context = new())
{
    var phones = context.Phones.Where(p => p.Company.Name == "Nokia");
    var phones2 = (from Phone in context.Phones
                   where Phone.Company.Name == "Nokia"
                   select Phone);

    foreach (var item in phones)
    {
        Console.WriteLine($"{item.Name} - {item.Price}");
    }
}

Console.WriteLine(new string('-', 100));

using (Context db = new())
{
    var phones = db.Phones.Where(p => p.Id > 1).ToList();

    IQueryable<Phone> phones2 = db.Phones.Where(p => p.Id > 1);

    foreach (var item in phones)
    {
        Console.WriteLine(item.Name);
    }
    Console.WriteLine();
    foreach (var item in phones2)
    {
        Console.WriteLine(item.Name);
    }
}

Console.WriteLine(new string('-', 100));

using (Context db = new())
{
    var maxPrice = db.Phones
        .Where(p => p.Id > 1)
        .Any(p => p.Price == 42000);
    //.All(p => p.Price == 42000);

    var sum = db.Phones
        .Where(p => p.Id > 1)
        .Sum(s => s.Price);

    var avg = db.Phones
        .Where(p => p.Id > 1)
        .Average(s => s.Price);

    var contains = db.Phones
     .Where(p => p.Name.Contains("Sony"));


    var result = db.Phones.Select(s => new
    {
        s.Id,
        s.Name
    });

    var result2 = db.Phones.SelectMany(s => contains);
    foreach (var item in result2)
    {
        Console.WriteLine(item.Name);
    }
    foreach (var item in result)
    {
        Console.WriteLine(item.Name);
    }

    IEnumerable<Phone> resu3 = db.Phones.
        DistinctBy(p => p.Name);

    Console.WriteLine("---------------");
    foreach (var item in contains)
    {
        Console.WriteLine(item.CompanyId + " , " + item.Price);
    }


    Console.WriteLine("Sum is {0}  ", sum);
    Console.WriteLine("Avg is {0}  ", avg);


    IQueryable<Phone> phones2 = db.Phones
        .Where(p => p.Id > 1);


    Console.WriteLine("Max is {0}", maxPrice);


    foreach (var item in phones2)
    {
        Console.WriteLine(item.Name);
    }
}
