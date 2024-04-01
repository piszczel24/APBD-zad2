using APBDzad2.Enums;

namespace APBDzad2.Containers;

public class RefrigeratedContainer : Container
{
    private CargoTypes _cargoType;
    private float _temperature;

    private static readonly Dictionary<CargoTypes, float> CargoTemperature = new()
    {
        { CargoTypes.Bananas, 13.3f },
        { CargoTypes.Chocolate, 18f },
        { CargoTypes.Fish, 2f },
        { CargoTypes.Meat, -15f },
        { CargoTypes.IceCream, -18f },
        { CargoTypes.FrozenPizza, -30f },
        { CargoTypes.Cheese, 7.2f },
        { CargoTypes.Sausages, 5f },
        { CargoTypes.Butter, 20.5f },
        { CargoTypes.Eggs, 19f }
    };

    public RefrigeratedContainer(CargoTypes cargoType, float temperature)
    {
        Type = ContainerTypeLetter.C;
        _cargoType = cargoType;

        _temperature = temperature >= CargoTemperature[cargoType]
            ? temperature
            : throw new Exception("TooLowTemperatureException");
    }

    private static float GetTemperature(CargoTypes type)
    {
        return CargoTemperature[type];
    }
}