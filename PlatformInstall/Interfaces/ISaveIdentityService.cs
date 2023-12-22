using PlatformInstall.Domain.Identity;

namespace PlaformInstall.Interfaces
{
    public interface ISaveIdentityService
    {
        public void Process(DataIdentity dataIdentity);
    }
}
