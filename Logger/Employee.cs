namespace Logger;

public record class Employee(FullName FullName, string Role) : Person(FullName)
{

}