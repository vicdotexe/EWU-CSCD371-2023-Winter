namespace Vehicles;

public class Car : ICar
{
    public void Reverse()
    {
        throw new NotImplementedException();
    }

    int ICar.Reverse()
    {
        throw new NotImplementedException();
    }
}
