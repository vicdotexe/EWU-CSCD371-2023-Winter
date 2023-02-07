namespace Logger;

public record class Student(FullName FullName, string Major) : Person(FullName)
{

}