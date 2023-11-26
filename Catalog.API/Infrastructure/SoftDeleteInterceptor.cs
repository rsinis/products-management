using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null) return new ValueTask<InterceptionResult<int>>(result);

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;
                entry.State = EntityState.Modified;
                delete.IsDeleted = true;
                delete.DeletedAt = DateTimeOffset.UtcNow;
            }

            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}
