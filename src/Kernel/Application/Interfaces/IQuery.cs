using MediatR;

namespace Kernel.Application;

public interface IQuery : IRequest
{
    public string CacheKey { get; set; }
    public TimeSpan? ExpirationSliding { get; set; }
}
