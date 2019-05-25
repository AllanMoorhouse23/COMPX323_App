using MongoDB.Bson;

namespace COMPX323_App
{
    class MongoProducts
    {
        public ObjectId Id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
    }
}
