using Application.Models;

namespace Application.Interfaces;

public interface IPeopleRepository 
{
    Task<IEnumerable<ReadPersonModel>> GetAllAsync();
    Task<ReadPersonModel> AddAsync(AddPersonModel model);
}