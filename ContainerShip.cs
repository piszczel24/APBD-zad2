namespace APBDzad2;

public class ContainerShip(float maxVelocityInKnots, int maxContainers, float maxWeightInTons)
{
    private readonly List<Container> _containers = [];
    public readonly float MaxVelocityInKnots = maxVelocityInKnots;
    public readonly int MaxContainers = maxContainers;
    public readonly float MaxWeightInTons = maxWeightInTons;
    private float _currentWeight;

    private void LoadContainer(Container container)
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

    private void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }

    public void MoveContainerToShip(ContainerShip ship, Container container)
    {
        ship.LoadContainer(container);
        RemoveContainer(container);
    }
}