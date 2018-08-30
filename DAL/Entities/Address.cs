namespace DAL
{
    public abstract class Address
    {
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string AddressContent { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}