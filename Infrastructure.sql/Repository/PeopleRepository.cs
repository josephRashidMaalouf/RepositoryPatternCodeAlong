using Application.Interfaces;
using Application.Models;
using Infrastructure.sql.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.sql.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _context;

        public PeopleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ReadPersonModel> AddAsync(AddPersonModel model)
        {
            var entity = model.ToEntity();
            await _context.People.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ToModel();
        }

        public async Task<IEnumerable<ReadPersonModel>> GetAllAsync()
        {
            var people = await _context.People.ToListAsync();
            List<ReadPersonModel> peopleModels = new();
            foreach (var person in people)
            {
                var model = person.ToModel();
                peopleModels.Add(model);
            }

            return peopleModels;
        }
    }
}
