namespace Kanban_AKM.Data.DB_context
{
    public class TaskObject
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeadLine { get; set; }

    }
}