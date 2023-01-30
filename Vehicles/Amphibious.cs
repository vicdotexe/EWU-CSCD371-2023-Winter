namespace Vehicles;

public class Amphibious : ICar, IBoat
{
    int ICar.Reverse()
    {
        throw new NotImplementedException();
    }

    public string Reverse()
    {
        throw new NotImplementedException();
    }
}