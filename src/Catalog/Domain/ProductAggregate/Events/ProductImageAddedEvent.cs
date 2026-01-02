namespace Catalog.Domain.Products.Events;

public record ProductImageAddedEvent(Guid ProductId, string ImageUrl) : DomainEvent;
public record ProductImageRemovedEvent(Guid ProductId, string ImageUrl) : DomainEvent;
