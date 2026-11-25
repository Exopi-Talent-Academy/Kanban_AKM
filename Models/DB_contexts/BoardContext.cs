using Microsoft.EntityFrameworkCore;

namespace Kanban_AKM.Models.DB_contexts;
public class Board_DB_Context : DbContext
{
	public DbSet<BoardObject> boards { get;set; }
	public Board_DB_Context(DbContextOptions<Board_DB_Context> options) : base(options){ }
}
