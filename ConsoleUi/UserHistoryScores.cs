using ConsoleUi;
using System.Data.SqlClient;

internal class UserHistoryScores
{
    static string connectionString = DatabaseConnection.ConnectionString;

    public static void DisplayTop10HistoryScores(int gamerID, string name)
    {
        Console.WriteLine($"TOP 10 History Score of {name}!\n");
        Console.WriteLine("------------------------------");

        string query = @"
            SELECT TOP 10 s.score, s.date_time
            FROM [leaderboard].[dbo].[Gamer] g
            JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
            WHERE g.gamer_id = @GamerId
            ORDER BY s.score DESC";

        using (SqlConnection sql_con = new SqlConnection(connectionString))
        using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
        {
            sql_cmd.Parameters.AddWithValue("@GamerId", gamerID);
            sql_con.Open();
            SqlDataReader reader = sql_cmd.ExecuteReader();

            int times = 1;

            while (reader.Read())
            {
                int score = (int)reader["score"];
                DateTime date = (DateTime)reader["date_time"];

                Console.WriteLine($"{times}. Score: {score}, Date: {date}");
                times++;
            }
        }

        // Wait for the user to quit
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

    public static void DisplayRecent10HistoryScores(int gamerID, string name)
    {
        Console.WriteLine($"Recent 10 History Score of {name}!\n");
        Console.WriteLine("------------------------------");

        string query = @"
            SELECT TOP 10 s.score, s.date_time
            FROM [leaderboard].[dbo].[Gamer] g
            JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
            WHERE g.gamer_id = @GamerId
            ORDER BY s.date_time DESC;";

        using (SqlConnection sql_con = new SqlConnection(connectionString))
        using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
        {
            sql_cmd.Parameters.AddWithValue("@GamerId", gamerID);
            sql_con.Open();
            SqlDataReader reader = sql_cmd.ExecuteReader();

            int times = 1; // Start from 1

            while (reader.Read())
            {
                int score = (int)reader["score"];
                DateTime date = (DateTime)reader["date_time"];

                Console.WriteLine($"{times}. Score: {score}, Date: {date}");
                times++;
            }
        }

        // Wait for the user to quit
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

