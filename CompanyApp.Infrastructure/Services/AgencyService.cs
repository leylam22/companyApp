using Company.Core.Entities;
using CompanyApp.Infrastructure.DBContext;
using CompanyApp.Infrastructure.Utilities.Exceptions;
using System.Xml.Linq;

namespace CompanyApp.Infrastructure.Services;

public class AgencyService
{
    private static int index_counter = 0;
    public void Create(string? name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBContext.Agencies[i].Name.ToUpper() == name.ToUpper())
            {
                isExist = true; break;
            }
        }
        if (isExist)
        {
            throw new DublicateNameException("This company name alredy exist");
        }
        Agency agency = new(name);
        AppDBContext.Agencies[index_counter++] = agency;
    }

    public void GetAll()
    {
        for (int i = 0; i < index_counter; i++)
        {
            Console.WriteLine(AppDBContext.Agencies[i].Id + "-" + AppDBContext.Agencies[i].Name);
        }
    }
}