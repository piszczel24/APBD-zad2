using APBDzad2.Enums;
using APBDzad2.Exceptions;

namespace APBDzad2;

public abstract class Container
{
    private static int _containerCounter;
    protected internal float CargoMassInKg { get; protected set; }
    protected internal readonly float HeightInCm;
    protected internal readonly float OwnMassInKg;
    protected internal readonly float DepthInCm;
    protected internal readonly string SerialNumber;
    protected ContainerTypeLetter Type;
    protected float MaxLoadInKg = 10;

    private static readonly Dictionary<ContainerTypeLetter, string> ContainerCodeStringValues = new()
    {
        { ContainerTypeLetter.L, "L" },
        { ContainerTypeLetter.G, "G" },
        { ContainerTypeLetter.C, "C" }
    };

    protected Container(float heightInCm, float ownMassInKg, float depthInCm)
    {
        HeightInCm = heightInCm;
        OwnMassInKg = ownMassInKg;
        DepthInCm = depthInCm;
        SerialNumber = $"$KON-{GetString(Type)}-{++_containerCounter}";
    }

    protected virtual void Load(float mass)
    {
        if (mass > MaxLoadInKg) throw new OverfillException();
        CargoMassInKg = mass;
    }

    protected internal virtual void Unload()
    {
        CargoMassInKg = 0;
    }

    private static string GetString(ContainerTypeLetter type)
    {
        return ContainerCodeStringValues[type];
    }
}