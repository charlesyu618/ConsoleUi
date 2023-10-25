using System.Data.SqlClient;

namespace ConsoleUi
{
    class Leaderboard
    {
        static string connectionString = @"Data Source=charles\SQLEXPRESS;Initial Catalog=leaderboard;Integrated Security=True;";
        public static void DisplayLeaderboardOverall()
        {
            Console.WriteLine("  Top 10 Leaderboard Scores");
            Console.WriteLine("------------------------------");

            string query = @"SELECT TOP 10 g.gamer_name, MAX(s.score) AS max_score
                             FROM [leaderboard].[dbo].[Gamer] g 
                             JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
                             GROUP BY g.gamer_name
                             ORDER BY max_score DESC;";

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
            {
                sql_con.Open();
                SqlDataReader reader = sql_cmd.ExecuteReader();

                int times = 0;

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.Write(times);
                    Console.WriteLine($"{gamerName.PadRight(20)}: {score}");
                    times++;
                    if (times == 10)
                    {
                        break;
                    }
                }
            }

            // wait for user to quit
            while (true)
            {
                Console.Write("Press 'x' to quit: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "x")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }

        public static void DisplayLeaderboardDaily()
        {
            Console.WriteLine(" Today's Top 10 Leaderboard Scores");
            Console.WriteLine("------------------------------");

            string query = @"SELECT TOP 10 
                                   RANK() OVER (PARTITION BY s.gamer_id ORDER BY MAX(s.score) DESC) as rank,
                                   s.gamer_id, g.gamer_name, MAX(s.score) AS max_score
                             FROM [leaderboard].[dbo].[Gamer] g 
                             JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
                             WHERE DATEDIFF(day, s.date, GETDATE()) = 0 -- update leaderboard the 1st day in month (00:00) 
                             GROUP BY s.gamer_id, g.gamer_name
                             ORDER BY max_score DESC;";

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
            {
                sql_con.Open();
                SqlDataReader reader = sql_cmd.ExecuteReader();

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{gamerName.PadRight(20)}: {score}");
                }
            }

            // wait for user to quit
            while (true)
            {
                Console.Write("Press 'x' to quit: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "x")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }

        public static void DisplayLeaderboardWeekly()
        {
            Console.WriteLine(" This Week's Top 10 Leaderboard Scores");
            Console.WriteLine("------------------------------");

            string query = @"SELECT TOP 10 
                                   RANK() OVER (PARTITION BY s.gamer_id ORDER BY MAX(s.score) DESC) as rank,
                                   s.gamer_id, g.gamer_name, MAX(s.score) AS max_score
                             FROM [leaderboard].[dbo].[Gamer] g 
                             JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
                             WHERE DATEDIFF(week, s.date, GETDATE()) = 0
                             GROUP BY s.gamer_id, g.gamer_name
                             ORDER BY max_score DESC;";

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
            {
                sql_con.Open();
                SqlDataReader reader = sql_cmd.ExecuteReader();

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{gamerName.PadRight(20)}: {score}");
                }
            }

            // wait for user to quit
            while (true)
            {
                Console.Write("Press 'x' to quit: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "x")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }

        public static void DisplayLeaderboardMonthly()
        {
            Console.WriteLine(" This Month's Top 10 Leaderboard Scores");
            Console.WriteLine("------------------------------");

            string query = @"SELECT TOP 10 
                                   RANK() OVER (PARTITION BY s.gamer_id ORDER BY MAX(s.score) DESC) as rank,
                                   s.gamer_id, g.gamer_name, MAX(s.score) AS max_score
                             FROM [leaderboard].[dbo].[Gamer] g 
                             JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
                             WHERE DATEDIFF(month, s.date, GETDATE()) = 0
                             GROUP BY s.gamer_id, g.gamer_name
                             ORDER BY max_score DESC;";

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
            {
                sql_con.Open();
                SqlDataReader reader = sql_cmd.ExecuteReader();

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{gamerName.PadRight(20)}: {score}");
                }
            }

            // wait for user to quit
            while (true)
            {
                Console.Write("Press 'x' to quit: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "x")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }
    }
}