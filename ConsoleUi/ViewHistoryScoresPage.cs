using ConsoleUi;
using System;

public static class ViewHistoryScores
{
    static string connectionString = DatabaseConnection.ConnectionString;
    static MusicPlayer musicPlayer = new MusicPlayer();

    public static void Page(int gamerID, string name)
    {
        bool backToGameMenu = false;

        while (!backToGameMenu)
        {
            Console.WriteLine($"History Score of {name}!\n");
            Console.WriteLine("1. My TOP 10 History Scores");
            Console.WriteLine("2. My Recent 10 History Scores");
            Console.WriteLine("x. Back to Game Menu");
            Console.Write("Please select an option: ");
            string historyChoice = Console.ReadLine();

            switch (historyChoice)
            {
                case "1":
                    Console.Clear();
                    UserHistoryScores.DisplayTop10HistoryScores(gamerID, name);
                    Console.Clear();
                    break;

                case "2":
                    Console.Clear();
                    UserHistoryScores.DisplayRecent10HistoryScores(gamerID, name);
                    Console.Clear();
                    break;

                case "X":
                case "x":
                    Console.Clear();
                    GameMenu.Page(name);
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please select a valid option.\n");
                    break;
            }
        }
    }
}
