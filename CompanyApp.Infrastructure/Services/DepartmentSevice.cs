using Company.Core.Entities;
using CompanyApp.Infrastructure.DBContext;
using CompanyApp.Infrastructure.Utilities.Exceptions;
using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;

namespace CompanyApp.Infrastructure.Services;

public class DepartmentService
{
    private static int index_counter = 0;

    public void Create(string? name, int max_count, int agency_id)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("Must be a department name");
        }
        foreach (var agency in AppDBContext.Agencies)
        {
            if (agency is null)
            {
                throw new AddAgencyFailedException("This agency is not exist");
            }
            if (agency.Id == agency_id) { break; }
        }
        bool isSame = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBContext.Departments[i].DepartmentName.ToUpper() == name.ToUpper() && agency_id == AppDBContext.Departments[i].AgensyId)
            {
                isSame = true; break;
            }
        }
        if (isSame)
        {
            throw new DublicateNameException("A company cannot have two departments with the same name!");
        }
        Department new_department = new(name, max_count, agency_id);
        AppDBContext.Departments[index_counter++] = new_department;
    }

    public void GetAll()
    {
        for (int i = 0; i < index_counter; i++)
        {
            String temp_agency = String.Empty;
            foreach (var agency in AppDBContext.Agencies)
            {
                if (agency == null) break;
                if (AppDBContext.Departments[i].AgensyId == agency.Id)
                {
                    temp_agency = agency.Name;
                    break;
                }
            }
            Console.WriteLine($"id: {AppDBContext.Departments[i].Id};  " +  
                        $"Department: {AppDBContext.Departments[i].DepartmentName};  " +  
                        $"Max Count: {AppDBContext.Departments[i].MaxCount}; " +  
                        $"Belong to: {temp_agency};");
        }
    }

    public static void GetById(int id)
    {
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBContext.Departments[i].Id == id)
            {
                String temp_agency = String.Empty;
                foreach (var agency in AppDBContext.Agencies)
                {
                    if (agency == null) break;
                    if (AppDBContext.Departments[i].AgensyId == agency.Id)
                    {
                        temp_agency = agency.Name; break;
                    }
                }
                Console.WriteLine($"Department ID: {AppDBContext.Departments[i].Id}; " +
                                  $"Department; {AppDBContext.Departments[i].DepartmentName}; " +
                                  $"Employee Limit: {AppDBContext.Departments[i].EmployeeLimit}; " +
                                  $"Belongs to: {temp_agency}");
                return;
            }
        }
    }

    public void Update(int update, string name, int limit)
    {
        for (int i = 0; i < AppDBContext.Departments.Length; i++)
        {
            if (AppDBContext.Departments[i].Id == update)
            {
                AppDBContext.Departments[update].DepartmentName = name;
                AppDBContext.Departments[update].EmployeeLimit = limit;
                break;
            }
        }
    }

    public void GetAllDepartment(string search_name)
    {
        for (int i = 0; i < AppDBContext.Agencies.Length; i++)
        {
            if (AppDBContext.Agencies[i].Name.Equals(search_name))
            {
                foreach (var department in AppDBContext.Departments)
                {
                    if (department == null) break;
                    if (department.AgensyId == AppDBContext.Agencies[i].Id)
                    {
                        Console.WriteLine(department.DepartmentName);
                    }
                }
                break;
            }
            else
            {
                throw new NotExistException("Search name company is not exist");
            }
        }
    }

    //public void GetDepartmentEmployees(string departmentName)
    //{
    //    for (int i = 0; i < index_counter; i++)
    //    {
    //        if (departmentName == null)
    //        {
    //            throw new NotNullException("Department can't be contain null");
    //        }
    //    }
    //    Console.WriteLine("Employees in department:");
    //    foreach (var employee in AppDBContext.Employees )
    //    {
    //        if (employee.DepartmentId == DepartmentName)
    //        {
    //            Console.WriteLine($"Name: {employee.Name}, Surname: {employee.Surname}, Salary: {employee.Salary}");
    //        }
    //    }
    //}
}

