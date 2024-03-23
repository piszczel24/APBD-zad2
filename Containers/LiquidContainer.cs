using APBDzad2.Interfaces;

namespace APBDzad2.Containers;

public class LiquidContainer() : Container(ContainerTypeLetter.C), IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public override void Load(float mass)
    {
        MaxLoadInKg *= IsHazardous ? 0.5f : 0.9f;
        base.Load(mass);
    }

    protected override void Unload()
    {
        throw new NotImplementedException();
    }


    public void NotifyHazard(string serialNumber, string hazardDescription)
    {
        Console.WriteLine($"Container {serialNumber} is hazardous: {hazardDescription}");
        IsHazardous = true;
    }
}