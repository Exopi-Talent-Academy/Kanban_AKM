
namespace Kanban_AKM.Web.Models.DTOs.Boards;

public sealed record CreateBoardDto(
    string Title,
    string? Description);