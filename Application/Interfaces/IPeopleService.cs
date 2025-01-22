using Application.Models;

namespace Application.Interfaces;

public interface IPeopleService
{
    Task<IEnumerable<ReadPersonModel>> GetAllAsync();
    Task<ReadPersonModel> AddAsync(AddPersonModel model);
}