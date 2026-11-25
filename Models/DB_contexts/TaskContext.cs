using Microsoft.EntityFrameworkCore;

namespace Kanban_AKM.Models.DB_contexts;
public class Task_DB_Context : DbContext
{
	public DbSet<TaskObject> tasks { get;set; }
	public Task_DB_Context(DbContextOptions<Task_DB_Context> options) : base(options){ }
}
