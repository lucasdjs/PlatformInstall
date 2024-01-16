using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Microsoft.SqlServer.Dac.Compare;
using Microsoft.SqlServer.Dac;

namespace PlatformInstall.Infraestruture
{
    public static class ConnectionDatabase
    {
        private static string connectionString = "Data Source=DESKTOP-5SNC0TF;User ID=sa;Password=321;TrustServerCertificate=true;";

        private static string[] databaseNames = { "Shipper", "Monitoring", "DocumentStorage", "Payment", "Carrier" };

        public static void CreateDatabases(string path)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (var dbName in databaseNames)
                    {
                        if (!DatabaseExists(connection, dbName))
                        {
                            CreateDatabase(connection, dbName);

                            string testDbName = dbName + "_Test";

                            var scriptsFolderPath = Path.Combine(path, $"nddFrete_Platform\\projects\\shipper\\Server\\NDDigital.Shipper.DataBase.{dbName}");

                            if (!DatabaseExists(connection, testDbName))
                                CreateDatabase(connection, testDbName);

                            if (dbName == "Shipper")
                                ExecuteScriptsShipper(connectionString, scriptsFolderPath);
                        }
                        else
                        {
                            Console.WriteLine($"Banco de dados '{dbName}' já existe.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static void ExecuteScriptsShipper(string targetConnectionString, string path)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(targetConnectionString))
                {
                    connection.Open();

                    ExecuteScriptsInFolder(connection, Path.Combine(path, "address\\Tables"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "auth\\Tables"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "available\\Tables"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "carrier"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "dbo\\Tables"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "middleware\\Tables"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "otm\\Tables"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "processing\\Tables"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "Scripts"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "Security"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "Shipper\\Functions"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "Shipper\\Sequences"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "Shipper\\Tables"));
                    ExecuteScriptsInFolder(connection, Path.Combine(path, "taxconfig\\Tables"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a execução dos scripts: {ex.Message}");
            }
        }

        private static void ExecuteScriptsInFolder(SqlConnection connection, string folderPath)
        {
            string[] scriptFiles = Directory.GetFiles(folderPath, "*.sql");

            foreach (var scriptFile in scriptFiles)
            {
                string scriptContent = File.ReadAllText(scriptFile);

                using (SqlCommand command = new SqlCommand(scriptContent, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static bool DatabaseExists(SqlConnection connection, string databaseName)
        {
            if (connection == null)
            {
                Console.WriteLine("A conexão não foi inicializada.");
                return false;
            }

            string query = $"SELECT 1 FROM sys.databases WHERE name = @DatabaseName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DatabaseName", databaseName);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao verificar a existência do banco de dados: {ex.Message}");
                    return false;
                }
            }
        }

        private static void CreateDatabase(SqlConnection connection, string databaseName)
        {
            string createDatabaseQuery = $"CREATE DATABASE {databaseName}";

            using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine($"Banco de dados '{databaseName}' criado com sucesso!");
            }
        }
    }
}
