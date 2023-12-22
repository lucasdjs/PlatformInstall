using Microsoft.Win32;
using PlaformInstall.Interfaces;
using PlatformInstall.Domain.RegistryKey;
using PlatformInstall.Interfaces;
using User = PlatformInstall.Domain.Identity.User;

namespace PlaformInstall.Services
{
    public class CreateRegistryKeysService : ICreateRegistryKeys
    {
        public CreateRegistryKeysService()
        {
        }

        public void CreateKeyShipper(User user)
        {
            try
            {
                var shipperKey = new ShipperKey(user);
                // Caminho para a chave no Registro do Windows
                string registryPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\NDDigital\Shipper";

                var properties = shipperKey.GetType().GetProperties();

                foreach (var property in properties)
                {
                    // Obtém o valor da propriedade atual
                    var value = property.GetValue(shipperKey);

                    // Define o valor no Registro
                    if(property.Name == nameof(shipperKey.CreateQueues) || property.Name == nameof(shipperKey.CriticalErrorTimeout))
                    {
                        Registry.SetValue(registryPath, property.Name, value, RegistryValueKind.DWord);
                    }
                    else
                    {
                        Registry.SetValue(registryPath, property.Name, value);
                    }
                }
                Console.WriteLine("Chaves e valores adicionados com sucesso ao Registro.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        public void CreateKeyShipperTest(User user)
        {
            try
            {
                var shipperKey = new ShipperKeyTest(user);
                // Caminho para a chave no Registro do Windows
                string registryPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\NDDigital\Shipper_Test";

                var properties = shipperKey.GetType().GetProperties();

                foreach (var property in properties)
                {
                    // Obtém o valor da propriedade atual
                    var value = property.GetValue(shipperKey);

                    // Define o valor no Registro
                    if (property.Name == nameof(shipperKey.CreateQueues) || property.Name == nameof(shipperKey.CriticalErrorTimeout))
                    {
                        Registry.SetValue(registryPath, property.Name, value, RegistryValueKind.DWord);
                    }
                    else
                    {
                        Registry.SetValue(registryPath, property.Name, value);
                    }
                }
                Console.WriteLine("Chaves e valores adicionados com sucesso ao Registro.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
