using System;
using System.Data.SqlClient;

namespace ConsoleUi
{
    class Program
    {
        static string connectionString = "Server=5900sql.infosci.cornell.edu;Database=leaderboard;User Id=test;Password=test2023;";

        static void Main(string[] args)
        {
            
            Program.MainMenu();
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
                        userName = SignUp.register();
                        Console.Clear();
                        GameMenu(userName);
                        break;

                    case "3":
                        Console.Clear();
                        ViewLeaderboard();
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
                        gameScore = new ConsoleUi.Game().Start(gamerID);
                        Console.Clear();
                        // new bug: can only insert score when gamer choose no for restart option 
                        InsertScore(gamerID, DateTime.Now.Date, gameScore);
                        break;

                    case "2":
                        Console.Clear();
                        ViewLeaderboard();
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

        static void ViewLeaderboard()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.WriteLine("Select a Leaderboard:");
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


        public static void InsertScore(int gamerId, DateTime date, int score)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO [leaderboard].[dbo].[Score] ([gamer_id], [date_time], [score]) VALUES (@GamerId, @Date, @Score)";

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
