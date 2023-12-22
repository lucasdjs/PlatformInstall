using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using PlaformInstall.Interfaces;
using PlatformInstall.Domain.Identity;
using PlatformInstall.Domain.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace PlaformInstall.Services
{
    public class ScriptCommandService : IScriptCommandService
    {
        private DataIdentity _dataIdentity;
        private RichTextBox _logProgress;

        public ScriptCommandService(DataIdentity dataIdentity, RichTextBox logProgress)
        {
            _dataIdentity = dataIdentity;
            _logProgress = logProgress;
        }

        private void AtualizarRichTextBox(string texto)
        {
            if (_logProgress.InvokeRequired)
            {
                _logProgress.Invoke((MethodInvoker)delegate {
                    AtualizarRichTextBox(texto);
                });
            }
            else
            {
                _logProgress.AppendText(texto + Environment.NewLine);
            }
        }

        private void richTextBox1_TextChanged_1(object? sender, EventArgs e)
        {
            // Código para manipular a mudança de texto no RichTextBox, se necessário
        }

        public void Execute(string path)
        {

            string firstPathBat = Path.Combine(path, "setup.bat");

            CreateBat(firstPathBat);
            CreatePs1(path);

            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = firstPathBat;
                processo.EnableRaisingEvents = true;
                processo.StartInfo.CreateNoWindow = false;

                processo.Exited += (sender, e) =>
                {
                    var pathGit = Path.Combine(path, "git.nddigital");

                    ReplaceClientId(pathGit);

                    AtualizarRichTextBox("Script PowerShell concluído.");
                    processo.Dispose();
                };

                processo.Start();
                processo.WaitForExit();
            }
        }

        private void CreateBat(string pathBat)
        {
            string scriptBat = @"@echo off
        powershell.exe -ExecutionPolicy Bypass -File ""%~dp0setup.ps1""
        pause";

            try
            {
                File.WriteAllText(pathBat, scriptBat);
                Console.WriteLine("Arquivo de lote criado com sucesso em: " + pathBat);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar o arquivo de lote: " + ex.Message);
            }
        }

        private void CreatePs1(string path)
        {
            var pathPs1 = Path.Combine(path, "setup.ps1");
            var pathGit = Path.Combine(path, "git.nddigital");

            if (!Directory.Exists(pathGit))
            {
                Directory.CreateDirectory(pathGit);
            }

            string scriptPs1 = $@"$gitNDDigitalPath = ""{pathGit}""
            $logFilePath = Join-Path $gitNDDigitalPath ""log_$(Get-Date -Format 'yyyyMMdd_HHmmss').txt""

            # Redireciona a saída para o arquivo de log
            Start-Transcript -Path $logFilePath

            # Instalação do NVM
            Write-Host ""Instalando o Node Version Manager (NVM)...""

            # Instala uma versão específica do Node.js
            nvm install 14.16.0
            
            # Usa a versão instalada do Node.js
            nvm use 14.16.0

            Write-Host ""NVM instalado com sucesso.""

            # Mudança para a pasta git.nddigital
            Set-Location -Path $gitNDDigitalPath

            # Clonar o repositório
            git clone https://tfs.ndd.com.br/tfs/NDD-DECollection/Third%20Part%20Logistic/_git/nddFrete_Platform

            # Mudando para o diretório correto
            Set-Location -Path ""C:\git.nddigital\nddFrete_Platform""
                ";

            File.WriteAllText(pathPs1, scriptPs1);
        }

        private void ReplaceClientId(string path)
        {
            var pathFile = Path.Combine(path, "nddFrete_Platform\\configs\\application.spec.json");

            string jsonConteudo = File.ReadAllText(pathFile);

            Configuracao configuracao = JsonConvert.DeserializeObject<Configuracao>(jsonConteudo);

            foreach (var app in configuracao.apps)
            {
                if (app.client_id == "frete-web")
                {
                    app.client_id = _dataIdentity.UserFrontEnd.ClientId;
                }
            }

            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string novoJsonConteudo = JsonConvert.SerializeObject(new
            {
                defaultApp = configuracao.defaultApp,
                authPath = configuracao.authPath,
                errorSettings = configuracao.errorSettings,
                apps = configuracao.apps
            }, jsonSettings);

            File.WriteAllText(pathFile, novoJsonConteudo);

            Console.WriteLine("Arquivo atualizado com sucesso.");
        }
    }
}
