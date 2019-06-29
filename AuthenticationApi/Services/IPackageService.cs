using System.Collections.Generic;
using AuthenticationApi.Models;

namespace AuthenticationApi.Services
{
    public interface IPackageService
    {
        IEnumerable<PackageModel> GetAll();
        bool CreatePackage(PackageModel package);
        bool UpdatePackage(string trackingNumber, PackageModel package);
        bool DeletePackage(string trackingNumber);
    }
}