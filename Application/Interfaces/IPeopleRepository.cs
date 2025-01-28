using Application.Models;

namespace Application.Interfaces;

public interface IPeopleRepository 
{
    Task<IEnumerable<ReadPersonModel>> GetAllAsync();
    Task<AddPersonModel> AddAsync(AddPersonModel model);
}