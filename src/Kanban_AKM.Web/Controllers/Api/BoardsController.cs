using Kanban_AKM.Web.Services;
using Microsoft.AspNetCore.Mvc;

using Kanban_AKM.Web.Models.DTOs.Boards;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kanban_AKM.Web.Controllers.Api;

[Route("api/boards")]
[ApiController]
public class BoardsController(IBoardService boardService) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<ActionResult<BoardDto>> GetBoard(
        long id,
        CancellationToken cancellationToken)
    {
        var board = await boardService.GetBoardById(id, cancellationToken);

        return board is null
            ? NotFound()
            : Ok(board);
    }
}
