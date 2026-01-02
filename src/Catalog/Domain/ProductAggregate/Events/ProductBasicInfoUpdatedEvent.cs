namespace Catalog.Domain;

public record ProductBasicInfoUpdatedEvent(Product Payload) : DomainEvent;