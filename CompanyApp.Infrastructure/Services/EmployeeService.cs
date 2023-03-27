using Company.Core.Entities;
using CompanyApp.Infrastructure.DBContext;
using CompanyApp.Infrastructure.Utilities.Exceptions;

namespace CompanyApp.Infrastructure.Services;

public class EmployeeService
{
    public static int index_counter = 0;
    private EmployeeService _employeeService;
    public EmployeeService()
    {
        _employeeService = new EmployeeService();
    }
    public static void Create(string name, string surname, int departmentId, double salary, int age)
    {
        if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        if (salary <= 0 || age <= 0)
        {
            throw new NegativeException("Salary can't be 0!");
        }
        foreach (var department in AppDBContext.Departments)
        {
            if (department is null)
            {
                throw new AddDepartmentFailedException("This department is not exist");
            }
            if (department.Id == departmentId) { break; }
        }
        Employee new_employee = new(name, surname, departmentId, salary, age);
        AppDBContext.Employees[index_counter++] = new_employee;
    }
    public void GetAll()
    {
        for (int i = 0; i < index_counter; i++)
        {
            Console.WriteLine("\n************************************************************************\n");
            Console.WriteLine($"Employee ID: {AppDBContext.Employees[i].Id}; " +
                $"Employee Name: {AppDBContext.Employees[i].Name}; " +
                $"Employee Surname: {AppDBContext.Employees[i].Surname}; " +
                $"Employee Salary: {AppDBContext.Employees[i].Salary}; ");
            DepartmentService.GetById(AppDBContext.Employees[i].DepartmentId);
            Console.WriteLine("\n************************************************************************\n");
        }
    }
}

