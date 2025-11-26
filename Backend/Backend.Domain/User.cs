using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Domain
{
    public class User

    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
     
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NrPhone { get; set; }
        public string Address { get; set; }
        public string Salt { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Password { get; set; }
        public int LoginTryCount{ get; set; }
        public DateTime Deleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Inactive { get; set; }
    }
}
