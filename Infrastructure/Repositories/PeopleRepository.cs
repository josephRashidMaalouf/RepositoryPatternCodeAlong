using Application.Interfaces;
using Application.Models;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PeopleRepository : IPeopleRepository
{
    private readonly AppDbContext _context;

    public PeopleRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ReadPersonModel>> GetAllAsync()
    {
        //var people = await _context.People.ToListAsync();
        //var readModels = new List<ReadPersonModel>();
        //foreach (var person in people)
        //{
        //    readModels.Add(person.ToReadModel());
        //}
        //return readModels;

        return await _context.People.Select(p => p.ToReadModel()).ToListAsync();
    }

    public async Task<ReadPersonModel> AddAsync(AddPersonModel model)
    {
        var entity = model.ToEntity();
        await _context.People.AddAsync(model.ToEntity());
        await _context.SaveChangesAsync();
        return entity.ToReadModel();
    }
}