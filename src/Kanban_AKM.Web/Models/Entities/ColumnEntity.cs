namespace Kanban_AKM.Web.Models.Entities
{
    public class ColumnEntity
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public List<TaskEntity> Tasks { get; set; } = [];
    }
}
