namespace APBDzad2.Interfaces;

public interface IHazardNotifier
{
    protected bool IsHazardous { get; }
    public void NotifyHazard(string serialNumber, string hazardDescription);
}