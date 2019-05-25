using MongoDB.Bson;

namespace COMPX323_App
{
    class MongoCartItem
    {
        public ObjectId Id { get; set; }
        public int id { get; set; }
        public int quantity { get; set; }
    }
}
