namespace LearnMath.Domain
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public Address() { }
        public Address(Guid id, string street, string city, string country, string postCode) 
        {
            Id = id;
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;
        }
    }
}