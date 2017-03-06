using System.Collections.Generic;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;

namespace PackageManager.Tests.Models.Mocks
{
    public class FakePackageRepository : PackageRepository
    {
        public bool IsCalled = false;

        public FakePackageRepository(ILogger logger, ICollection<IPackage> packages = null) : base(logger, packages)
        {
        }

        public override bool Update(IPackage package)
        {
            IsCalled = true;
            return IsCalled;
        }
    }
}
