using Kanban_AKM.Web.Data;
using Kanban_AKM.Web.Models.DTOs.Columns;

namespace Kanban_AKM.Web.Services
{
    public class ColumnService(KanbanDbContext dbContext) : IColumnService
    {
        public async Task<ColumnDto> CreateAsync(CreateColumnDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ColumnDto?> GetColumnByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(long id, UpdateColumnDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
