using Kanban_AKM.Web.Models.DTOs.Tasks;
namespace Kanban_AKM.Web.Models.DTOs.Columns;

public sealed record ColumnDto(
    long Id,
    string Title,
    int Position,
    IReadOnlyList<TaskDto> Tasks);
