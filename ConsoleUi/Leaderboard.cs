using System.Data.SqlClient;

namespace ConsoleUi
{
    class Leaderboard
    {
        static string connectionString = DatabaseConnection.ConnectionString;

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

                int times = 1;

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];


                    Console.WriteLine($"{times}: {gamerName.PadRight(20)}: {score}");
                    times++;
                    if (times == 10)
                    {
                        break;
                    }
                }
            }

            Console.Write("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void DisplayLeaderboardDaily()
        {
            Console.WriteLine("Today's Top 10 Leaderboard Scores");
            Console.WriteLine("---------------------------------");

            string query = @"SELECT TOP 10 RANK() OVER (PARTITION BY s.gamer_id ORDER BY MAX(s.score) DESC) as rank, 
                             s.gamer_id, g.gamer_name, MAX(s.score) AS max_score
                             FROM [leaderboard].[dbo].[Gamer] g 
                             JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
                             WHERE DATEPART(day, s.date_time) = DATEPART(day, GETDATE())
                             GROUP BY s.gamer_id, g.gamer_name
                             ORDER BY max_score DESC;";

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
            {
                sql_con.Open();
                SqlDataReader reader = sql_cmd.ExecuteReader();

                int times = 1;

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{times}: {gamerName.PadRight(20)}: {score}");
                    times++;
                    if (times == 10)
                    {
                        break;
                    }
                }
            }

            Console.Write("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void DisplayLeaderboardWeekly()
        {
            Console.WriteLine("This Week's Top 10 Leaderboard Scores");
            Console.WriteLine("-------------------------------------");

            string query = @"SELECT TOP 10 RANK() OVER (PARTITION BY s.gamer_id ORDER BY MAX(s.score) DESC) as rank,
                             s.gamer_id, g.gamer_name, MAX(s.score) AS max_score
                             FROM [leaderboard].[dbo].[Gamer] g 
                             JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
                             WHERE DATEPART(week, s.date_time) = DATEPART(week, GETDATE())
                             GROUP BY s.gamer_id, g.gamer_name
                             ORDER BY max_score DESC;";

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
            {
                sql_con.Open();
                SqlDataReader reader = sql_cmd.ExecuteReader();

                int times = 1;

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{times}: {gamerName.PadRight(20)}: {score}");
                    times++;
                    if (times == 10)
                    {
                        break;
                    }
                }
            }

            Console.Write("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void DisplayLeaderboardMonthly()
        {
            Console.WriteLine("This Month's Top 10 Leaderboard Scores");
            Console.WriteLine("--------------------------------------");

            string query = @"SELECT TOP 10 RANK() OVER (PARTITION BY s.gamer_id ORDER BY MAX(s.score) DESC) as rank,
                             s.gamer_id, g.gamer_name, MAX(s.score) AS max_score
                             FROM [leaderboard].[dbo].[Gamer] g 
                             JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
                             WHERE DATEPART(month, s.date_time) = DATEPART(month, GETDATE())
                             GROUP BY s.gamer_id, g.gamer_name
                             ORDER BY max_score DESC;";

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
            {
                sql_con.Open();
                SqlDataReader reader = sql_cmd.ExecuteReader();

                int times = 1;

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{times}: {gamerName.PadRight(20)}: {score}");
                    times++;
                    if (times == 10)
                    {
                        break;
                    }
                }
            }

            Console.Write("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}

