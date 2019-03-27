namespace pdv.Models 
{
	public class PdvCreate
    {
        public string id { get; set; }
        public string tradingName { get; set; }
        public string ownerName { get; set; }
        public string document { get; set; }
        public CoverageArea coverageArea { get; set; }
        public Address address { get; set; }
    }
}