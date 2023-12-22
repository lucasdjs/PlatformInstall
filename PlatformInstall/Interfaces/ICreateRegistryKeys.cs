using PlatformInstall.Domain.Identity;

namespace PlatformInstall.Interfaces
{
    public interface ICreateRegistryKeys
    {
        public void CreateKeyShipper(User user);
        public void CreateKeyShipperTest(User user);
    }
}
