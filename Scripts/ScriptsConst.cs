using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace PlatformInstall.Scripts
{
    public class ScriptsConst
    {
        private static string logFilePath;
        public readonly static string InstallNodeCommand = "nvm install 14.16.0";
        public readonly static string UseNodeCommand = "nvm use 14.16.0";
        public readonly static string ClonePlatformCommand = "git clone https://tfs.ndd.com.br/tfs/NDD-DECollection/Third%20Part%20Logistic/_git/nddFrete_Platform";
        public readonly static string RedirectLogPath = "Start-Transcript -Path";
        public readonly static string SetGitNdd = "Set-Location -Path";
        public readonly static string SetPlatform = "Set-Location -Path \"C:\\git.nddigital\\nddFrete_Platform\"";
        public readonly static string LogType = "\"log_$(Get-Date -Format 'yyyyMMdd_HHmmss').txt\"";
        public readonly static string StopProcess = "Stop-Process -Name \"\"cmd\"\" -Force\"";


        public static void InitializeLog(string pathGit)
        {
            logFilePath = $"{pathGit}\\{LogType}";
        }

        public static string Script1(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"

                {logRedirect}

                # Instalação do NVM
                Write-Host ""Instalando o Node Version Manager (NVM)...""
                {InstallNodeCommand}

                # Usa a versão instalada do Node.js
                Write-Host ""{UseNodeCommand}""
                {UseNodeCommand}

                Write-Host ""NVM instalado com sucesso.""

                # Mudança para a pasta git.nddigital
                {SetGitNdd} {pathGit}

                # {ClonePlatformCommand}
                {ClonePlatformCommand}

    
                Stop-Process -Name ""cmd"" -Force
            ";
        }

        public static string Script2(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();
            return $@"
                {logRedirect}
                # Instalar pacotes typescript
                npm install typescript --save -g

                Stop-Process -Name ""cmd"" -Force";
        }

        public static string InstallNdk(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}

                # Instalar ndk
                npm install -g @ndk/cli

                Stop-Process -Name ""cmd"" -Force";
        }

        public static string LoadNdkPlatform(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}

                # Instalar ndk
                ndk load ndk-platform

                Stop-Process -Name ""cmd"" -Force";
        }

        public static string RemoveClientShipper(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Deletar as pastas
                Remove-Item -Path ""$gitNDDigitalPath\nddFrete_Platform\projects\client-shipper"" -Recurse -Force

               Stop-Process -Name ""cmd"" -Force";
        }

        public static string RemoveShipper(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Deletar as pastas
                                Remove-Item -Path ""$gitNDDigitalPath\nddFrete_Platform\projects\shipper"" -Recurse -Force
                 Stop-Process -Name ""cmd"" -Force";
        }

        public static string NdkLoadShipper(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Clonando shipper...
                 ndk load shipper
                Stop-Process -Name ""cmd"" -Force";
        }

        public static string NdkLoadClient(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Clonando client-shipper...
                 ndk load client-shipper
                 Stop-Process -Name ""cmd"" -Force";
        }

        public static string NdkInstallApps(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Instalando apps
                ndk install apps
                Stop-Process -Name ""cmd"" -Force";
        }

        public static string BuildCore(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Buildando pacotes da platform
                ndk run build core
                 Stop-Process -Name ""cmd"" -Force";
        }

        public static string BuildGlobalStyles(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Buildando pacotes da platform
                ndk run build global-styles
                 Stop-Process -Name ""cmd"" -Force";
        }

        public static string BuildLayout(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Buildando pacotes da platform
                ndk run build layout
                Stop-Process -Name ""cmd"" -Force";
        }

        public static string BuildGateway(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Buildando pacotes da platform
                ndk run build gateway
                 Stop-Process -Name ""cmd"" -Force";
        }

        public static string BuildPlatformBrowser(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Buildando pacotes da platform
                ndk run build platform-browser
                 Stop-Process -Name ""cmd"" -Force";
        }


        public static string BuildShipper(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Buildando pacotes da shipper
                ndk build shipper
                 Stop-Process -Name ""cmd"" -Force";
        }

        public static string BuildClientShipper(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                # Buildando pacotes da client-shipper
                ndk build shipper
                 Stop-Process -Name ""cmd"" -Force";
        }

        public static string LoginDocker(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                #Realizando login no docker
                docker login nddlabs.azurecr.io -Username nddLabs -Password ""DfNQ9CnZNV91b+6lcuTrPYW5NB9ERaJc""
                 Stop-Process -Name ""cmd"" -Force";
        }
        public static string InstallProjectsDocker(string pathGit)
        {
            ScriptsConst.InitializeLog(pathGit);
            var logRedirect = ScriptsConst.RedirectLog();

            return $@"
                {logRedirect}
                # Mudando para o diretório correto
                {SetPlatform}
                #Realizando login no docker
                docker login nddlabs.azurecr.io -Username nddLabs -Password ""DfNQ9CnZNV91b+6lcuTrPYW5NB9ERaJc""
               #Instalando projetos no docker
                ndk run start -d
                ndk run shipper -d
                ndk run client-shipper -d
                ndk run redis -d
                Stop-Process -Name ""cmd"" -Force";
        }

        public static string RedirectLog()
        {
            if (string.IsNullOrEmpty(logFilePath))
            {
                throw new InvalidOperationException("O caminho do log não foi inicializado. Chame InitializeLog antes de usar RedirectLog.");
            }

            return $@"
        # Redireciona a saída para o arquivo de log
        {RedirectLogPath} {logFilePath}
        ";
        }
    }
}
