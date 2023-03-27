using Company.Core.Interface;

namespace Company.Core.Entities;

public class Employee : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int DepartmentId { get; set; }
    public double Salary { get; set; }
    public int Age { get; set; }
    private static int _count;

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Surname: {Surname}";
    }
    private Employee()
    {
        Id = _count++;
    }

    public Employee(string name, string surname, int departmentId, double salary, int age) : this()
    {
        Name = name;
        Surname = surname;
        DepartmentId = departmentId;
        Salary = salary;
        Age = age;
    }
}
