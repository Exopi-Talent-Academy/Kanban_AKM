namespace Kanban_AKM.Models.DB_contexts
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