using System;

public static class GameRules
{
    public static void Page()
    {
        Console.WriteLine("          Game Rules          ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("Fruit");
        Console.WriteLine("Red:   Ghost Mode 40 steps");
        Console.WriteLine("Green: Change Speed\n");
        Console.WriteLine("Speed Stage");
        Console.WriteLine("Slow:        0 < Score <= 20");
        Console.WriteLine("Medium:     20 < Score <= 50");
        Console.WriteLine("Fast:       50 < Score <= 80");
        Console.WriteLine("Scary Fast: 80 < Score\n");
        Console.Write("Press any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }
}
