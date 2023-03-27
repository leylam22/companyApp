using Company.Core.Interface;
using System.Xml.Linq;

namespace Company.Core.Entities;

public class Department : IEntity
{
    public int Id { get; set; }
    public int AgensyId { get; set; }
    public string DepartmentName { get; set; }
    public int MaxCount { get; }  
    public int EmployeeLimit { get; set; }
    private static int _count;


    private Department()
    {
        Id = _count++;
    }

    public Department(string department_name, int limit, int agency_id) : this()
    {
        DepartmentName = department_name;
        EmployeeLimit = limit;
        AgensyId = agency_id;
    }
}
