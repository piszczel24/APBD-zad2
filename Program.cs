using APBDzad2.Containers;

namespace APBDzad2;

internal abstract class Program
{
    private static void Main()
    {
        Container container = new LiquidContainer();
        container.Load(10);
    }
}