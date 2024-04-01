using APBDzad2.Enums;
using APBDzad2.Interfaces;

namespace APBDzad2.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }


    public GasContainer(float heightInCm, float ownMassInKg, float depthInCm) : base(heightInCm, ownMassInKg, depthInCm)
    {
        Type = ContainerTypeLetter.G;
    }

    protected internal override void Unload()
    {
        CargoMassInKg = 0.05f * CargoMassInKg;
    }

    public void NotifyHazard(string serialNumber, string hazardDescription)
    {
        IsHazardous = true;
        Console.WriteLine($"Container {serialNumber} is hazardous: {hazardDescription}");
    }
}