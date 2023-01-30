namespace Vehicles;

public record class Boat(Guid Id, int NumberOfSails) : IBoat
{
    public string Reverse() => "Reversing the boat;";
}
    
