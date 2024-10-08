using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Dtos;
using ToDoList.Application.Services.ToDoService;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDosController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDosAsync()
        {
            var result = await _toDoService.GetToDosAsync();

            return Ok(result);
        }

        [HttpGet("{toDoId}")]
        public async Task<IActionResult> GetToDoByIdAsync(Guid toDoId)
        {
            var result = await _toDoService.GetToDoByIdAsync(toDoId);

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoAsync(CreateToDoDto newToDo)
        {
            try
            {
                var result = await _toDoService.CreateToDoAsync(newToDo);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{toDoId}")]
        public async Task<IActionResult> UpdateToDoAsync(Guid toDoId, UpdateToDoDto newToDo)
        {
            try
            {
                var result = await _toDoService.UpdateToDoAsync(toDoId, newToDo);
                
                return result is not null ? Ok(result) : NotFound();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{toDoId}")]
        public async Task<IActionResult> DeleteToDoByIdAsync(Guid toDoId)
        {
            try
            {
                var result = await _toDoService.DeleteToDoByIdAsync(toDoId);

                if (result is true)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
