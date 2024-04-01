using APBDzad2.Enums;

namespace APBDzad2;

public class ContainerShip
{
    private static int _shipCount;
    private ContainerTypes _containerType;
    private readonly List<Container> _containers = [];
    private const float MaxVelocityInKnots = 10;
    private const int MaxContainers = 100;
    private const float MaxWeightInTons = 4;
    private float _currentWeight;

    public ContainerShip(ContainerTypes containerType)
    {
        _containerType = containerType;
    }

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= MaxContainers) return;


        if (_currentWeight + container.CargoMassInKg > MaxWeightInTons * 1000) return;

        _currentWeight += container.CargoMassInKg;
        _containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers) LoadContainer(container);
    }

    public void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }

    public void MoveContainerToShip(ContainerShip ship, Container container)
    {
        ship.LoadContainer(container);
        RemoveContainer(container);
    }


    public override string ToString()
    {
        return $"Statek {++_shipCount} (speed={MaxVelocityInKnots}, maxContainerNum=" +
               $"{MaxContainers}, maxWeight={MaxWeightInTons * 1000})";
    }
}