using Kanban_AKM.Web.Data;
using Kanban_AKM.Web.Models.DTOs.Boards;

namespace Kanban_AKM.Web.Services;

public class BoardService(KanbanDbContext dbContext) : IBoardService
{
    public async Task<BoardDto> CreateAsync(CreateBoardDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<BoardDto?> GetBoardByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(UpdateBoardDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

