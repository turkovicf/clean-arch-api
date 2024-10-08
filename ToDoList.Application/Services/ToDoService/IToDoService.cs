using ToDoList.Application.Dtos;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Services.ToDoService
{
    public interface IToDoService
    {
        Task<List<GetToDoDto>> GetToDosAsync();
        Task<GetToDoDto> GetToDoByIdAsync(Guid Id);
        Task<GetToDoDto> CreateToDoAsync(CreateToDoDto newToDo);
        Task<GetToDoDto> UpdateToDoAsync(Guid id, UpdateToDoDto updatedToDo);
        Task<bool> DeleteToDoByIdAsync(Guid id);

    }
}
