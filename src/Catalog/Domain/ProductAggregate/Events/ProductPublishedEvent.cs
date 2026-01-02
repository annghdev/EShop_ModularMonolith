namespace Catalog.Domain;

public record ProductPublishedEvent(Guid ProductId) : DomainEvent;
public record ProductDiscontinuedEvent(Guid ProductId) : DomainEvent;
