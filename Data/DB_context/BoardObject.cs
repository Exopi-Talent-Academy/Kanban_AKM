namespace Kanban_AKM.Data.DB_context
{
    public class BoardObject
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TaskObject> Tasks { get; set; }
        public string Owner_ID { get; set; }

    }
}