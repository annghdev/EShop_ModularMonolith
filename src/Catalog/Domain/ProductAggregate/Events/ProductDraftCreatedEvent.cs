namespace Catalog.Domain;

public record ProductDraftCreatedEvent(Product Payload) : DomainEvent;
