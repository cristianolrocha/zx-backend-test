using System.Collections.Generic;

namespace pdv.Models
{
    public class CoverageArea
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }

    public class Address
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Pdv
    {
        public string id { get; set; }
        public string tradingName { get; set; }
        public string ownerName { get; set; }
        public string document { get; set; }
        public CoverageArea coverageArea { get; set; }
        public Address address { get; set; }
    }
}
