using System;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;

namespace ConsoleUi
{
    class SignUp
    {
        static string connectionString = @"Data Source=charles\SQLEXPRESS;Initial Catalog=leaderboard;Integrated Security=True;";

        public static void register()
        {
            //Console.WriteLine("   Welcome to the Snake Game");
            Console.WriteLine("           Sign Up");
            Console.WriteLine("------------------------------");

            while (true)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = ReadPassword();

                Console.Write("Confirm password: ");
                string confirmPassword = ReadPassword();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    Console.WriteLine("Please fill mandatory fields");
                }
                else if (password != confirmPassword)
                {
                    Console.WriteLine("Password does not match");
                }
                else if (IsUsernameExists(username))
                {
                    Console.WriteLine("Username already exists. Please try another.");
                }
                else
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    using (SqlConnection sql_con = new SqlConnection(connectionString))
                    {
                        sql_con.Open();
                        SqlCommand sql_cmd = new SqlCommand(
                            @"INSERT INTO [dbo].[Gamer] ([gamer_name], [password]) VALUES (@username, @hashedPassword)",
                            sql_con
                        );
                        sql_cmd.Parameters.AddWithValue("@username", username);
                        sql_cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                        sql_cmd.ExecuteNonQuery();
                        Console.WriteLine("Successfully registered!");
                    }
                    break;
                }
            }
        }

        private static bool IsUsernameExists(string gamer_name)
        {
            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [leaderboard].[dbo].[Gamer] WHERE gamer_name = @gamer_name", sql_con))
                {
                    command.Parameters.AddWithValue("@gamer_name", gamer_name);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        static string ReadPassword()
        {
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
            return password;
        }
    }
}
