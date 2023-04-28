using ContratoPersistencia;
using MongoDB.Bson.Serialization.Attributes;


namespace app.Models;
public class Cliente : IEntidade
{
    public Cliente()
    {
        int timestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        this.Id = timestamp;
    }
    [BsonId]
    public int Id { get; set; }
    [BsonElement("nome")]

    public string Nome { get; set; }
    [BsonElement("telefone")]

    public string Telefone { get; set; }
}
