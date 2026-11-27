using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Kanban_AKM.Web.Models.Entities
{
    public class BoardEntity
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public List<ColumnEntity> Columns { get; set; } = [];
        public long Owner_ID { get; set; }
    }
}
