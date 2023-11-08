using ConsoleUi;
using System;

public static class ViewLeaderboard
{
    static string connectionString = DatabaseConnection.ConnectionString;
    static MusicPlayer musicPlayer = new MusicPlayer();

    public static void Page()
    {
        bool backToMainMenu = false;

        while (!backToMainMenu)
        {
            Console.WriteLine("Select a Leaderboard:\n");
            Console.WriteLine("1. Overall");
            Console.WriteLine("2. Today");
            Console.WriteLine("3. This Week");
            Console.WriteLine("4. This Month");
            Console.WriteLine("x. Back to Main Menu");
            Console.Write("Please select an option: ");
            string leaderboardChoice = Console.ReadLine();

            switch (leaderboardChoice)
            {
                case "1":
                    Console.Clear();
                    Leaderboard.DisplayLeaderboardOverall();
                    Console.Clear();
                    break;

                case "2":
                    Console.Clear();
                    Leaderboard.DisplayLeaderboardDaily();
                    Console.Clear();
                    break;

                case "3":
                    Console.Clear();
                    Leaderboard.DisplayLeaderboardWeekly();
                    Console.Clear();
                    break;

                case "4":
                    Console.Clear();
                    Leaderboard.DisplayLeaderboardMonthly();
                    Console.Clear();
                    break;

                case "X":
                case "x":
                    backToMainMenu = true;
                    Console.Clear();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please select a valid option.\n");
                    break;
            }
        }
    }
}
