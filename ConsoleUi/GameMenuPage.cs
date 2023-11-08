using ConsoleUi;
using System;
using System.Data.SqlClient;

public static class GameMenu
{
    static string connectionString = DatabaseConnection.ConnectionString;
    static MusicPlayer musicPlayer = new MusicPlayer();

    public static void Page(string name)
    {
        int gamerID = -1;

        // Get gamer_id from db
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT [gamer_id] FROM [leaderboard].[dbo].[Gamer] WHERE [gamer_name] = @GamerName", connection))
            {
                command.Parameters.AddWithValue("@GamerName", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        gamerID = reader.GetInt32(0);
                    }
                }
            }
        }

        while (true)
        {
            if (DateTime.Now.Hour < 12)
            {
                Console.WriteLine("Good Morning, " + name + "!\n");
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                Console.WriteLine("Good Afternoon, " + name + "!\n");
            }
            else
            {
                Console.WriteLine("Good Evening, " + name + "!\n");
            }

            Console.WriteLine("1. Game Start!");
            Console.WriteLine("2. Show Game Rules");
            Console.WriteLine("3. View Leaderboard");
            Console.WriteLine("4. My History Scores");
            Console.WriteLine("5. Log Out");
            Console.WriteLine("x. Exit");
            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();

            int gameScore = 0;
            switch (choice)
            {
                case "1":
                    musicPlayer.StopBackgroundMusic();
                    Console.Clear();
                    gameScore = new Game().Start(gamerID);
                    Thread.Sleep(500);
                    musicPlayer.PlayBackgroundMusic1(true);
                    Console.Clear();
                    break;

                case "2":
                    Console.Clear();
                    GameRules.Page();
                    break;

                case "3":
                    Console.Clear();
                    ViewLeaderboard.Page();
                    Console.Clear();
                    break;

                case "4":
                    Console.Clear();
                    ViewHistoryScores.Page(gamerID, name);
                    break;

                case "5":
                    Console.Clear();
                    MainMenu.Page();
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
