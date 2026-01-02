using MediatR;

namespace Kernel.Application;

public interface ICommand : IRequest
{
    public IEnumerable<string> CacheKeysToInvalidate { get; }
    public IEnumerable<string> CacheKeyPrefix { get; }
}