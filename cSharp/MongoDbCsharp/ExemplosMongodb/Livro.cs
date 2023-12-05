using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExemplosMongodb;

public class Livro
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Titulo { get; set; }

    public string Autor { get; set; }

    public int Ano { get; set; }

    public int Paginas { get; set; }

    public List<string> Assunto { get; set; }
}