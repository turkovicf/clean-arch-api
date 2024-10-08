using ToDoList.Application.Dtos;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services.ToDoService
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        
        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        public async Task<List<GetToDoDto>> GetToDosAsync()
        {
            var toDos = await _toDoRepository.GetToDosAsync();

            var toDosMapper = toDos.Select(toDo => new GetToDoDto
            {
                Id = toDo.Id,
                Name = toDo.Name,
                Description = toDo.Description,
                Status = toDo.Status,
            }).ToList();

            return toDosMapper;
        }

        public async Task<GetToDoDto> GetToDoByIdAsync(Guid Id)
        {
            var toDo = await _toDoRepository.GetToDoByIdAsync(Id);

            if (toDo is null)
            {
                return null;
            }

            var toDosMapper = new GetToDoDto
            {
                Id = toDo.Id,
                Name = toDo.Name,
                Description = toDo.Description,
                Status = toDo.Status,
            };

            return toDosMapper;
        }

        public async Task<GetToDoDto> CreateToDoAsync(CreateToDoDto newToDo)
        {
            var newToDoEntity = new ToDo
            {
                Name = newToDo.Name,
                Description = newToDo.Description,
                Status = newToDo.Status,
            };

            var toDo = await _toDoRepository.CreateToDoAsync(newToDoEntity);

            return new GetToDoDto { Id = toDo.Id, Description = newToDo.Description, Status = newToDo.Status, Name = toDo.Name };
        }

        public Task<bool> DeleteToDoByIdAsync(Guid id)
        {
            return _toDoRepository.DeleteToDoByIdAsync(id);
        }

        public async Task<GetToDoDto> UpdateToDoAsync(Guid id, UpdateToDoDto updatedToDo)
        {
            var updatedToDoEntity = new ToDo
            {
                Name = updatedToDo.Name,
                Description = updatedToDo.Description,
                Status = updatedToDo.Status,
            };
            
            var toDo = await _toDoRepository.UpdateToDoAsync(id,  updatedToDoEntity);

            if (toDo is null)
            {
                return null;
            }

            return new GetToDoDto
            {
                Id = toDo.Id,
                Description = toDo.Description,
                Status = toDo.Status,
                Name = toDo.Name
            };

        }
    }
}
