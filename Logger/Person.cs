namespace Logger;

public record class Person(FullName FullName) : Entity
{
    //This is implemented implicitly as an abstract property in the base class so we need to override it here.
    public override string Name => FullName.ToString();

}