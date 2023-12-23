namespace PlatformInstall.Domain.Json
{
    class Configuracao
    {
        public string defaultApp { get; set; }
        public string authPath { get; set; }
        public List<App> apps { get; set; }
        public ErrorSettings errorSettings { get; set; }

        public Configuracao() { }
    }
}
