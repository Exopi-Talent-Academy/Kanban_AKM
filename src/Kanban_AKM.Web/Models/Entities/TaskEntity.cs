namespace Kanban_AKM.Web.Models.Entities
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; } = 0;
        public DateTime? CreationDate { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
