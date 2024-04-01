using APBDzad2.Enums;
using APBDzad2.Interfaces;

namespace APBDzad2.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(float heightInCm, float ownMassInKg, float depthInCm) : base(heightInCm, ownMassInKg,
        depthInCm)
    {
        Type = ContainerTypeLetter.L;
    }

    protected override void Load(float mass)
    {
        MaxLoadInKg *= IsHazardous ? 0.5f : 0.9f;
        base.Load(mass);
    }

    public void NotifyHazard(string serialNumber, string hazardDescription)
    {
        IsHazardous = true;
        Console.WriteLine($"Container {serialNumber} is hazardous: {hazardDescription}");
    }
}