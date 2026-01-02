namespace Catalog.Domain.ProductAggregate.Events;

public record ProductAttributeAddedEvent(ProductAttribute Payload) : DomainEvent;
public record ProductAttributeRemovedEvent(ProductAttribute Payload) : DomainEvent;