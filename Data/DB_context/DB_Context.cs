using Microsoft.EntityFrameworkCore;

namespace Kanban_AKM.Data.DB_context;

public class DB_Context : DbContext
{
    public DbSet<UserObject> Users { get; set; }
    public DbSet<BoardObject> Boards { get; set; }
    public DbSet<TaskObject> Tasks { get; set; }
    public DB_Context(DbContextOptions<DB_Context> options) : base(options) { }
}