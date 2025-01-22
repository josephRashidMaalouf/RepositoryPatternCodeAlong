using System.ComponentModel.DataAnnotations;
using Application.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.MongoDb.Entities;

public class Person
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public required Guid Id { get; set; }
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(50)]
    public required string LastName { get; set; }
}

public static class PeopleExtensions
{
    public static Person ToEntity(this PersonModelBase model)
    {
        if(model is ReadPersonModel readPersonModel)
        {
            return new Person
            {
                Id = readPersonModel.Id,
                FirstName = readPersonModel.FirstName,
                LastName = readPersonModel.LastName
            };
        }

        return new Person()
        {
            Id = Guid.NewGuid(),
            FirstName = model.FirstName,
            LastName = model.LastName
        };
    }
    public static ReadPersonModel ToReadModel(this Person entity)
    {
        return new ReadPersonModel()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName
        };
    }
 
}