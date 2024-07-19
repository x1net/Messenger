using MySql.Data.MySqlClient;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace client
{
    internal class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("MySqlClient") ?? throw new InvalidOperationException("Connection string 'MySqlClient' not found.");
        }

        public bool CreateUser(string username, string password, string userInfo, string blacklist, string comment, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = "INSERT INTO users (username, userpassword, userinfo, blacklist, comment) VALUES (@username, @userpassword, @userinfo, @blacklist, @comment)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@userpassword", password);
                        command.Parameters.AddWithValue("@userinfo", userInfo);
                        command.Parameters.AddWithValue("@blacklist", blacklist);
                        command.Parameters.AddWithValue("@comment", comment);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    errorMessage = "Користувач з таким логіном вже існує. Будь ласка, введіть інший логін.";
                }
                else
                {
                    errorMessage = "Виникла помилка при створенні користувача. Будь ласка, спробуйте ще раз.";
                }
                return false;
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(1) FROM users WHERE username = @username AND userpassword = @userpassword";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@userpassword", password);

                    var result = (long)command.ExecuteScalar();
                    return result == 1;
                }
            }
        }

        public (string userInfo, int userId) GetUserInfoAndId(string username)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT userinfo, id FROM users WHERE username = @username";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader["userinfo"].ToString(), Convert.ToInt32(reader["id"]));
                        }
                        else
                        {
                            return (string.Empty, -1);
                        }
                    }
                }
            }
        }

        public bool IsUserBlacklisted(int userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(1) FROM users WHERE id = @userId AND blacklist IS NOT NULL AND blacklist <> ''";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    var result = (long)command.ExecuteScalar();
                    return result == 1;
                }
            }
        }
    }
}
