using ContratoPersistencia;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;

namespace MongoDBPersistencia;
    public class BsonCustumSerializer<T> : SerializerBase<T> where T : IEntidade
    {
        public override T Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return BsonSerializer.Deserialize<T>(context.Reader);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, T value)
        {
            BsonSerializer.Serialize(context.Writer, value);
        }
    }
