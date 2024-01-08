using Newtonsoft.Json;
using PlatformInstall.Domain.Identity;
using PlatformInstall.Domain.Json;
using PlatformInstall.Infraestruture;
using PlatformInstall.Scripts;
using System.Data;
using System.Diagnostics;

namespace PlatformInstall.Pages
{
    public partial class Install : Form
    {
        DataIdentity _identity;
        public Install(DataIdentity dataIdentity)
        {
            _identity = dataIdentity;
            InitializeComponent();
        }
        public void Execute(string path)
        {
            ConfigureProgressBar();
            progressBar1.Value = 5;
            AtualizarRichTextBox("Iniciando a instalação do platform...");
            var firstPathBat = Path.Combine(path, "setup.bat");
            var ps1Path = Path.Combine(path, "setup.ps1");
            var pathGit = Path.Combine(path, "git.nddigital");
            AtualizarRichTextBox($"Criando o arquivo de bat para execução do processo no cmd na pasta {path}...");
            progressBar1.Value = 10;
            CreateBat(firstPathBat);

            AtualizarRichTextBox($"Criando o arquivo de ps1 para execução do processo no cmd na pasta {path}...");
            var script = ScriptsConst.Script1(pathGit);
            progressBar1.Value = 15;
            CreatePs1(path, script);

            ExecuteScript(pathGit, firstPathBat, "Clonando repositório: https://tfs.ndd.com.br/tfs/NDD-DECollection/Third%20Part%20Logistic/_git/nddFrete_Platform");
            AtualizarRichTextBox($"Criando arquivo de log na pasta {pathGit}");
            AtualizarRichTextBox($"Clonagem do repositório realizada com sucesso.");
            progressBar1.Value = 20;
            ReplaceClientId(pathGit);
            ChangeConfigurationNddGatewayJson(pathGit);
            ChangeFileEnv(pathGit);
            DeleteScript(ps1Path);

            var script2 = ScriptsConst.Script2(pathGit);
            CreatePs1(path, script2);
            ExecuteScript(pathGit, firstPathBat, "Instalando pacotes typescript...");
            AtualizarRichTextBox($"Pacotes instalados com sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 25;
            AtualizarRichTextBox($"Script apagado com suceso");

            var installNdk = ScriptsConst.InstallNdk(pathGit);
            CreatePs1(path, installNdk);
            ExecuteScript(pathGit, firstPathBat, "Instalando pacotes NDK globalmente...");
            AtualizarRichTextBox($"Pacotes instalados com sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 30;
            AtualizarRichTextBox($"Script apagado com suceso");

            var loadNdkPlatform = ScriptsConst.LoadNdkPlatform(pathGit);
            CreatePs1(path, loadNdkPlatform);
            ExecuteScript(pathGit, firstPathBat, "Clonando projetos da platform...");
            AtualizarRichTextBox($"Clonagem do repositório realizada com sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 35;
            AtualizarRichTextBox($"Script apagado com suceso");

            var basePathProjects = Path.Combine(path, "\\nddFrete_Platform\\projects");
            var shipper = Path.Combine(basePathProjects, "shipper");
            var clientShipper = Path.Combine(basePathProjects, "client-shipper");

            if (Directory.Exists(shipper))
            {
                var deletePath = ScriptsConst.RemoveShipper(pathGit);
                CreatePs1(path, deletePath);
                ExecuteScript(pathGit, firstPathBat, "Removendo pastas da shipper");
                AtualizarRichTextBox($"Remoção realizada com sucesso.");
                DeleteScript(ps1Path);

            }
            if (Directory.Exists(clientShipper))
            {
                var deletePath = ScriptsConst.RemoveClientShipper(pathGit);
                CreatePs1(path, deletePath);
                ExecuteScript(pathGit, firstPathBat, "Removendo pastas da client-shipper");
                AtualizarRichTextBox($"Remoção realizada com sucesso.");
                DeleteScript(ps1Path);

            }
            progressBar1.Value = 40;

            var ndkLoadShipper = ScriptsConst.NdkLoadShipper(pathGit);
            CreatePs1(path, ndkLoadShipper);
            ExecuteScript(pathGit, firstPathBat, "Clonando pasta da shipper");
            AtualizarRichTextBox($"Clonagem do repositório realizada com sucesso..");
            DeleteScript(ps1Path);
            progressBar1.Value = 45;
            AtualizarRichTextBox($"Script apagado com suceso");

            var ndkLoadClientShipper = ScriptsConst.NdkLoadClient(pathGit);
            CreatePs1(path, ndkLoadClientShipper);
            ExecuteScript(pathGit, firstPathBat, "Clonando pasta da client-shipper");
            AtualizarRichTextBox($"Clonagem do repositório realizada com sucesso..");
            DeleteScript(ps1Path);
            progressBar1.Value = 50;
            AtualizarRichTextBox($"Script apagado com suceso");

            var ndkInstallApps = ScriptsConst.NdkInstallApps(pathGit);
            CreatePs1(path, ndkInstallApps);
            ExecuteScript(pathGit, firstPathBat, "Instalando apps da platform");
            AtualizarRichTextBox($"Instalado com sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 55;
            AtualizarRichTextBox($"Script apagado com suceso");

            var buildCore = ScriptsConst.BuildCore(pathGit);
            CreatePs1(path, buildCore);
            ExecuteScript(pathGit, firstPathBat, "Buildando pacotes core");
            AtualizarRichTextBox($"Build realizado sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 60;
            AtualizarRichTextBox($"Script apagado com suceso");

            var buildGlobalStyles = ScriptsConst.BuildGlobalStyles(pathGit);
            CreatePs1(path, buildGlobalStyles);
            ExecuteScript(pathGit, firstPathBat, "Buildando pacotes GlobalStyles");
            AtualizarRichTextBox($"Build realizado sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 65;
            AtualizarRichTextBox($"Script apagado com suceso");

            var buildLayout = ScriptsConst.BuildLayout(pathGit);
            CreatePs1(path, buildLayout);
            ExecuteScript(pathGit, firstPathBat, "Buildando pacotes Layout");
            AtualizarRichTextBox($"Build realizado sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 70;
            AtualizarRichTextBox($"Script apagado com suceso");

            var buildGateway = ScriptsConst.BuildGateway(pathGit);
            CreatePs1(path, buildGateway);
            ExecuteScript(pathGit, firstPathBat, "Buildando pacotes Gateway");
            AtualizarRichTextBox($"Build realizado sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 75;
            AtualizarRichTextBox($"Script apagado com suceso");

            var buildPlatformBrowser = ScriptsConst.BuildPlatformBrowser(pathGit);
            CreatePs1(path, buildPlatformBrowser);
            ExecuteScript(pathGit, firstPathBat, "Buildando pacotes PlatformBrowser");
            AtualizarRichTextBox($"Build realizado sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 80;
            AtualizarRichTextBox($"Script apagado com suceso");

            var buildShipper = ScriptsConst.BuildShipper(pathGit);
            CreatePs1(path, buildShipper);
            ExecuteScript(pathGit, firstPathBat, "Buildando pacotes shipper");
            AtualizarRichTextBox($"Build realizado sucesso.");
            progressBar1.Value = 43;
            ChangeAppSettings(pathGit);
            DeleteScript(ps1Path);
            progressBar1.Value = 85;
            AtualizarRichTextBox($"Script apagado com suceso");

            var buildClientShipper = ScriptsConst.BuildClientShipper(pathGit);
            CreatePs1(path, buildClientShipper);
            ExecuteScript(pathGit, firstPathBat, "Buildando pacotes client-shipper");
            AtualizarRichTextBox($"Build realizado sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 90;
            AtualizarRichTextBox($"Script apagado com suceso");

            var installProjectsDocker = ScriptsConst.InstallProjectsDocker(pathGit);
            CreatePs1(path, installProjectsDocker);
            ExecuteScript(pathGit, firstPathBat, "Instalando projetos no docker");
            AtualizarRichTextBox($"Projetos instalados com sucesso.");
            DeleteScript(ps1Path);
            progressBar1.Value = 95;
            AtualizarRichTextBox($"Script apagado com suceso");
            MessageBox.Show("Plaform instalado com sucesso");

            progressBar1.Value = 100;
            AtualizarRichTextBox($"Criando banco de dados para platform...");
            ConnectionDatabase.CreateDatabases();
            AtualizarRichTextBox($"Banco de dados criado com sucesso.");
        }

        public void ExecuteScript(string workingDirectory, string script, string message)
        {

            using (Process processo = new Process())
            {
                try
                {
                    processo.StartInfo.FileName = script;
                    processo.StartInfo.WorkingDirectory = workingDirectory;
                    processo.EnableRaisingEvents = true;
                    processo.StartInfo.CreateNoWindow = false;

                    AtualizarRichTextBox(message);
                    processo.Start();
                    processo.WaitForExit();
                    processo.Dispose();
                }
                catch (Exception)
                {
                    throw new Exception("Ocorreu um erro ao rodar o script.");
                }
                finally
                {
                    processo.Dispose();
                }
            }
        }

        private void AtualizarRichTextBox(string texto)
        {
            if (logProgress.InvokeRequired)
            {
                logProgress.Invoke((MethodInvoker)delegate
                {
                    AtualizarRichTextBox(texto);
                });
            }
            else
            {
                logProgress.AppendText(texto + Environment.NewLine);
                logProgress.SelectionStart = logProgress.Text.Length;
                logProgress.ScrollToCaret();
            }
        }

        private void ChangeAppSettings(string path)
        {
            var newPath = Path.Combine(path, "nddFrete_Platform\\projects\\shipper\\Server\\NDDigital.Shipper.ShipperAPI\\appsettings.json");
            UpdateJsonFile<Appsettings>(newPath, clients =>
            {
                clients.General.ConnectionStringCache = "191.235.97.40:6379";
                clients.General.StorageUrl = "https://nddfrete-dev-storage.e-datacenter.nddigital.com.br/";
                clients.UserProvider.ClientID = _identity.UserSdk.ClientId;
                clients.UserProvider.ClientSecret = _identity.UserSdk.SecretKey;
            });
        }

        private void richTextBox1_TextChanged_1(object? sender, EventArgs e)
        {
            // Código para manipular a mudança de texto no RichTextBox, se necessário
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void CreateBat(string pathBat)
        {
            AtualizarRichTextBox("Criando o arquivo de script Bat para execução do script:");
            string scriptBat = @"@echo off
        powershell.exe -ExecutionPolicy Bypass -File ""%~dp0setup.ps1""
        pause";

            try
            {
                File.WriteAllText(pathBat, scriptBat);
                AtualizarRichTextBox("Arquivo de lote criado com sucesso em: " + pathBat);
            }
            catch (Exception ex)
            {
                AtualizarRichTextBox("Erro ao criar o arquivo de lote: " + ex.Message);
            }
        }

        private void CreatePs1(string path, string script)
        {
            AtualizarRichTextBox("Criando o arquivo de script ps1 para execução do script:");
            var pathPs1 = Path.Combine(path, "setup.ps1");
            var pathGit = Path.Combine(path, "git.nddigital");

            if (!Directory.Exists(pathGit))
                Directory.CreateDirectory(pathGit);

            File.WriteAllText(pathPs1, script);
            AtualizarRichTextBox("Arquivo de lote criado com sucesso em: " + pathPs1);
        }

        private void ReplaceClientId(string path)
        {
            UpdateJsonFile<Configuracao>(Path.Combine(path, "nddFrete_Platform\\configs\\application.spec.json"), configuracao =>
            {
                foreach (var app in configuracao.apps)
                {
                    if (app.client_id == "frete-web")
                        app.client_id = _identity.UserFrontEnd.ClientId;
                }
            });
        }

        public void ChangeFileEnv(string path)
        {
            try
            {
                if (!Path.Exists(path))
                {
                    AtualizarRichTextBox($"Não foi possivel encontrar o arquivo.");
                    return;
                }

                string keyToModify = "PLATFORM_AUTH_URL";
                string newValue = "https://nddfrete-dev.e-datacenter.nddigital.com.br/";

                var pathEnv = Path.Combine(path, "nddFrete_Platform\\configs\\.env");

                var lines = File.ReadLines(pathEnv)
                 .Select(line =>
                     line.StartsWith(keyToModify + "=") ? keyToModify + "= " + newValue :
                     line.StartsWith("PLATFORM_AUTH_SCOPE=") ? line.Replace("nddfrete-tpl-api", "") :
                     line).ToList();

                if (lines.Any(line => line.StartsWith(keyToModify + "= ")))
                {
                    AtualizarRichTextBox($"Arquivo {pathEnv} atualizado com sucesso.");
                }
                else
                {
                    AtualizarRichTextBox($"Chave não encontrada no arquivo");
                }

                File.WriteAllLines(pathEnv, lines);
            }
            catch (Exception ex)
            {
                AtualizarRichTextBox($"Ocorreu um erro na atualização do arquivo. {ex.Message}");
            }
            
        }

        public void ChangeConfigurationNddGatewayJson(string path)
        {
            try
            {
                if (!Path.Exists(path))
                {
                    AtualizarRichTextBox($"Não foi possivel encontrar o arquivo.");
                    return;
                }

                UpdateJsonFile<NddGateway>(Path.Combine(path, "nddFrete_Platform\\configs\\ndd-gateway.dev.docker.json"), configuracao =>
                {
                    foreach (var route in configuracao.Routes)
                    {
                        if (route.UpstreamPathTemplate == "/policies-api/{url}")
                        {
                            route.DownstreamScheme = "https";
                            route.DownstreamHostAndPorts = new List<DownstreamHostAndPorts>
                {
                    new DownstreamHostAndPorts
                    {
                        Host = "nddfrete-pol-dev.e-datacenter.nddigital.com.br",
                        Port = 443
                    }
                };
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                AtualizarRichTextBox($"Ocorreu um erro na atualização do arquivo. {ex.Message}");
            }
           
        }

        private void UpdateJsonFile<T>(string path, Action<T> updateAction)
        {
            AtualizarRichTextBox($"Iniciando a atualização do arquivo JSON em {path}...");

            try
            {
                if (!Path.Exists(path))
                {
                    AtualizarRichTextBox($"Não foi possivel encontrar o arquivo.");
                    return;
                }

                string jsonConteudo = File.ReadAllText(path);
                T configuracao = JsonConvert.DeserializeObject<T>(jsonConteudo);

                updateAction(configuracao);

                JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                string novoJsonConteudo = JsonConvert.SerializeObject(configuracao, jsonSettings);

                File.WriteAllText(path, novoJsonConteudo);

                AtualizarRichTextBox($"Arquivo {Path.GetFileName(path)} atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                AtualizarRichTextBox($"Ocorreu um erro na atualização do arquivo. {ex.Message}");
            }
        }

        public void DeleteScript(string ps1)
        {
            try
            {
                File.Delete(ps1);
            }
            catch (Exception ex)
            {
                AtualizarRichTextBox($"Erro ao excluir o arquivo: {ex.Message}"); ;
            }
        }

        private void searchFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var pathUser = folderBrowserDialog1.SelectedPath;
                textBoxUser.Text = pathUser;
                buttonInstall.Enabled = true;
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            Execute(textBoxUser.Text);
            Finish.Enabled = true;
        }

        private void ConfigureProgressBar()
        {
            progressBar1.Location = new Point(68, 406);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(549, 23);
            progressBar1.TabIndex = 16;
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
        }
    }
}
