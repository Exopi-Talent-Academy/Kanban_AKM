using Kanban_AKM.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kanban_AKM.Web.Data
{
    public class KanbanDbContext(DbContextOptions<KanbanDbContext> options) 
        : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BoardEntity> Boards { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
