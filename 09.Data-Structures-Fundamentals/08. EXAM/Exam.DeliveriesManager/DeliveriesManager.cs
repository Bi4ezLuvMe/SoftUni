using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        Dictionary<string,Deliverer>deliversById = new Dictionary<string,Deliverer>();
        Dictionary<string,Package>packagesById = new Dictionary<string,Package>();
        public void AddDeliverer(Deliverer deliverer)
        {
            deliversById.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            packagesById.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!deliversById.ContainsKey(deliverer.Id) || !packagesById.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }
            deliverer.packages.Add(package);
            package.deliver = deliverer;
        }

        public bool Contains(Deliverer deliverer) => deliversById.ContainsKey(deliverer.Id);

        public bool Contains(Package package) => packagesById.ContainsKey(package.Id);

        public IEnumerable<Deliverer> GetDeliverers() => deliversById.Values;

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName() => deliversById.Values.OrderBy(x => x.packages.Count).ThenBy(x => x.Name);

        public IEnumerable<Package> GetPackages()=>packagesById.Values;

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver() => packagesById.Values.OrderBy(x => x.Weight).ThenBy(x => x.Receiver);

        public IEnumerable<Package> GetUnassignedPackages() => packagesById.Values.Where(x => x.deliver is null);
    }
}
