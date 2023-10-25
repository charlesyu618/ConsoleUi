using System;
using System.Data.SqlClient;

namespace ConsoleUi
{
    class Program
    {
        static string connectionString = @"Data Source=charles\SQLEXPRESS;Initial Catalog=leaderboard;Integrated Security=True;";

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            string userName;

            while (true)
            {
                Console.WriteLine("   Welcome to the Snake Game");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. View Leaderboard");
                Console.WriteLine("4. Test GameMenu");
                Console.WriteLine("x. Exit");
                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        userName = Login.login();
                        Console.Clear();
                        GameMenu(userName);
                        break;

                    case "2":
                        Console.Clear();
                        userName = Login.login();
                        Console.Clear();
                        GameMenu(userName);
                        break;

                    case "3":
                        Console.Clear();
                        Leaderboard.DisplayLeaderboardOverall();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        GameMenu("Player_XXX");
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

        static void GameMenu(string name)
        {
            string userName = name;
            int gamerID = -1;

            // Get gamer_id from db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [gamer_id] FROM [leaderboard].[dbo].[Gamer] WHERE [gamer_name] = @GamerName", connection))
                {
                    command.Parameters.AddWithValue("@GamerName", userName);
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
                Console.WriteLine("2. View Leaderboard");
                Console.WriteLine("3. Log Out");
                Console.WriteLine("x. Exit");
                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                int gameScore = 0;
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        gameScore = new ConsoleUi.Game().Start();
                        Console.Clear();
                        InsertScore(gamerID, DateTime.Now, gameScore);
                        break;

                    case "2":
                        Console.Clear();
                        Leaderboard.DisplayLeaderboardOverall();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        MainMenu();
                        return;

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


        static void InsertScore(int gamerId, DateTime date, int score)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO [leaderboard].[dbo].[Score] ([gamer_id], [date], [score]) VALUES (@GamerId, @Date, @Score)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@GamerId", gamerId);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Score", score);

                    command.ExecuteNonQuery();
                }
            }

        }
    }
}