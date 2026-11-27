using Kanban_AKM.Web.Data;
using Kanban_AKM.Web.Models.DTOs.Tasks;

namespace Kanban_AKM.Web.Services
{
    public class TaskService(KanbanDbContext dbContext) : ITaskService
    {
        public async Task<TaskDto> CreateAsync(CreateTaskDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskDto?> GetTaskByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(long id, UpdateTaskDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
