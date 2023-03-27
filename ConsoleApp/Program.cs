// See https://aka.ms/new-console-template for more information
using Company.Core.Entities;
using CompanyApp.Infrastructure.Services;
using CompanyApp.Infrastructure.Utilities;
using CompanyApp.Infrastructure.Utilities.Exceptions;
AgencyService agencyService = new AgencyService();
DepartmentService departmentService = new DepartmentService();
Console.WriteLine("Welcome! Please enter a number: ");
while (true)
{
    Console.WriteLine("\nExit-0" +
        "\nCreate Company-1" +
        "\nList Company-2" +
        "\nCreate Department-3" +
        "\nDepartment List-4" +
        "\nSearch department by company-5" +
        "\nCreate Employee-6" +
        "\nUpdate-7 ");
    string? response = Console.ReadLine();
    int menu;
    bool tryToInt = int.TryParse(response, out menu);
    if (tryToInt)
    {
        switch (menu)
        {
            case (int)Menu.Exit:
                Environment.Exit(0);
                break;
            case (int)Menu.CreateCompany:
                Console.WriteLine("Enter Company name: ");
                string? res_compnyname = Console.ReadLine();
                try
                {
                    agencyService.Create(res_compnyname);
                    Console.WriteLine($"new company:{res_compnyname}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                break;
            case (int)Menu.ListCompany:
                Console.WriteLine("Company List: ");
                agencyService.GetAll();
                break;
            case (int)Menu.CreateDepartment:
                Console.WriteLine("Enter Department name: ");
                string? department_nane = Console.ReadLine();
            max_count:
                Console.WriteLine("Enter Department Employee Limit:");
                string? department_limit = Console.ReadLine();
                int limit_count;
                bool tryToIntMax = int.TryParse(department_limit, out limit_count);
                if (!tryToIntMax) 
                {
                    Console.WriteLine("Enter correct Format!!!");
                    goto max_count;
                }
            select_agency:
                Console.WriteLine("Enter Agency (ID):");
                agencyService.GetAll();
                string? select_agency = Console.ReadLine();
                int agency_Id;
                bool tryToIdAgency = int.TryParse(select_agency, out agency_Id);
                if (!tryToIdAgency)
                {
                    Console.WriteLine("Enter correct Agency ID!!!");
                    goto select_agency;
                }
                try
                {
                    departmentService.Create(department_nane, limit_count, agency_Id);
                    Console.WriteLine("Succesfully created");
                }
                catch (AddAgencyFailedException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto select_agency;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case (int)Menu.CreateDepartment;
                }
                break;
            case (int)Menu.DepartmentList:
                Console.WriteLine("Department List: ");
                departmentService.GetAll();
                break;
            case (int)Menu.GetAllDepartmentByCompany:
                Console.WriteLine("Enter Company name: ");
                string? search = Console.ReadLine();
                try
                {
                    departmentService.GetAllDepartment(search);
                }
                catch (NotNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NotExistException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case (int)Menu.CreateEmployee:
                Console.WriteLine("Enter Employee Name: ");
                string? employee_name = Console.ReadLine();
                Console.WriteLine("Enter Employee Surname: ");
                string? employee_surname = Console.ReadLine();
                Console.WriteLine("Enter Employee salary: ");
                double.TryParse(Console.ReadLine(), out double employee_salary);
                Console.WriteLine("Enter Employee Age: ");
                int.TryParse(Console.ReadLine(), out int employee_age);
            select_department:
                departmentService.GetAll();
                Console.WriteLine("Enter department ID: ");
                string? select_department = Console.ReadLine();
                int department_Id;
                bool tryToIdDepartment = int.TryParse(select_department, out department_Id);
                if (!tryToIdDepartment)
                {
                    Console.WriteLine("Enter Correct Department ID");
                    goto select_department;
                }
                try
                {
                    EmployeeService.Create(employee_name, employee_surname, department_Id, employee_salary, employee_age);
                    Console.WriteLine("Succesfuly created");
                }
                catch (AddDepartmentFailedException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto select_department;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case (int)Menu.CreateEmployee;
                }
                break;
            case (int)Menu.Update:
                departmentService.GetAll();
            select_update:
                Console.WriteLine("Sellect to Update");
                string? update = Console.ReadLine();
                int update_Id;
                bool tryToUpdateId = int.TryParse(update, out update_Id);
                if (!tryToUpdateId)
                {
                    Console.WriteLine("Enter correct option!");
                    goto select_update;
                }
                Console.WriteLine("Enter department name!");
                string? name_update = Console.ReadLine();
            new_limit:
                Console.WriteLine("Enter employee limit");
                string? employee_limit = Console.ReadLine();
                int limit;
                bool tryToEmployeeLimit = int.TryParse(employee_limit, out limit);
                if (!tryToEmployeeLimit)
                {
                    Console.WriteLine("Enter correct option!");
                }
                try
                {
                    departmentService.Update(update_Id, name_update, limit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case (int)Menu.Update;
                }
                break;
            default:
                Console.WriteLine("Sellect correct ones from menu!!!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Enter correct menu item!!!");
    }
}
