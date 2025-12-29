using MediatR;

namespace Common;

public interface IQuery : IRequest
{
    public string CacheKey { get; set; }
    public TimeSpan? ExpiryTime { get; set; }
}
