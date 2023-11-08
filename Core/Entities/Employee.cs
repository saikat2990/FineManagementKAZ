namespace Core.Entities;

public class Employee:BaseEntity
{
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Salary { get; set; }
}