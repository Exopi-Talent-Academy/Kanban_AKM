namespace Kanban_AKM.Web.Models.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }
        public List<BoardEntity> Boards { get; set; } = [];
    }
}
