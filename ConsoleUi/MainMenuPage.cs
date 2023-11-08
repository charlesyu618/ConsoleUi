using ConsoleUi;
using System;

public static class MainMenu
{
    static string connectionString = DatabaseConnection.ConnectionString;
    static MusicPlayer musicPlayer = new MusicPlayer();

    public static void Page()
    {
        string userName;

        while (true)
        {
            Console.WriteLine("  Welcome to the Snake Game");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. View Leaderboard");
            Console.WriteLine("x. Exit");
            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    userName = Login.login();
                    Console.Clear();
                    if (userName == null)
                    {
                        Page();
                    }
                    else
                    {
                        GameMenu.Page(userName);
                    }
                    break;

                case "2":
                    Console.Clear();
                    userName = SignUp.register();
                    Console.Clear();
                    if (userName == null)
                    {
                        Page();
                    }
                    else
                    {
                        GameMenu.Page(userName);
                    }
                    break;

                case "3":
                    Console.Clear();
                    ViewLeaderboard.Page();
                    Console.Clear();
                    break;

                case "X":
                case "x":
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please select a valid option.\n");
                    break;
            }
        }
    }
}
