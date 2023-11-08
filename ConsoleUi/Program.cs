using System;
using System.Data.SqlClient;

namespace ConsoleUi
{
    class Program
    {
        static string connectionString = DatabaseConnection.ConnectionString;
        static MusicPlayer musicPlayer = new MusicPlayer();

        static void Main(string[] args)
        {
            musicPlayer.PlayBackgroundMusic1(true);
            MainMenu.Page();
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
