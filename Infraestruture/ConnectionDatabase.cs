using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace PlatformInstall.Infraestruture
{
    public static class ConnectionDatabase
    {
        private static string connectionString = "Data Source=DESKTOP-5SNC0TF;User ID=sa;Password=321;TrustServerCertificate=true;";

        private static string[] databaseNames = { "Shipper", "Monitoring", "DocumentStorage", "Payment", "Carrier" };

        public static void CreateDatabases()
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
                            if (!DatabaseExists(connection, testDbName))
                            {
                                CreateDatabase(connection, testDbName);
                            }
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

        private static void SchemaCompare()
        {
            string sourceDacpacPath = @"C:\Caminho\Para\Seu\BancoDeDados_Source.dacpac";
            string targetDacpacPath = @"C:\Caminho\Para\Seu\BancoDeDados_Target.dacpac";

            // Configuração da comparação
            var deployOptions = $"/Action:DeployReport /SourceFile:{sourceDacpacPath} /TargetFile:{targetDacpacPath}";

            // Executar SqlPackage.exe para gerar o relatório de alterações
            string sqlPackagePath = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\150\SqlPackage.exe";

            Process process = new Process();
            process.StartInfo.FileName = sqlPackagePath;
            process.StartInfo.Arguments = deployOptions;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine("Relatório de Alterações:");
            Console.WriteLine(output);

            // Aplique as alterações usando a ação Publish
            string publishOptions = $"/Action:Publish /SourceFile:{sourceDacpacPath} /TargetFile:{targetDacpacPath}";

            process.StartInfo.Arguments = publishOptions;

            process.Start();
            process.WaitForExit();

            Console.WriteLine("Alterações aplicadas com sucesso.");
        }
    }
}
