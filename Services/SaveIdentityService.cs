using PlaformInstall.Interfaces;
using PlaformInstall.Services;
using PlatformInstall.Domain.Identity;
using PlatformInstall.Interfaces;

namespace PlatformInstall.Services
{
    public class SaveIdentityService : ISaveIdentityService
    {
        private readonly ICreateRegistryKeys _createRegistryKeys;

        public SaveIdentityService(ICreateRegistryKeys createRegistryKeys)
        {
            _createRegistryKeys = createRegistryKeys;
        }

        public void Process(DataIdentity dataIdentity)
        {
            _createRegistryKeys.CreateKeyShipper(dataIdentity.UserBackEnd);
            _createRegistryKeys.CreateKeyShipperTest(dataIdentity.UserBackEnd);
            MessageBox.Show("Configuração salva com sucesso!");
        }

    }
}
