using Application.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.sql.Entities
{
    public class Person
    {
        [Key]
        public required Guid Id { get; set; }

        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(100)]
        public required string LastName { get; set; }

    }

    public static class PersonExtensions
    {
        public static ReadPersonModel ToModel(this Person person)
        {
            return new ReadPersonModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
            };
        }

        public static Person ToEntity(this AddPersonModel model)
        {
            return new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }
    }
}
