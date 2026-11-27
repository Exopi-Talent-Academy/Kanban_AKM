using Kanban_AKM.Web.Models.DTOs.Boards;

namespace Kanban_AKM.Web.Services;

public interface IBoardService
{
    Task<BoardDto?> GetBoardByIdAsync(
        long id,
        CancellationToken cancellationToken = default);
    Task<BoardDto> CreateAsync(
        CreateBoardDto request,
        CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(
        UpdateBoardDto request,
        CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(
        long id, 
        CancellationToken cancellationToken = default);
}
