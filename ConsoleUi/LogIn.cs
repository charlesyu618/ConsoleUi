﻿using System;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using BCrypt.Net;

namespace ConsoleUi
{
    class LogIn
    {
        static string connectionString = @"Data Source=charles\SQLEXPRESS;Initial Catalog=leaderboard;Integrated Security=True;";

        public static void login()
        {
            //Console.WriteLine("   Welcome to the Snake Game");
            Console.WriteLine("            Log in");
            Console.WriteLine("------------------------------");

            while (true)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = ReadPassword();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Please fill mandatory fields");
                }
                else if (!IsUsernameExists(username))
                {
                    Console.WriteLine("Login failed, the username does not exist");
                }
                else
                {
                    string query = $"SELECT password FROM [leaderboard].[dbo].[Gamer] WHERE gamer_name = '{username}'";

                    using (SqlConnection sql_con = new SqlConnection(connectionString))
                    using (SqlCommand sql_cmd = new SqlCommand(query, sql_con))
                    {
                        sql_con.Open();
                        string storedHashedPassword = sql_cmd.ExecuteScalar() as string;
                        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);
                        if (isPasswordValid)
                        {
                            Console.WriteLine("Login successful!");
                            // Figure out after Login successful how to pass the gamer info (gamer_id) to game start page
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password, please try again");
                        }
                    }
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