using Application.Interfaces;
using Application.Models;

namespace Application.Services;

public class PeoplePeopleService : IPeopleService
{
    private readonly IPeopleRepository _peopleRepository;

    public PeoplePeopleService(IPeopleRepository repo)
    {
        _peopleRepository = repo;
    }


    public async Task<IEnumerable<ReadPersonModel>> GetAllAsync()
    {
        return await _peopleRepository.GetAllAsync();
    }

    public async Task<ReadPersonModel> AddAsync(AddPersonModel model)
    {
        return await _peopleRepository.AddAsync(model);
    }
}