using Kanban_AKM.Web.Models.DTOs.Columns;

namespace Kanban_AKM.Web.Services;

public interface IColumnService
{
    Task<ColumnDto?> GetColumnByIdAsync(
        long id,
        CancellationToken cancellationToken = default);

    Task<ColumnDto> CreateAsync(
        CreateColumnDto request,
        CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(
        long id,
        UpdateColumnDto request,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        long id,
        CancellationToken cancellationToken = default);
}
