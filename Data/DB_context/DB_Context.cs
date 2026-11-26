using Microsoft.EntityFrameworkCore;

namespace Kanban_AKM.Data.DB_context;

public class DB_Context : DbContext
{
    public DbSet<UserObject> users { get; set; }
    public DbSet<BoardObject> boards { get; set; }
    public DbSet<TaskObject> tasks { get; set; }
    public DB_Context(DbContextOptions<DB_Context> options) : base(options) { }
}