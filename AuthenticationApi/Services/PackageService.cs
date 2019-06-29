using System.Collections.Generic;
using System.Linq;
using AuthenticationApi.Models;
using AuthenticationApi.Models.DbModels;

namespace AuthenticationApi.Services
{
    public class PackageService : IPackageService
    {
        private static IList<PackageModel> _localPackages = new List<PackageModel>();


        public IEnumerable<PackageModel> GetAll()
        {
            return _localPackages;
        }

        public bool CreatePackage(PackageModel package)
        {
            _localPackages.Add(package);

            return true;
        }

        public bool UpdatePackage(string trackingNumber, PackageModel package)
        {
            var existing = _localPackages.SingleOrDefault(p => p.TrackingNumber == trackingNumber);

            if (existing == null)
                return false;

            _localPackages.Remove(existing);
            _localPackages.Add(package);

            return true;
        }

        public bool DeletePackage(string trackingNumber)
        {
            var existing = _localPackages.SingleOrDefault(p => p.TrackingNumber == trackingNumber);

            if (existing == null)
                return false;

            _localPackages.Remove(existing);
            return true;
        }
    }
}
