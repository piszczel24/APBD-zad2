using APBDzad2.Containers;

namespace APBDzad2;

internal abstract class Program
{
    private static readonly List<ContainerShip> Ships = [];
    private static readonly List<Container> Containers = [];

    public static void Main()
    {
        while (true)
        {
            DisplayShips();
            DisplayContainers();
            DisplayActions();

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddShip();
                    break;
                case "2":
                    RemoveShip();
                    break;
                case "3":
                    AddContainer();
                    break;
                case "4":
                    RemoveContainer();
                    break;
            }
        }
    }

    private static void DisplayShips()
    {
        Console.WriteLine("Lista kontenerowców:");
        Console.WriteLine(Ships.Count == 0
            ? "Brak"
            : string.Join("\n",
                Ships.Select((ship, i) =>
                    $"Statek {i + 1} (speed={ship.MaxVelocityInKnots}, maxContainerNum={ship.MaxContainers}, maxWeight={ship.MaxWeightInTons})")));
    }

    private static void DisplayContainers()
    {
        Console.WriteLine("Lista kontenerów:");
        Console.WriteLine(Containers.Count == 0
            ? "Brak"
            : string.Join("\n",
                Containers.Select((container, i) =>
                    $"Kontener {i + 1} (cargoMass={container.CargoMassInKg}), height={container.HeightInCm}, ownMass={container.OwnMassInKg}, depth={container.DepthInCm}, serialNumber={container.SerialNumber})")));
    }

    private static void DisplayActions()
    {
        Console.WriteLine("Możliwe akcje:");
        Console.WriteLine("1. Dodaj kontenerowiec");
        Console.WriteLine("2. Usun kontenerowiec");
        Console.WriteLine("3. Dodaj kontener");
        Console.WriteLine("4. Usun kontener");
    }

    private static void AddShip()
    {
        Console.WriteLine("Podaj predkosc statku w wezlach:");
        var speed = float.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Podaj maksymalna liczbe kontenerow:");
        var maxContainers = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Podaj maksymalna wage w tonach:");
        var maxWeight = float.Parse(Console.ReadLine() ?? string.Empty);
        Ships.Add(new ContainerShip(speed, maxContainers, maxWeight));
    }

    private static void RemoveShip()
    {
        Console.WriteLine("Podaj numer statku do usuniecia:");
        var index = int.Parse(Console.ReadLine() ?? string.Empty);
        Ships.RemoveAt(index - 1);
    }

    private static void AddContainer()
    {
        Console.WriteLine("Podaj typ kontenera (L - liquid, G - gas, C - container):");
        var type = Console.ReadLine()?.ToUpper();
        Console.WriteLine("Podaj wysokosc kontenera w cm:");
        var height = float.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Podaj mase wlasna kontenera w kg:");
        var mass = float.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Podaj glebokosc kontenera w cm:");
        var depth = float.Parse(Console.ReadLine() ?? string.Empty);
        switch (type)
        {
            case "L":
                Containers.Add(new LiquidContainer(height, mass, depth));
                break;
            case "G":
                Containers.Add(new GasContainer(height, mass, depth));
                break;
            case "C":
                AddRefrigeratedContainer(height, mass, depth);
                break;
        }
    }

    private static void AddRefrigeratedContainer(float height, float mass, float depth)
    {
        Console.WriteLine("Podaj zawartosc kontenera:");
        var cargoType = Console.ReadLine();
        Console.WriteLine("Podaj temperature kontenera:");
        var temperature = float.Parse(Console.ReadLine() ?? string.Empty);
        Containers.Add(new RefrigeratedContainer(RefrigeratedContainer.StringToCargoType(cargoType),
            temperature, height, mass, depth));
    }

    private static void RemoveContainer()
    {
        Console.WriteLine("Podaj numer kontenera do usuniecia:");
        var index = int.Parse(Console.ReadLine() ?? string.Empty);
        Containers.RemoveAt(index - 1);
    }
}