// GameRules.cs
using System;

public static class GameRules
{
    public static void Show()
    {
        Console.WriteLine("          Game Rules          ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("Fruit");
        Console.WriteLine("Red:   One more life.");
        Console.WriteLine("Green: Constant Speed\n");
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
