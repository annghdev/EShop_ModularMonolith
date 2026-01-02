namespace Catalog.Domain.ProductAggregate.Events;

public record VariantUpdatedEvent(Variant Payload) : DomainEvent;
