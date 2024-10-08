using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> GetToDosAsync();
        Task<ToDo> GetToDoByIdAsync(Guid id);
        Task<ToDo> CreateToDoAsync(ToDo newToDo);
        Task<ToDo> UpdateToDoAsync(Guid id, ToDo updatedToDo);
        Task<bool> DeleteToDoByIdAsync(Guid id);
    }
}
