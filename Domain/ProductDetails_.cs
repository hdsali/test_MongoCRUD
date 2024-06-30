using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoTest7CQRS.Domain
{
    public class ProductDetails1
    {
        
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id
            {
                get;
                set;
            }
            [BsonElement("ProductName")]
            public string ProductName
            {
                get;
                set;
            }
            public string ProductDescription
            {
                get;
                set;
            }
            public int ProductPrice
            {
                get;
                set;
            }
            public int ProductStock
            {
                get;
                set;
            }
        
    }

}
