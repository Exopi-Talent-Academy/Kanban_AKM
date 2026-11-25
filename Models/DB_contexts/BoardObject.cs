namespace Kanban_AKM.Models.DB_contexts
{
    public class BoardObject
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tasks { get; set; }
        public string Owner_ID { get; set; }

    }
}