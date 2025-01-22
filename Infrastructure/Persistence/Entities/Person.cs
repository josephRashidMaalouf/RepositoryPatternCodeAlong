﻿using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Application.Models;

namespace Infrastructure.Persistence.Entities;

public class Person
{
    [Key] public required Guid Id { get; set; }
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