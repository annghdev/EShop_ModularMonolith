using Kernel.Application;
using Kernel.Application.Interfaces;
using Kernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Infrastructure;

public abstract class BaseUnitOfWork<TContext>(TContext context, ICurrentUser user) : IUnitOfWork
    where TContext : DbContext
{
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo();
        await context.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditInfo()
    {
        if (context == null) return;

        var entries = context.ChangeTracker.Entries()
            .Where(e => e.Entity is AuditableEntity)
            .ToList();

        foreach (var entry in entries)
        {
            var now = DateTimeOffset.UtcNow;
            var currentUserId = user.UserId.ToString();
            var currentUserName = user.FullName ?? user.Email ?? currentUserId ?? "system";
            if (entry.Entity is AuditableEntity entity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedAt = now;
                        entity.CreatedBy = currentUserName;
                        break;

                    case EntityState.Modified:
                        entity.UpdatedAt = now;
                        entity.UpdatedBy = currentUserName;
                        break;

                    case EntityState.Deleted:
                        entity.IsDeleted = true;
                        entity.UpdatedAt = now;
                        entity.UpdatedBy = currentUserName;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
        }
    }
}
