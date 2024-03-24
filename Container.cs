using APBDzad2.Exceptions;

namespace APBDzad2;

public abstract class Container
{
    private static int _containerCounter;
    protected float CargoMassInKg;
    protected float HeightInCm;
    protected float OwnMassInKg;
    protected float DepthInCm;
    protected string SerialNumber;
    protected ContainerTypeLetter Type;
    protected float MaxLoadInKg = 10;

    private static readonly Dictionary<ContainerTypeLetter, string> ContainerCodeStringValues = new()
    {
        { ContainerTypeLetter.L, "L" },
        { ContainerTypeLetter.G, "G" },
        { ContainerTypeLetter.C, "C" }
    };

    protected Container()
    {
        SerialNumber = $"$KON-{GetString(Type)}.-{++_containerCounter}";
    }

    public virtual void Load(float mass)
    {
        if (mass > MaxLoadInKg) throw new OverfillException();
        CargoMassInKg = mass;
    }

    protected virtual void Unload()
    {
        CargoMassInKg = 0;
    }

    private static string GetString(ContainerTypeLetter type)
    {
        return ContainerCodeStringValues[type];
    }
}