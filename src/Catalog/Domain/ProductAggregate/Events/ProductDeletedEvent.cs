namespace Catalog.Domain;

public record ProductDeletedEvent(Guid ProductId) : DomainEvent;