﻿using APBDzad2.Interfaces;

namespace APBDzad2.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }


    public GasContainer()
    {
        Type = ContainerTypeLetter.G;
    }

    protected override void Unload()
    {
        CargoMassInKg = 0.05f * CargoMassInKg;
    }

    public void NotifyHazard(string serialNumber, string hazardDescription)
    {
        IsHazardous = true;
        Console.WriteLine($"Container {serialNumber} is hazardous: {hazardDescription}");
    }
}