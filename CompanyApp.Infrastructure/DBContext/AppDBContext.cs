using Company.Core.Entities;

namespace CompanyApp.Infrastructure.DBContext;

public static class AppDBContext
{
    public static Employee[] Employees { get; set; } = new Employee[1000];
    public static Department[] Departments { get; set; } = new Department[100];
    public static Agency[] Agencies { get; set; } = new Agency[10];
}
