using MongoDB.Bson;

namespace COMPX323_App
{
    class MongoCustomer
    {
        public ObjectId Id { get; set; }
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string streetAdr { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
        public string password { get; set; }
        public MongoCartItem[] products { get; set; }
    }
}
