using Microsoft.EntityFrameworkCore;
using Kanban_AKM.Web.Models.Entities;

namespace Kanban_AKM.Web.Data
{
    public class KanbanDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BoardEntity> Boards { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options) { }
    }
}
