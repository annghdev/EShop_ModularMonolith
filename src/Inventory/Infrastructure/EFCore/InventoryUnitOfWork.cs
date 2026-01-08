using Inventory.Application;
using Inventory.Domain;

namespace Inventory.Infrastructure;

public class InventoryUnitOfWork(InventoryDbContext context, ICurrentUser user, IPublisher publisher)
    : BaseUnitOfWork<InventoryDbContext>(context, user, publisher), IInventoryUnitOfWork
{
    public DbSet<StockItem> StockItems => context.StockItems;
    public DbSet<StockLog> StockLogs => context.StockLogs;
}
