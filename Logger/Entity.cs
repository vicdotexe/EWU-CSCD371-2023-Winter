namespace Logger;

public abstract record class Entity() : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();

    //This is implemented implicitly here as abstract to force implementation in derived classes.
    public abstract string Name { get; }
}