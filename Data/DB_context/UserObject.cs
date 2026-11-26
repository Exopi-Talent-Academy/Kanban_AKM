namespace Kanban_AKM.Data.DB_context
{
    public class UserObject
    {
        public string ID { get; set; }
        public List<BoardObject> Boards { get; set; }

    }
}