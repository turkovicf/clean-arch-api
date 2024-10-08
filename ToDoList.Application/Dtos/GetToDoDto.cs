namespace ToDoList.Application.Dtos
{
    public class GetToDoDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required bool Status { get; set; }
    }
}
