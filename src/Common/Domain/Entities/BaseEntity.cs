namespace Common;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public long Version { get; set; } = DateTime.Now.Ticks;


    private readonly List<BaseDomainEvent> _events = [];
    public IReadOnlyCollection<BaseDomainEvent> Events => _events.AsReadOnly();

    public void AddEvent(BaseDomainEvent e) => _events.Add(e);
    public void RemoveEvent(BaseDomainEvent e) => _events.Remove(e);
    public void ClearEvents() => _events.Clear();
}
