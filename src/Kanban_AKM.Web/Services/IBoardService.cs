using Kanban_AKM.Web.Models.DTOs.Boards;

namespace Kanban_AKM.Web.Services;

public interface IBoardService
{
    Task<BoardDto?> GetBoardById(
        long id,
        CancellationToken cancellationToken = default);
}
