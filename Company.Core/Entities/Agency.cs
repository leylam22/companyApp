using Company.Core.Interface;

namespace Company.Core.Entities;

public class Agency : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    private static int _count;
    private Agency()
    {
        Id = _count++;
    }

    public Agency(string name) : this()
    {
        Name = name;
    }
}