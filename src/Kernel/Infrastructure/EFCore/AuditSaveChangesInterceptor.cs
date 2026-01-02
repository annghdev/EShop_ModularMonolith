using Kernel.Application;
using Kernel.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Kernel.Infrastructure;

public class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUser _currentUser;

    public AuditSaveChangesInterceptor(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        ApplyAuditInfo(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void ApplyAuditInfo(DbContext? context)
    {
        if (context == null) return;

        var entries = context.ChangeTracker.Entries()
            .Where(e => e.Entity is AuditableEntity)
            .ToList();

        foreach (var entry in entries)
        {
            var now = DateTimeOffset.UtcNow;
            var currentUserId = _currentUser.UserId.ToString();
            var currentUserName = _currentUser.FullName ?? _currentUser.Email ?? currentUserId ?? "system";
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