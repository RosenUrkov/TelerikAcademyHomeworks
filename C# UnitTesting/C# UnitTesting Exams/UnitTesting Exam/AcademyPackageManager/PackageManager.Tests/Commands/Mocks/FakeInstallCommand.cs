using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.Mocks
{
    internal class FakeInstallCommand : InstallCommand
    {
        public FakeInstallCommand(IInstaller<IPackage> installer, IPackage package) : base(installer, package)
        {
        }

        public IInstaller<IPackage> GetInstaller()
        {
            return this.Installer;
        }

        public IPackage GetPackage()
        {
            return this.Package;
        }
    }
}
