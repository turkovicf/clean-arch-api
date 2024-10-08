using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public ToDoRepository(ApplicationDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
        }

        public async Task<List<ToDo>> GetToDosAsync()
        {
            return await _appDbContext.ToDoList.ToListAsync();
        }

        public async Task<ToDo> GetToDoByIdAsync(Guid id)
        {
            return await _appDbContext.ToDoList.Where(toDo => toDo.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ToDo> CreateToDoAsync(ToDo newToDo)
        {
            _appDbContext.ToDoList.Add(newToDo);
            await _appDbContext.SaveChangesAsync();

            return newToDo;
        }

        public async Task<ToDo> UpdateToDoAsync(Guid id, ToDo updatedToDo)
        {
            var existingToDo = await _appDbContext.ToDoList.FirstOrDefaultAsync(toDo => toDo.Id == id);

            if (existingToDo is not null) { 
                existingToDo.Name = updatedToDo.Name;
                existingToDo.Description = updatedToDo.Description;
                existingToDo.Status = updatedToDo.Status;

                await _appDbContext.SaveChangesAsync();
                return existingToDo;
            }

            return updatedToDo;
        }

        public async Task<bool> DeleteToDoByIdAsync(Guid id)
        {
            var existingToDo = await _appDbContext.ToDoList.FirstOrDefaultAsync(toDo => toDo.Id == id);

            if (existingToDo is not null)
            {
                _appDbContext.ToDoList.Remove(existingToDo);

                return await _appDbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
