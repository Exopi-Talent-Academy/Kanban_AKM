namespace Kanban_AKM.Web.Models.DTOs.Tasks;

public sealed record TaskDto(
    long Id,
    string Title,
    string? Description,
    int Priority,
    DateTime CreationDate,
    DateTime? Deadline);