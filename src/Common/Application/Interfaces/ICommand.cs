using MediatR;

namespace Common;

public interface ICommand : IRequest
{
    public IEnumerable<string> InvalidateCacheKeys { get; set; }
    public IEnumerable<string>? InvalidateCachePattern { get; set; }
}