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

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{gamerName.PadRight(20)}: {score}");
                }
            }
        }

        //  to do
        public static void DisplayLeaderboardMonthly()
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

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{gamerName.PadRight(20)}: {score}");
                }
            }
        }

        //  to do
        public static void DisplayLeaderboardWeekly()
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

                while (reader.Read())
                {
                    string gamerName = reader["gamer_name"].ToString();
                    int score = (int)reader["max_score"];

                    Console.WriteLine($"{gamerName.PadRight(20)}: {score}");
                }
            }
        }
    }
}