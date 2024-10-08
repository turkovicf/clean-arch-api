namespace ToDoList.Application.Dtos
{
    public class CreateToDoDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required bool Status { get; set; }
    }
}
