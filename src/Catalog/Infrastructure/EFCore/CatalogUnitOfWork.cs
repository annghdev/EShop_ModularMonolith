using Catalog.Application;

namespace Catalog.Infrastructure;

public sealed class CatalogUnitOfWork(CatalogDbContext context, ICurrentUser user) 
    : BaseUnitOfWork<CatalogDbContext>(context, user), ICatalogUnitOfWork
{
}
