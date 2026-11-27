namespace Kanban_AKM.Web.Models.DTOs.Tasks;

public sealed record UpdateTaskDto(
    string? Title,
    string? Description,
    int? Priority,
    DateTime? Deadline);