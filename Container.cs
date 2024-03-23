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

    protected Container(ContainerTypeLetter type)
    {
        SerialNumber = $"$KON-{GetString(type)}.-{++_containerCounter}";
    }

    public virtual void Load(float mass)
    {
        if (mass > MaxLoadInKg) throw new OverfillException("Container is overloaded");
        CargoMassInKg = mass;
    }

    protected abstract void Unload();

    private static readonly Dictionary<ContainerTypeLetter, string> StringValues = new()
    {
        { ContainerTypeLetter.L, "L" },
        { ContainerTypeLetter.G, "G" },
        { ContainerTypeLetter.C, "C" }
    };

    private static string GetString(ContainerTypeLetter type)
    {
        return StringValues[type];
    }
}