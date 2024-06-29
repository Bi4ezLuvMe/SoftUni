using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    public class Deliverer
    {
        public Deliverer(string id, string name)
        {
            Id = id;
            Name = name;
            packages = new List<Package>();
        }

        public string Id { get; set; }

        public string Name { get; set; }
        public List<Package> packages { get; set; }
    }
}
