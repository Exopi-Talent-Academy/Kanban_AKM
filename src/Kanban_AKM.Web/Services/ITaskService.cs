using Kanban_AKM.Web.Models.DTOs.Tasks;

namespace Kanban_AKM.Web.Services;

public interface ITaskService
{
    Task<TaskDto?> GetTaskByIdAsync(
        long id,
        CancellationToken cancellationToken = default);

    Task<TaskDto> CreateAsync(
        CreateTaskDto request,
        CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(
        long id,
        UpdateTaskDto request,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        long id,
        CancellationToken cancellationToken = default);
}
