using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleUi
{
    internal class UserHistoryScores
    {
        static string connectionString = DatabaseConnection.ConnectionString;

        public static void DisplayUserHistoryScores()
        {
            Console.WriteLine("History Score of " + name + "!\n");
            Console.WriteLine("------------------------------");

            string query = @"SELECT s.score, s.data_time
                             FROM [leaderboard].[dbo].[Gamer] g
                             JOIN [leaderboard].[dbo].[Score] s ON g.gamer_id = s.gamer_id
                             WHERE name = g.gamer_name
                             ORDER BY s.data_time DESC;";

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
        }
}
