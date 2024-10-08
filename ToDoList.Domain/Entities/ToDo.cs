namespace ToDoList.Domain.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required bool Status { get; set; }
    }
}
