using Kanban_AKM.Web.Models.DTOs.Columns;

namespace Kanban_AKM.Web.Models.DTOs.Boards;

public sealed record UpdateBoardDto(
    string? Title,
    string? Description,
    IReadOnlyList<ColumnDto> Columns);