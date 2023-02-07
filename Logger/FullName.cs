namespace Logger;

//This represents the value of someone's name. We want to compare
//by value, a reference comparison could invalidate the comparison.
//Any copies of this value shouldn't be affected when the value is replaced.

//This should be immutable, because if the data were to change,
//then the value is technically new, so we would just replace the value,
//and safeguard against assuming the changes have affected any copies.
public readonly record struct FullName(string FirstName, string LastName, string? MiddleName = null)
{
    public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
    public string? MiddleName { get; } = MiddleName;

    public override string ToString()
    {
        return MiddleName == null ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
    }
}
