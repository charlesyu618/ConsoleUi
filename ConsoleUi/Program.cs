using System;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("   Welcome to the Snake Game");
            Console.WriteLine("------------------------------");
            while (true)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. View Leaderboard");
                Console.WriteLine("x. Exit");
                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("");
                        LogIn.login();
                        Console.WriteLine("");
                        GameMenu();
                        break;

                    case "2":
                        Console.WriteLine("");
                        SignUp.register();
                        Console.WriteLine("");
                        GameMenu();
                        break;

                    case "3":
                        Console.WriteLine("");
                        Leaderboard.DisplayLeaderboardOverall();
                        Console.WriteLine("");
                        break;

                    case "X":
                    case "x":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        static void GameMenu()
        {
            
            // Console.WriteLine("Hello ...");

            while (true)
            {
                Console.WriteLine("1. Game Start!");
                Console.WriteLine("2. View Leaderboard");
                Console.WriteLine("3. Log Out");
                Console.WriteLine("x. Exit");
                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("");
                        // Add snake game here
                        // Write score
                        break;

                    case "2":
                        Console.WriteLine("");
                        Leaderboard.DisplayLeaderboardOverall();
                        Console.WriteLine("");
                        break;

                    case "3":
                        Console.WriteLine("");
                        MainMenu();
                        return;

                    case "X":
                    case "x":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        Console.WriteLine("");
                        break;
                }
            }
        }
    }
}
